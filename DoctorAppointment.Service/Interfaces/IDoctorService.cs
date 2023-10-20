using DoctorAppointment.Domain.Entities;
using DoctorAppointment.Service.ViewModels;

namespace DoctorAppointment.Service.Interfaces
{
    public interface IDoctorService
    {
        Doctor Create(Doctor doctor);

        IEnumerable<DoctorViewModel> GetAll();
        DoctorViewModel Get(int id);

        bool Delete(int id);
        Doctor Update(int id, Doctor doctor);
    }
}
