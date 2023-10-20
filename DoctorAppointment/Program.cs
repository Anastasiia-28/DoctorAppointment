using DoctorAppointment.Domain.Entities;
using DoctorAppointment.Domain.Enums;
using DoctorAppointment.Service.Interfaces;
using DoctorAppointment.Service.Services;


namespace MyDoctorAppointment
{
    public class DoctorAppointment 
    {
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;

        public DoctorAppointment()
        {
            _doctorService = new DoctorService();
            _patientService = new PatientService();
        }

        public void Menu()
        {
            //while (true)
            //{
            //    //Add Enum for menu items and describe menu
            //}
            Console.WriteLine("Current doctors list: ");
            var docs = _doctorService.GetAll();

            foreach (var doc in docs)
            {
                Console.WriteLine(doc.Name);
            }

            Console.WriteLine("Adding doctor: ");

            var newDoctor = new Doctor
            {
                Name = "Di",
                Surname = "Gu",
                Experience = 20,
                DoctorType = DoctorTypes.Dermatologist
            };
            _doctorService.Create(newDoctor);

            Console.WriteLine("Current doctors list: ");
            docs = _doctorService.GetAll();

            foreach (var doc in docs)
            {
                Console.WriteLine(doc.Name);
                Console.WriteLine(doc.DoctorType);
            }



            Console.WriteLine("Current patients list: ");
            var pats = _patientService.GetAll();

            foreach (var pat in pats)
            {
                Console.WriteLine(pat.Name);
                Console.WriteLine(pat.IllnessType);
            }

            Console.WriteLine("Adding patient: ");

            var newPatient = new Patient
            {
                Name = "An",
                Surname = "Sh",
                IllnessType = IllnessTypes.SkinDisease
                
            };

            _patientService.Create(newPatient);

            Console.WriteLine("Current patients list: ");
            pats = _patientService.GetAll();

            foreach (var pat in pats)
            {
                Console.WriteLine(pat.Name);
                Console.WriteLine(pat.IllnessType);
            }
        }
    }

    public static class Program
    {
        public static void Main(string[] args)
        {
            var doctorAppointment = new DoctorAppointment();
            doctorAppointment.Menu();
        }
    }
}