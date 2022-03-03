using System.ComponentModel;

namespace run4cause.Models
{
    public class Participation
    {
        public int Id { get; set; }

        [DisplayName("Participant")]
        public Participant? Participant { get; set;}

        [DisplayName("Run")]
        public Run? Run { get; set; }

        [DisplayName("Date/time")]
        public DateTime DateTime { get; set; }
    }
}
