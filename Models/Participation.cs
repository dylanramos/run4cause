using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace run4cause.Models
{
    public class Participation
    {
        public int Id { get; set; }

        [DisplayName("Participant")]
        public Participant? Participant { get; set;}

        public int ParticipantID { get; set; }

        [DisplayName("Run")]
        public Run? Run { get; set; }

        public int RunID { get; set; }

        [DisplayName("Date/time")]
        public DateTime DateTime { get; set; }
    }
}
