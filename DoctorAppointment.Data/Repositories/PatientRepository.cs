﻿using DoctorAppointment.Data.Configuration;
using DoctorAppointment.Data.Repositories;
using DoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Data.Interfaces;

namespace MyDoctorAppointment.Data.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        public override string Path { get; set; }
        public override int LastId { get; set; }

        public PatientRepository()
        {
            dynamic result = ReadFromAppSettings();

            Path = result.Database.Patients.Path;
            LastId = result.Database.Patients.LastId;
        }

        protected override void SaveLastId()
        {
            dynamic result = ReadFromAppSettings();
            result.Database.Patients.LastId = LastId;

            File.WriteAllText(Constants.AppSettingsPath, result.ToString());
        }
        public override void ShowInfo(Patient patient)
        {
            Console.WriteLine();
        }
    }
}
