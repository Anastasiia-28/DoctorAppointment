using DoctorAppointment.Domain.Entities;

namespace DoctorAppointment.Data.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>
    {
        public override string Path { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override int LastId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void ShowInfo(Appointment source)
        {
            throw new NotImplementedException();
        }

        protected override void SaveLastId()
        {
            throw new NotImplementedException();
        }
    }
}
