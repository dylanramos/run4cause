using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace run4cause.Models
{
    public class Participant
    {
        public int Id { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [DisplayName("Lastname")]
        public string? LastName { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [DisplayName("Firstname")]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 3)]
        [DisplayName("Nickname")]
        public string? Nickname { get; set; }

        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

        [Required]
        [Range(1, 100)]
        [DisplayName("Bib number")]
        public int BibNumber { get; set; }

        [DisplayName("Handicapped")]
        public bool IsHandicapped { get; set; }

        [Required]
        [DisplayName("Gender")]
        public string Gender { get; set; }

        [NotMapped]
        [DisplayName("Profile picture")]
        [DataType(DataType.Upload)]
        public IFormFile Picture { get; set; }

        public string PictureName { get; set; }

        public ICollection<Participation>? Participations { get; set; }
    }
}