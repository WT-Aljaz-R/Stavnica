using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stavnica;

public class User
{

    private static int NextId = 1;

    public int Id { get; set; }

    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }

    public User(string Username, string Password)
    {
        this.Id = NextId++;
        this.Username = Username;
        this.Password = Password;
    }


}