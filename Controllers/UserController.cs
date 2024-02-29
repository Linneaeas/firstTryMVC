using Microsoft.AspNetCore.Mvc;
using Npgsql.Replication;

public class CreateUserDto
{
    public string Id { get; set; };
    public string Email { get; set; } = "";
     public string Password { get; set; } = "";
}


public class UserDto
{
    public string Id { get; set; }
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

    public User CreateUser(string id, string email, string password)
    {
        // TODO: Prevent course name duplicates
        User user = new User(id, email, password);

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

    public UserController(UserService userService)
    {
        this.userService = userService;
    }


    /*   [HttpPost]
       public IActionResult CreateUser([FromBody] CreateUserDto dto)
       {
           User user = userService.CreateUser(dto.Id, dto.Email);

           return Ok(new UserDto(user));
       }*/

    [HttpGet("hej")]
    public List<UserDto> GetAllUser()
    {
        return userService.GetAll().Select(user => new UserDto(user)).ToList();
    }

    [HttpPost("test-create-user")]
    public IActionResult TestCreateUser([FromBody] CreateUserDto dto)
    {
        try
        {
            // Call the CreateUser method to add the test user to the database
            User testUser = userService.CreateUser(dto.Id, dto.Email, dto.Password);

            // Return the created user details
            return Ok(new UserDto(testUser));
        }
        catch (Exception ex)
        {
            // Log the exception details
            Console.WriteLine($"Error creating user: {ex.Message}");
            return StatusCode(500, "Internal Server Error");
        }
    }

}



