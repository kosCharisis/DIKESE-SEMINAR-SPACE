namespace DIKESE.Models
{
    public class Speaker_Seminar
    {
        public int SeminarId { get; set; }
        public Seminar Seminar { get; set; }

        public int SpeakerId { get; set; }

        public Speaker Speaker { get; set; }
    }
}
