using DoctorAppointment.Data.Interfaces;
using DoctorAppointment.Data.Repositories;
using DoctorAppointment.Domain.Entities;
using DoctorAppointment.Service.Extensions;
using DoctorAppointment.Service.Interfaces;
using DoctorAppointment.Service.ViewModels;

namespace DoctorAppointment.Service.Services
{
    public class DoctorService : DoctorRepository, IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private const string PATH = "F:\\Projects\\DoctorAppointment\\DoctorAppointment\\DoctorAppointment.Data\\MockedDatabase\\doctors.xml";
        public DoctorService()
        {
            _doctorRepository = new DoctorRepository();
        }

        public Doctor CreateToJson(Doctor doctor)
        {
            return _doctorRepository.CreateToJson(doctor);
        }

        public Doctor CreateToXml(Doctor doctor)
        {
            return _doctorRepository.CreateToXml(doctor, PATH);
        }

        public IEnumerable<DoctorViewModel> GetFromXml()
        {
            var doctors = _doctorRepository.GetFromXml(PATH);
            var doctorViewModels = doctors.Select(x => x.ConvertTo());
            return doctorViewModels;
        }

        public IEnumerable<DoctorViewModel> GetAll()
        {
            var doctors = _doctorRepository.GetAll();
            var doctorViewModels = doctors.Select(x => x.ConvertTo());
            return doctorViewModels;
        }

        public DoctorViewModel? Get(int id)
        {
            var doctor = _doctorRepository.GetById(id);
            var doctorViewModels = doctor?.ConvertTo();
            return doctorViewModels;
        }

        public bool Delete(int id)
        {
            return _doctorRepository.Delete(id);
        }

        public Doctor Update(int id, Doctor doctor)
        {
            return _doctorRepository.Update(id, doctor);
        }

    }
}
