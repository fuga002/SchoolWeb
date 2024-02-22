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
        /*modelBuilder.Entity<User>().HasData(new User()
        {
            Id = 1,
            FirstName = "Maruf",
            LastName = "Berdiev",
            UserName = "fuga_02"
        });*/
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
    public DbSet<TaskResponseStatus> TaskResponsesStatus { get; set; }
    public DbSet<TaskResponseResult> TaskResponsesResult { get; set; }
}