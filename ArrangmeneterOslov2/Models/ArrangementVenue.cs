namespace ArrangmeneterOslov2.Models
{
    public class ArrangementVenue
    {
        public int Id { get; set; }
        public string VenueName { get; set; }
        public string? Address { get; set; }
        public int? PeopleLimit { get; set; }
    }
}
