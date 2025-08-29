using DIKESE.Data;
using DIKESE.Data.Base;
using DIKESE.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DIKESE.Models
{
    public class NewSeminarVM
    {
        public int Id { get; set; }

        [Display(Name = "Seminar name")]
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        [Display(Name = "Seminar description")]
        [Required(ErrorMessage = "Description is required")]
        public string? Description { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Seminar poster URL")]
        [Required(ErrorMessage = "Seminar poster URL is required")]
        public string? ImageURL { get; set; }

        [Display(Name = "Seminar start date")]
        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Seminar end date")]
        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "Seminar category is required")]
        public SeminarCategory SeminarCategory { get; set; }

        //Relationships
        [Display(Name = "Select Speakers")]
        [Required(ErrorMessage = "Seminar Speakers actor(s) is required")]
        public List<int>? SpeakerIds { get; set; }

        [Display(Name = "Select an Auditorium")]
        [Required(ErrorMessage = "Seminar Auditorium is required")]
        public int RoomId { get; set; }

        [Display(Name = "Select a Sponsor")]
        [Required(ErrorMessage = "Seminar Sponsor is required")]
        public int SponsorId { get; set; }
    }
}