using System.ComponentModel;

namespace run4cause.Models
{
    public class Participant
    {
        public int Id { get; set; }

        [DisplayName("Lastname")]
        public string? LastName { get; set; }

        [DisplayName("Firstname")]
        public string? FirstName { get; set; }
    }
}