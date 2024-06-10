namespace Stavnica;

public class User
{
    public int Id { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public User(int Id, string Username, string Password)
    {
        this.Id = Id;
        this.Username = Username;
        this.Password = Password;
    }

    
}