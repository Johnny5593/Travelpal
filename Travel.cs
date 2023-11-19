using System.Collections.Generic;

namespace travelpal
{
    public class Travel
    {
        public string? City { get; set; }
        public string? Country { get; set; }
        public int Travelers { get; set; }
        public bool IsWorkTrip { get; set; }
        public bool AllInclusive { get; set; }
        public string? MeetingDetails { get; set; } = string.Empty;
        public List<TravelDocument> Documents { get; set; } = new List<TravelDocument>();
    }
}