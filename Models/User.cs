



public class User
{

    public string Id { get; set; }

    public string Email { get; set; }



    public User(string email, string id)
    {
        this.Id = id;
        this.Email = email;

    }
}
