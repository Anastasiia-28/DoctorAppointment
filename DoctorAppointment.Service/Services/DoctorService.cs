using DoctorAppointment.Data.Interfaces;
using DoctorAppointment.Data.Repositories;
using DoctorAppointment.Domain.Entities;
using DoctorAppointment.Service.Extensions;
using DoctorAppointment.Service.Interfaces;
using DoctorAppointment.Service.ViewModels;

namespace DoctorAppointment.Service.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService()
        {
            _doctorRepository = new DoctorRepository();
        }

        public Doctor Create(Doctor doctor)
        {
            return _doctorRepository.Create(doctor);
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
