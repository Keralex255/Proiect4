namespace Proiect4.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
    }
}
