namespace Tournament.Api.Data.Models
{
    public class Tournament
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int TeamsInvolved { get; set; }

        public string? Organizer { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
