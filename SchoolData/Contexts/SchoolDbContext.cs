using Microsoft.EntityFrameworkCore;
using SchoolData.Entities;
using Task = SchoolData.Entities.Task;

namespace SchoolData.Contexts;

public class SchoolDbContext:DbContext
{
    public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(new User
        {
            Id = Guid.NewGuid(),
            FirstName = "Maruf",
            LastName = "Berdiev",
            UserName = "fuga_02",
            PasswordHash = "password123",
            BornDate = "2002-31-10",
            UserRole = "Admin",
            CreatedDateTime = DateTime.Now
        
        });
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<UserSubject> UsersSubjects { get; set; }
    public DbSet<SubjectRequest> SubjectRequests { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<TaskResponse> TaskResponses { get; set; }
    public DbSet<TaskResponseResult> TaskResponsesResult { get; set; }
}