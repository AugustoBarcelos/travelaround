public class Trip
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public List<Pin> Pins { get; set; } = new();
}