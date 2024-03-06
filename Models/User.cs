using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class User
{
  [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string Email { get; set; }
     public string Password { get; set; }



    public User(string email, string password)
    {
        Id = Guid.NewGuid(); // Generate a new Guid here or use a default value
        Email = email;
        Password = password;
    }
}


