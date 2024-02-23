using Microsoft.AspNetCore.Authorization;

namespace SchoolApi.Attributes;

public class CustomAuthorizeAttribute : AuthorizeAttribute
{
    public CustomAuthorizeAttribute(params string[] roles)
    {
        Roles = string.Join(",", roles);
    }
}