namespace Proiect4.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }
    }
}
