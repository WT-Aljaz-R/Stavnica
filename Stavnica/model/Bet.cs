namespace Stavnica;

public class Bet
{
    private static int NextId = 1;

    public int Id { get; set; }

    public int UserId { get; set; }

    public float PayIn { get; set; }

    public float PayOut { get; set; }

    public int SportEventId { get; set; }

    public string Side { get; set; }

     public Bet( int userId, float payIn, float payOut, int sportEventId, string side)
    {
        Id = NextId++;
        UserId = userId;
        PayIn = payIn;
        PayOut = payOut;
        SportEventId = sportEventId;
        Side = side;
    }
}