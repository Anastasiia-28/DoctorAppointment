using DoctorAppointment.Domain.Entities;
namespace DoctorAppointment.Service.ViewModels
{
    public class AppointmentViewModel
    {
        public string? Patient { get; set; }
        public string? Doctor { get; set; }
        public DateTime DateTimeFrom { get; set; }
        public DateTime DateTimeTo { get; set; }
        public string? Description { get; set; }
    }
}
