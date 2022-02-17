using System.ComponentModel;

namespace run4cause.Models
{
    public class Course
    {
        public int Id { get; set; }

        [DisplayName("Title")]
        public string? Title { get; set; }

        [DisplayName("Description")]
        public string? Description { get; set; }
    }
}
