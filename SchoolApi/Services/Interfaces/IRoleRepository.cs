namespace SchoolApi.Services.Interfaces;

public interface IRoleRepository
{
    Task<bool> IsExistRole(string roleName);
}