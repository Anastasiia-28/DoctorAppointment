using DoctorAppointment.Data.Interfaces;
using DoctorAppointment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDoctorAppointment.Data.Interfaces
{
    public interface IPatientRepository: IGenericRepository<Patient>
    {
        //Patient Create(Patient patient);

        //Patient GetById(int id);

        //Patient Update(int id, Patient patient);

        //IEnumerable<Patient> GetAll();

        //bool Delete(int id);
    }
}
