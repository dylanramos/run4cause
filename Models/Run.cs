using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace run4cause.Models
{
    public class Run
    {
        public int Id { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 3)]
        [DisplayName("Title")]
        public string? Title { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 3)]
        [DisplayName("Description")]
        public string? Description { get; set; }
    }
}
