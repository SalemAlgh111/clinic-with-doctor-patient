using ClinikData.Helpers;

namespace ClinikData.Models
{
    public class AppointmentVM
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime CreationDate { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }

        public string DoctorName { get; set; } = null!;

        public string RawStatus { get; set; } = null!;
        public string Status =>
           RawStatus == Statuses.Scheduled.ToString() && AppointmentDate < DateTime.Now
           ? "No Show" : RawStatus;
    }
}
