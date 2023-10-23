﻿using DoctorAppointment.Domain.Enums;
using System.Xml.Serialization;

namespace DoctorAppointment.Domain.Entities
{
    public class Doctor: UserBase
    {
        public DoctorTypes DoctorType { get; set; }
        public byte Experience { get; set; }
        public decimal Salary { get; set; }
    }
}
