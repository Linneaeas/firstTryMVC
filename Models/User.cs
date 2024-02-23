

public class User
{
    public string Id { get; set; }
    public string Email { get; set; }


    public User(string id, string email)
    {
        this.Id = id;
        this.Email = email;
    }
}


