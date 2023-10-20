using DoctorAppointment.Domain.Entities;
using DoctorAppointment.Service.ViewModels;

namespace DoctorAppointment.Service.Interfaces
{
    public interface IPatientService
    {
        Patient Create(Patient patient);
        IEnumerable<PatientViewModel> GetAll();
        PatientViewModel Get(int id);
        bool Delete(int id);
        Patient Update(int id, Patient patient);
    }
}
