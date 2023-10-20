﻿using DoctorAppointment.Data.Interfaces;
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

    }
}
