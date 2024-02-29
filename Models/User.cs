

public class User
{
    public string Id { get; set; }
    public string Email { get; set; }
     public string Password { get; set; }


    public User(string id, string email, string password)
    {
        this.Id = id;
        this.Email = email;
         this.Password = password;
    }
}


