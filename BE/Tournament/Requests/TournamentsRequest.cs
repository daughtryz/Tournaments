namespace Tournament.Api.Requests
{
    public class TournamentsRequest
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? StartDate { get; set; }

        public string? EndDate { get; set; }

        public int TeamsInvolved { get; set; }

        public string? Organizer { get; set; }
    }
}
