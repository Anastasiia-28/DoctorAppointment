using DoctorAppointment.Domain.Entities;
using DoctorAppointment.Domain.Enums;
using DoctorAppointment.Service.Interfaces;
using DoctorAppointment.Service.Services;
using DoctorAppointment.Service.ViewModels;
using System.Text;

namespace DoctorAppointment
{
    public class ConsoleManager
    {
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;
        private readonly IAppointmentService _appointmentService;

        public ConsoleManager()
        {
            _doctorService = new DoctorService();
            _patientService = new PatientService();
            _appointmentService = new AppointmentService();
        }

        public void Menu()
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("Отримати дані про лікарів/пацієнтів/записи? - натисніть R/r");
                Console.WriteLine("Записати дані про лікарів/пацієнтів/записи? - натисніть W/w");
                Console.WriteLine("Вийти - натисніть x/X");

                var input = Console.ReadLine();

                if (input == "x" || input == "X")
                    Environment.Exit(0);

                if (input == "r" || input == "R")
                {
                    var enteredData = CheckInput();

                    if (enteredData.Item1 == "1")
                    {
                        if (enteredData.Item2 == "1")
                            ShowDoctors(_doctorService.GetAll());

                        if (enteredData.Item2 == "2")
                            ShowPatients(_patientService.GetAll());

                        if (enteredData.Item2 == "3")
                            ShowAppointments(_appointmentService.GetAll());
                    }
                    else if (enteredData.Item1 == "2")
                    {
                        if (enteredData.Item2 == "1")
                            ShowDoctors(_doctorService.GetFromXml());

                        if (enteredData.Item2 == "2")
                            ShowPatients(_patientService.GetFromXml());

                        if (enteredData.Item2 == "3")
                            ShowAppointments(_appointmentService.GetFromXml());
                    }
                }
                else if (input == "w" || input == "W")
                {
                    var enteredData = CheckInput();

                    if (enteredData.Item1 == "1")
                    {
                        if (enteredData.Item2 == "1")
                            _doctorService.CreateToJson(CreateDoctor());

                        if (enteredData.Item2 == "2")
                            _patientService.CreateToJson(CreatePatient());

                        if (enteredData.Item2 == "3")
                            _appointmentService.CreateToJson(CreateAppointment());
                    }
                    else if (enteredData.Item1 == "2")
                    {
                        if (enteredData.Item2 == "1")
                            _doctorService.CreateToXml(CreateDoctor());

                        if (enteredData.Item2 == "2")
                            _patientService.CreateToXml(CreatePatient());

                        if (enteredData.Item2 == "3")
                            _appointmentService.CreateToXml(CreateAppointment());
                    }
                }
                else
                    Console.WriteLine("Невірно введені дані, спробуйте ще раз.\n");
            }
        }

        private void ShowPatients(IEnumerable<PatientViewModel> patients)
        {
            foreach (var patient in patients)
            {
                Console.WriteLine($"Пацієнт: {patient.Name}\n{patient.Surname}\nПошта: {patient.Email}\nТелефон: {patient.Phone}\nЗахворювання: {patient.IllnessType}");
                Console.WriteLine("____________");
            }
        }

        private void ShowDoctors(IEnumerable<DoctorViewModel> doctors)
        {
            foreach (var doctor in doctors)
            {
                Console.WriteLine($"Лікар: {doctor.DoctorType}\n{doctor.Name}\n{doctor.Surname}\nПошта: {doctor.Email}\nТелефон: {doctor.Phone}\nДосвід: {doctor.Experience}\nЗП: {doctor.Salary}");
                Console.WriteLine("____________");
            }
        }

        private void ShowAppointments(IEnumerable<AppointmentViewModel> appointments)
        {
            foreach (var appointment in appointments)
            {
                Console.WriteLine($"Лікар: {appointment.Doctor}\nПацієнт: {appointment.Patient}\nОпис: {appointment.Description}\nТривалість з: {appointment.DateTimeFrom}\nдо: {appointment.DateTimeTo}");
                Console.WriteLine("____________");
            }
        }

        private (string, string) CheckInput()
        {
            string choiceFormat = "";
            string choiceAbout = "";
            bool fl = true;

            while (fl)
            {
                Console.WriteLine("Робота з файлами формату .json - натисніть 1, .xml - натисніть 2");
                choiceFormat = Console.ReadLine();

                if (choiceFormat != "1" && choiceFormat != "2")
                    Console.WriteLine("Невірно введені дані, спробуйте ще раз.\n");
                else
                    fl = false;
            }

            fl = true;

            while (fl)
            {
                Console.WriteLine("Інформація про лікарів - натисніть 1, про пацієнтів - натисніть 2, про записи - натисніть 3");
                choiceAbout = Console.ReadLine();

                if (choiceAbout != "1" && choiceAbout != "2" && choiceAbout != "3")
                    Console.WriteLine("Невірно введені дані, спробуйте ще раз.\n");
                else
                    fl = false;
            }

            return (choiceFormat, choiceAbout);
        }

        private Doctor CreateDoctor()
        {
            var newDoctor = new Doctor();

            Console.WriteLine("Введіть ім'я лікаря: ");
            newDoctor.Name = Console.ReadLine();

            Console.WriteLine("Введіть прізвище лікаря: ");
            newDoctor.Surname = Console.ReadLine();

            Console.WriteLine("Посада (дантист - натисніть 1, дерматолог - 2, інфекціоніст - 3, офтальмолог - 4): ");
            var type = Console.ReadLine();

            switch (type)
            {
                case "1":
                    newDoctor.DoctorType = DoctorTypes.Dentist;
                    break;
                case "2":
                    newDoctor.DoctorType = DoctorTypes.Dermatologist;
                    break;
                case "3":
                    newDoctor.DoctorType = DoctorTypes.InfectiousDiseaseSpecialist;
                    break;
                case "4":
                    newDoctor.DoctorType = DoctorTypes.Ophthalmologist;
                    break;
            }

            Console.WriteLine("Пошта: ");
            newDoctor.Email = Console.ReadLine();

            Console.WriteLine("Телефон: ");
            newDoctor.Phone = Console.ReadLine();

            Console.WriteLine("Досвід роботи (кількість років): ");
            newDoctor.Experience = Convert.ToByte(Console.ReadLine());

            Console.WriteLine("Заробітна плата: ");
            newDoctor.Salary = Convert.ToDecimal(Console.ReadLine());

            return newDoctor;
        }

        private Patient CreatePatient()
        {
            var newPatient = new Patient();

            Console.WriteLine("Введіть ім'я пацієнта: ");
            newPatient.Name = Console.ReadLine();

            Console.WriteLine("Введіть прізвище пацієнта: ");
            newPatient.Surname = Console.ReadLine();

            Console.WriteLine("Хвороба (хвороба очей - натисніть 1, стоматологічна хвороба - 2, проблеми зі шкірою - 3, інфекція - 4): ");
            var type = Console.ReadLine();

            switch (type)
            {
                case "1":
                    newPatient.IllnessType = IllnessTypes.EyeDisease;
                    break;
                case "2":
                    newPatient.IllnessType = IllnessTypes.DentalDisease;
                    break;
                case "3":
                    newPatient.IllnessType = IllnessTypes.SkinDisease;
                    break;
                case "4":
                    newPatient.IllnessType = IllnessTypes.Infection;
                    break;
            }

            Console.WriteLine("Пошта: ");
            newPatient.Email = Console.ReadLine();

            Console.WriteLine("Телефон: ");
            newPatient.Phone = Console.ReadLine();

            Console.WriteLine("Адреса: ");
            newPatient.Address = Console.ReadLine();

            Console.WriteLine("Додаткова інформація: ");
            newPatient.AdditionalInfo = Console.ReadLine();

            return newPatient;
        }

        private Appointment CreateAppointment()
        {
            var newAppointment = new Appointment();

            newAppointment.Doctor = CreateDoctor();
            newAppointment.Patient = CreatePatient();

            Console.WriteLine("Опис запису: ");
            newAppointment.Description = Console.ReadLine();

            Console.WriteLine("Від (у форматі 'дд.мм.рррр 00:00:00'): ");
            var from = Console.ReadLine();
            DateTime dtFrom;
            DateTime.TryParse(from, out dtFrom);
            newAppointment.DateTimeFrom = dtFrom;

            Console.WriteLine("До (у форматі 'дд.мм.рррр 00:00:00'): ");
            DateTime dtTo;
            var to = Console.ReadLine();
            DateTime.TryParse(to, out dtTo);
            newAppointment.DateTimeTo = dtTo;

            return newAppointment;
        }
    }
}
