using System.Globalization;

namespace DateTimeDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Aktuellt datum och tid
            DateTime nu = DateTime.Now;
            Console.WriteLine("Aktuellt datum och tid (oformaterat): " + nu);

            // Formatering av datum
            string formateratDatum = nu.ToString("dddd, d MMMM yyyy HH:mm:ss");
            Console.WriteLine("Formaterat datum: " + formateratDatum);

            // Lägga till tid
            DateTime framtidaDatum = nu.AddDays(7).AddHours(3);
            Console.WriteLine("Datum 7 dagar och 3 timmar från nu: " + framtidaDatum);

            // Skillnad mellan datum
            DateTime datum1 = new DateTime(2024, 7, 22);
            DateTime datum2 = new DateTime(2024, 8, 15);
            TimeSpan skillnad = datum2 - datum1;
            Console.WriteLine("Dagar mellan datum: " + skillnad.Days);

            // Analysera datumsträng
            string datumSträng = "2024-07-22 14:30:00";
            DateTime analyseratDatum = DateTime.ParseExact(datumSträng, "yyyy-MM-dd HH:mm:ss", null);
            Console.WriteLine("Analyserat datum: " + analyseratDatum);


            CultureInfo svenskKultur = new CultureInfo("sv-SE");
            CultureInfo amerikanskKultur = new CultureInfo("en-US");

            DateTime now = DateTime.Now;
            Console.WriteLine(now.ToString(svenskKultur)); // t.ex. 2024-07-22 14:30:00
            Console.WriteLine(now.ToString(amerikanskKultur)); // t.ex. 7/22/2024 2:30:00 PM

            DateTime datum = new DateTime(2024, 7, 22);
            Console.WriteLine(datum.ToString("d", svenskKultur)); // 2024-07-22
            Console.WriteLine(datum.ToString("d", amerikanskKultur)); // 7/22/2024

            Console.WriteLine(svenskKultur.DateTimeFormat.FirstDayOfWeek); // Monday
            Console.WriteLine(amerikanskKultur.DateTimeFormat.FirstDayOfWeek); // Sunday

        }
    }
}
