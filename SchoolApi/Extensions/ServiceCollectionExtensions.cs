using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SchoolApi.Managers;
using SchoolApi.Providers;
using SchoolApi.Services.Interfaces;
using SchoolApi.Services;
using SchoolData.Contexts;
using SchoolData.Options;

namespace SchoolApi.Extensions;

public static  class ServiceCollectionExtensions
{
    private static void AddJwt(this IServiceCollection services, IConfiguration configuration)
    {
        var section = configuration.GetSection(nameof(JwtOptions));
        services.Configure<JwtOptions>(section);
        JwtOptions jwtOptions = section.Get<JwtOptions>()!;
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                var signingKey = System.Text.Encoding.UTF32.GetBytes(jwtOptions.SigningKey);
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = jwtOptions.ValidIssuer,
                    ValidAudience = jwtOptions.ValidAudience,
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    IssuerSigningKey = new SymmetricSecurityKey(signingKey),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
    }

    public static void AddIdentity(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddJwt(configuration); 

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ISubjectRepository, SubjectRepository>();
        services.AddScoped<ISubjectRequestRepository, SubjectRequestRepository>();
        services.AddScoped<IUserSubjectRepository, UserSubjectRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<ITaskRepository, TaskRepository>();
        services.AddScoped<ITaskResponseRepository, TaskResponseRepository>();

        services.AddScoped<SubjectManager>();
        services.AddScoped<SubjectRequestManager>();
        services.AddScoped<JwtTokenManager>();
        services.AddScoped<UserManager>();
        services.AddScoped<TaskManager>();
        services.AddScoped<TaskResponseManager>();

        services.AddScoped<UserProvider>();

        services.AddHttpContextAccessor();
        
    }


    public static void MigrateIdentityDb(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var services = scope.ServiceProvider;
        var identityDb = services.GetService<SchoolDbContext>();

        if (identityDb != null)
        {
            identityDb.Database.Migrate();
        }
    }
}