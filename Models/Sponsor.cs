using DIKESE.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace DIKESE.Models
{
    public class Sponsor : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile Picture is required")]
        public string? ProfilePictureURL { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 50 characters")]
        public string? FullName { get; set; }

        [Display(Name = "Details")]
        [Required(ErrorMessage = "Details required")]
        public string? Bio { get; set; }

        //Relationships
        public List<Seminar>? Seminars { get; set; }
    }
}
