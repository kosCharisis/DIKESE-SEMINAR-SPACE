using DIKESE.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace DIKESE.Models
{
    public class Room : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Auditorium Logo")]
        [Required(ErrorMessage = "Auditorium Logo is required")]
        public string? Logo { get; set; }

        [Display(Name = "Auditorium Name")]
        [Required(ErrorMessage = "Auditorium Name is required")]

        public string? Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Auditorium description is required")]

        public string? Description { get; set; }

        //Relationships
        public List<Seminar>? Seminars { get; set; }
    }
}
