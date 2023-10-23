using DoctorAppointment.Data.Interfaces;
using DoctorAppointment.Data.Repositories;
using DoctorAppointment.Domain.Entities;
using DoctorAppointment.Service.Extensions;
using DoctorAppointment.Service.Interfaces;
using DoctorAppointment.Service.ViewModels;

namespace DoctorAppointment.Service.Services
{
    public class AppointmentService : AppointmentRepository, IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        public const string PATH = "F:\\Projects\\DoctorAppointment\\DoctorAppointment\\DoctorAppointment.Data\\MockedDatabase\\appointments.xml";
        public AppointmentService()
        {
            _appointmentRepository = new AppointmentRepository();
        }

        public Appointment CreateToJson(Appointment appointment)
        {
            return _appointmentRepository.CreateToJson(appointment);
        }

        public Appointment CreateToXml(Appointment appointment)
        {
            return _appointmentRepository.CreateToXml(appointment, PATH);
        }

        public IEnumerable<AppointmentViewModel> GetFromXml()
        {
            var appointments = _appointmentRepository.GetFromXml(PATH);
            var appointmentViewModels = appointments.Select(x => x.ConvertTo());
            return appointmentViewModels;
        }

        public IEnumerable<AppointmentViewModel> GetAll()
        {
            var appointments = _appointmentRepository.GetAll();
            var appointmentViewModels = appointments.Select(x => x.ConvertTo());
            return appointmentViewModels;
        }

        public AppointmentViewModel? Get(int id)
        {
            var appointment = _appointmentRepository.GetById(id);
            var appointmentViewModels = appointment?.ConvertTo();
            return appointmentViewModels;
        }

        public bool Delete(int id)
        {
            return _appointmentRepository.Delete(id);
        }

        public Appointment Update(int id, Appointment appointment)
        {
            return _appointmentRepository.Update(id, appointment);
        }
    }
}
