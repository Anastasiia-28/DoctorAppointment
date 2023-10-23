using DoctorAppointment;

namespace MyDoctorAppointment
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var consoleManager = new ConsoleManager();
            consoleManager.Menu();
        }
    }
}