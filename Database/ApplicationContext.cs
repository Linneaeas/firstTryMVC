using Microsoft.EntityFrameworkCore;


public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options) { }

}

public interface IUserRepository
{
    User SaveUser(User user);
}

public class UserRepository : IUserRepository
{
    ApplicationContext context;

    public UserRepository(ApplicationContext context)
    {
        this.context = context;
    }

    public User SaveUser(User user)
    {
        context.Users.Add(user);
        context.SaveChanges();
        return user;
    }
}