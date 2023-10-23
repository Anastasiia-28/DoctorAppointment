using DoctorAppointment.Domain.Entities;
using DoctorAppointment.Service.Extensions;
using DoctorAppointment.Service.Interfaces;
using DoctorAppointment.Service.ViewModels;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Data.Repositories;


namespace DoctorAppointment.Service.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private const string PATH = "F:\\Projects\\DoctorAppointment\\DoctorAppointment\\DoctorAppointment.Data\\MockedDatabase\\patients.xml";
        public PatientService()
        {
            _patientRepository = new PatientRepository();
        }

        public Patient CreateToJson(Patient patient)
        {
            return _patientRepository.CreateToJson(patient);
        }

        public Patient CreateToXml(Patient patient)
        {
            return _patientRepository.CreateToXml(patient, PATH);
        }

        public IEnumerable<PatientViewModel> GetFromXml()
        {
            var patients = _patientRepository.GetFromXml(PATH);
            var patientViewModels = patients.Select(x => x.ConvertTo());
            return patientViewModels;
        }
        public IEnumerable<PatientViewModel> GetAll()
        {
            var patients = _patientRepository.GetAll();
            var patientViewModels = patients.Select(x => x.ConvertTo());
            return patientViewModels;
        }

        public PatientViewModel? Get(int id)
        {
            var patient = _patientRepository.GetById(id);
            var patientViewModels = patient?.ConvertTo();
            return patientViewModels;
        }

        public bool Delete(int id)
        {
            return _patientRepository.Delete(id);
        }

        public Patient Update(int id, Patient patient)
        {
            return _patientRepository.Update(id, patient);
        }

    }
}
