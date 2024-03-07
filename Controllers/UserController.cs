using Microsoft.AspNetCore.Mvc;
using Npgsql.Replication;

public class CreateUserDto
{
    public Guid Id { get; set; }
    public string Email { get; set; } = "";
     public string Password { get; set; } = "";
}


public class UserDto
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public UserDto(User user)
    {
        this.Id = user.Id;
        this.Email = user.Email;
        this.Password = user.Password;
    }
}

public class UserService
{
    ApplicationContext context;

    public UserService(ApplicationContext context)
    {
        this.context = context;
    }

    public User CreateUser( string email, string password)
    {
        // TODO: Prevent course name duplicates
    User user = new User(email, password);

        context.Users.Add(user);
        context.SaveChanges();

        return user;
    }
    public List<User> GetAll()
    {
        return context.Users.ToList();
    }
}

[ApiController]
[Route("api")]
public class UserController : ControllerBase
{
    UserService userService;
     ApplicationContext context;

    public UserController(UserService userService)
    {
        this.userService = userService;
         this.context = context;
    }


    [HttpPost]
    [Authorize("create_user")]
    public IActionResult CreateUser([FromBody] CreateUserDto dto)
    {
        try
        {
            User user = userService.CreateUser(dto.Email, dto.Password);
            return Ok(new UserDto(user));
        }
        catch (DuplicateNameException)
        {
            return Conflict($"A user with the email '{dto.Email}' already exists.");
        }
        catch (ArgumentException)
        {
            return BadRequest($"'Email' and 'Password' must not be null or empty.");
        }
    }

    [HttpGet("hej")]
    public List<UserDto> GetAllUsers()
    {
        return userService.GetAll().Select(user => new UserDto(user)).ToList();
    }

   

}



