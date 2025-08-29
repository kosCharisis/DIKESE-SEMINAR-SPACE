using DIKESE.Data.Base;
using DIKESE.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DIKESE.Models
{
    public class Seminar : IEntityBase
    {
        [Key]
        public int  Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public double Price { get; set; }

        public string? ImageURL { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public SeminarCategory SeminarCategory { get; set; }

        //Relationships
        public List<Speaker_Seminar>? Speakers_Seminars { get; set; }

        //Room
        public int  RoomId { get; set; }
        [ForeignKey("RoomId")]
        public Room Room { get; set; }

        //Sponsor
        public int SponsorId { get; set; }
        [ForeignKey("SponsorId")]

        public Sponsor Sponsor { get; set; }






    }
}
