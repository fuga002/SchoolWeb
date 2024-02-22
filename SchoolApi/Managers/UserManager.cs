using Microsoft.AspNetCore.Identity;
using SchoolApi.Exceptions;
using SchoolApi.Extensions;
using SchoolApi.Services;
using SchoolApi.Services.Interfaces;
using SchoolData.Entities;
using SchoolData.Models;
using SchoolData.StaticServices;
using Task = System.Threading.Tasks.Task;

namespace SchoolApi.Managers;

public class UserManager
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly JwtTokenManager _jwtTokenManager;

    public UserManager(JwtTokenManager jwtTokenManager, IUserRepository userRepository, IRoleRepository roleRepository)
    {
        _jwtTokenManager = jwtTokenManager;
        _userRepository = userRepository;
        _roleRepository = roleRepository;
    }


    public async Task<UserModel> Register(CreateUserModel model)
    {
        if (await _userRepository.IsUserNameExist(model.Username))
        {
            throw new UsernameExistException(model.Username);
        }
        var user = new User()
        {
            FirstName = model.Firstname,
            LastName = model.Lastname,
            UserName = model.Username,
            BornDate = model.BornDate,
            UserRole = await _roleRepository.IsExistRole(model.UserRole) ? model.UserRole : StaticNames.StudentRole,
            PhotoUrl = "/Photos/user.png"
        };

        user.PasswordHash = new PasswordHasher<User>().HashPassword(user,model.Password);
        await _userRepository.AddUser(user);
        return user.ParseModel();
    }

    public async Task<string> Login(LoginUserModel model)
    {
        var userName = await _userRepository.GetByUserName(model.Username);
        var result = new PasswordHasher<User>().
            VerifyHashedPassword(userName, userName.PasswordHash, model.Password);

        if (result == PasswordVerificationResult.Failed)
        {
            throw new InCorrectPassword(model.Password);
        }
        var token = _jwtTokenManager.GenerateToken(userName);
        return token;
    }

    public async Task<UserModel?> GetUser(string username)
    {
        var user= await _userRepository.GetByUserName(username); if (user is null)
            throw new UserNotFoundException(username);
        return user.ParseModel();
    }
    public async Task<UserModel?> GetUser(Guid id)
    {
        var user= await _userRepository.GetUserById(id); 
        if (user is null)
            throw new UserNotFoundException(id.ToString());
        return user.ParseModel();
    }
    
    public async Task<UserModel> UpdateUser(UpdateUserModel model, Guid userId)
    {
        var user = await  _userRepository.GetUserById(userId);
        if (user is null)
            throw new UserNotFoundException(userId.ToString());
        if (!string.IsNullOrEmpty(model.Firstname))
            user.FirstName = model.Firstname;
        if (!string.IsNullOrEmpty(model.Lastname))
            user.LastName = model.Lastname;
        if (!string.IsNullOrEmpty(model.Firstname))
            user.FirstName = model.Firstname;
        if (!string.IsNullOrEmpty(model.BornDate))
            user.BornDate = model.BornDate;
        if (!string.IsNullOrEmpty(model.UserRole))
            user.UserRole = await _roleRepository.IsExistRole(model.UserRole)
                ? model.UserRole
                : user.UserRole;
        await _userRepository.UpdateUser(user);
        return user.ParseModel();
    }

    public async Task<UserModel> UpdatePhoto(Guid userId,IFormFile file)
    {
        var user = await _userRepository.GetUserById(userId);
        user.PhotoUrl = await FileService.SaveFile(file);
        await _userRepository.UpdateUser(user);
        return user.ParseModel();
    }

}