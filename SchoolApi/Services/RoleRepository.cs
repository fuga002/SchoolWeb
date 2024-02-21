using Microsoft.EntityFrameworkCore;
using SchoolApi.Services.Interfaces;
using SchoolData.Contexts;

namespace SchoolApi.Services;

public class RoleRepository: IRoleRepository
{
    private readonly SchoolDbContext _context;

    public RoleRepository(SchoolDbContext context)
    {
        _context = context;
    }

    public async Task<bool> IsExistRole(string roleName)
    {
        var isExists = await _context.Roles.Where(r => r.RoleName == roleName).AnyAsync();
        return isExists;
    }
}