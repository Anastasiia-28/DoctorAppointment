using DoctorAppointment.Domain.Entities;
using DoctorAppointment.Service.ViewModels;

namespace DoctorAppointment.Service.Interfaces
{
    public interface IPatientService
    {
        Patient CreateToJson(Patient patient);
        Patient CreateToXml(Patient patient);
        IEnumerable<PatientViewModel> GetFromXml();
        IEnumerable<PatientViewModel> GetAll();
        PatientViewModel Get(int id);
        bool Delete(int id);
        Patient Update(int id, Patient patient);
    }
}
