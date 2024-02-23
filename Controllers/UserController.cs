using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    private ApplicationContext context;

    public UserController(ApplicationContext context)
    {
        this.context = context;
    }

    [HttpPost]
    public string CreateUser([FromQuery] string email, string id)
    {
        User user = new User(email, id);

        // Registrera ett tillägg (spara i databasen).
        // DbContext gör inga ändringar direkt. 'SaveChanges' måste användas.
        context.Users.Add(user);

        // Utför ändringar.
        context.SaveChanges();

        return "Created user";
    }
}