using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SchoolApi.Extensions;
using SchoolApi.Managers;
using SchoolApi.Providers;
using SchoolApi.Services;
using SchoolApi.Services.Interfaces;
using SchoolData.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Description = "JWT Bearer. : \"Authorization: Bearer { token } \"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    });
});
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
builder.Services.AddDbContext<SchoolDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("SchoolDb"));
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<UserProvider>();
builder.Services.AddIdentity(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(c => c.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()); app.UseAuthorization();

app.MapControllers();

app.Run();
