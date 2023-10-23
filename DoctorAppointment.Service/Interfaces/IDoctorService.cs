using DoctorAppointment.Domain.Entities;
using DoctorAppointment.Service.ViewModels;

namespace DoctorAppointment.Service.Interfaces
{
    public interface IDoctorService
    {
        Doctor CreateToJson(Doctor doctor);
        Doctor CreateToXml(Doctor doctor);
        IEnumerable<DoctorViewModel> GetFromXml();
        IEnumerable<DoctorViewModel> GetAll();
        DoctorViewModel Get(int id);
        bool Delete(int id);
        Doctor Update(int id, Doctor doctor);
    }
}
