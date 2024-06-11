namespace Stavnica;

public class BetRequest
{
    public string Side { get; set; }
    public float PayIn { get; set; }
    public int SportEventId { get; set; }
    public int UserId { get; set; }
}