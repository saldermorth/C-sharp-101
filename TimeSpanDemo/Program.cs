namespace TimeSpanDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime start = new DateTime(2024, 1, 1);
            DateTime slut = new DateTime(2024, 12, 31);
            TimeSpan skillnad = slut - start;

            Console.WriteLine($"Antal dagar mellan datumen: {skillnad.Days}");

            DateTime nu = DateTime.Now;
            TimeSpan treTimmar = TimeSpan.FromHours(3);

            DateTime framtid = nu + treTimmar;
            DateTime dåtid = nu - treTimmar;

            Console.WriteLine($"Om tre timmar: {framtid}");
            Console.WriteLine($"För tre timmar sedan: {dåtid}");

            DateTime startTid = DateTime.Now;
            TimeSpan intervall = TimeSpan.FromMinutes(30);

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Möte {i + 1}: {startTid + intervall * i}");
            }


            // Skapa TimeSpan-objekt
            TimeSpan ts1 = new TimeSpan(2, 30, 0); // 2 timmar och 30 minuter
            TimeSpan ts2 = TimeSpan.FromHours(3.5); // 3 timmar och 30 minuter

            // Addera TimeSpans
            TimeSpan summa = ts1 + ts2;
            Console.WriteLine($"Summa: {summa}");

            // Subtrahera TimeSpans
            TimeSpan skillnaden = ts2 - ts1;
            Console.WriteLine($"Skillnad: {skillnaden}");

            // Jämföra TimeSpans
            if (ts1 < ts2)
            {
                Console.WriteLine("ts1 är kortare än ts2");
            }

            // Hämta totalt antal dagar, timmar, minuter, sekunder
            TimeSpan enVecka = TimeSpan.FromDays(7);
            Console.WriteLine($"En vecka är {enVecka.TotalHours} timmar");
            Console.WriteLine($"En vecka är {enVecka.TotalMinutes} minuter");

            // Formatera TimeSpan
            Console.WriteLine($"Formaterad: {ts1:hh\\:mm}");

            // Lägga till TimeSpan till DateTime
            DateTime now = DateTime.Now;
            DateTime future = now + ts1;
            Console.WriteLine($"Aktuell tid plus 2,5 timmar: {future}");

        }
    }
}
