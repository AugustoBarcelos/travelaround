namespace TravelMapApi.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public List<Pin> Pins { get; set; } = new();
    }
}