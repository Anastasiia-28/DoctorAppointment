using DoctorAppointment.Domain.Entities;
using DoctorAppointment.Domain.Enums;
using DoctorAppointment.Service.ViewModels;

namespace DoctorAppointment.Service.Extensions
{
    public static class Mapper
    {
        public static DoctorViewModel ConvertTo(this Doctor doctor)
        {
            if (doctor == null)
                return null;

            string doctorType = string.Empty;

            switch (doctor.DoctorType)
            {
                case DoctorTypes.Dentist:
                    doctorType = "Dentist";
                    break;
                case DoctorTypes.Dermatologist:
                    doctorType = "Dermatologist";
                    break;
                case DoctorTypes.Ophthalmologist:
                    doctorType = "Ophthalmologist";
                    break;
                case DoctorTypes.InfectiousDiseaseSpecialist:
                    doctorType = "Infectious Disease Specialist";
                    break;
                default:
                    doctorType = "Unknown"; 
                    break;
            }

            return new DoctorViewModel()
            {
                Name = doctor.Name,
                Surname = doctor.Surname,
                Email = doctor.Email,
                Phone = doctor.Phone,
                DoctorType = doctorType,
                Experience = doctor.Experience,
                Salary = doctor.Salary
            };
        }

        public static PatientViewModel ConvertTo(this Patient patient)
        {
            if (patient == null)
                return null;

            string illnessType = string.Empty;

            switch (patient.IllnessType)
            {
                case IllnessTypes.EyeDisease:
                    illnessType = "EyeDisease";
                    break;
                case IllnessTypes.Infection:
                    illnessType = "Infection";
                    break;
                case IllnessTypes.DentalDisease:
                    illnessType = "DentalDisease";
                    break;
                case IllnessTypes.SkinDisease:
                    illnessType = "SkinDisease";
                    break;
                default:
                    illnessType = "Unknown";
                    break;
            }

            return new PatientViewModel()
            {
                Name = patient.Name,
                Surname = patient.Surname,
                Email = patient.Email,
                Phone = patient.Phone,
                IllnessType = illnessType,
                AdditionalInfo = patient.AdditionalInfo,
                Address = patient.Address
            };
        }
        public static AppointmentViewModel ConvertTo(this Appointment appointment)
        {
            return new AppointmentViewModel()
            {
                Doctor = appointment.Doctor.Name +" " +appointment.Doctor.Surname,
                Patient = appointment.Patient.Name +" " +appointment.Patient.Surname,
                DateTimeFrom = appointment.DateTimeFrom,
                DateTimeTo = appointment.DateTimeTo,
                Description = appointment.Description
            };
        }
    }
}
