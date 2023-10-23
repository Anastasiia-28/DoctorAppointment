using DoctorAppointment.Domain.Entities;
using DoctorAppointment.Service.ViewModels;

namespace DoctorAppointment.Service.Interfaces
{
    public interface IAppointmentService
    {
        Appointment CreateToJson(Appointment appointment);
        Appointment CreateToXml(Appointment appointment);
        IEnumerable<AppointmentViewModel> GetFromXml();
        IEnumerable<AppointmentViewModel> GetAll();
        AppointmentViewModel Get(int id);
        bool Delete(int id);
        Appointment Update(int id, Appointment appointment);
    }
}
