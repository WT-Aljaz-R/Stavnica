namespace Stavnica;

public class Bet
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int SportEventId { get; set; }

    public string Side { get; set; }
}