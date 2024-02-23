using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.Common.Models;
using SchoolApi.Attributes;
using SchoolApi.Exceptions;
using SchoolApi.Managers;
using SchoolApi.Providers;

namespace SchoolApi.Controllers;


[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly UserManager _userManager;
    private readonly UserProvider _userProvider;

    public UsersController(UserManager userManager, UserProvider userProvider)
    {
        _userManager = userManager;
        _userProvider = userProvider;
    }
    [CustomAuthorize("Admin")]
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] CreateUserModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        try
        {       
            var user = await _userManager.Register(model);
            return Ok(user);
        }
        catch (UsernameExistException e)
        {
            return BadRequest("UserName is already exists");
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var token = await _userManager.Login(model);
            return Ok(new { Token = token });
        }
        catch (UserNotFoundException e)
        {
            return BadRequest("User not found ");
        }
        catch (InCorrectPassword e)
        {
            return BadRequest("Given password is incorrect");
        }
    }


    [HttpGet("profile")]
    [Authorize]
    public async Task<IActionResult> Profile()
    {
        var userId = _userProvider.UserId;
        try
        {
            var user = await _userManager.GetUser(userId);
            return Ok(user);

        }
        catch (UserNotFoundException e)
        {
            return Unauthorized();
        }


    }
    [HttpPost("{userName}")]
    public async Task<IActionResult> GetUser(string userName)
    {
        try
        {
            var user = await _userManager.GetUser(userName);
            return Ok(user);
        }
        catch (UserNotFoundException e)
        {
            return BadRequest("User not found");
        }

    }

    [HttpPut("updateDetails/{userId}")]
    public async Task<IActionResult> UpdateUserDetails(UpdateUserModel model)
    {
        var userId = _userProvider.UserId;
        var user = await _userManager.UpdateUser(model, userId);
        return Ok(user);
    }

    [HttpPut("updatePhoto/{userId}")]
    public async Task<IActionResult> UpdateUserPhoto([FromBody] IFormFile file)
    {
        var userId = _userProvider.UserId;
        var user = await _userManager.UpdatePhoto(userId, file);
        return Ok(user);
    }
}

