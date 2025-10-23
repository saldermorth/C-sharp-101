namespace TuplesDemo
{
    internal class Program
    {

        static void Main()
        {
            // Exempel 1: Skapa och använda en enkel tupel
            var person = ("Anna", 30);
            Console.WriteLine($"Namn: {person.Item1}, Ålder: {person.Item2}");

            // Exempel 2: Tupel med namngivna element
            var bok = (Titel: "C# i praktiken", Författare: "John Doe", År: 2024);
            Console.WriteLine($"Bok: {bok.Titel} av {bok.Författare}, utgiven {bok.År}");

            // Exempel 3: Metod som returnerar en tupel
            var statistik = BeräknaStatistik(new List<int> { 1, 2, 3, 4, 5 });
            Console.WriteLine($"Min: {statistik.Min}, Max: {statistik.Max}, Medel: {statistik.Medel}");

            // Exempel 4: Tupel-dekomposition
            var (namn, ålder) = person;
            Console.WriteLine($"Dekomponerad: Namn = {namn}, Ålder = {ålder}");

            // Exempel 5: Använda tupler i LINQ
            var personer = new List<(string Namn, int Ålder)>
        {
            ("Erik", 25),
            ("Maria", 30),
            ("Anders", 22)
        };

            var äldstaPerson = personer.OrderByDescending(p => p.Ålder).First();
            Console.WriteLine($"Äldsta personen: {äldstaPerson.Namn}, {äldstaPerson.Ålder} år");
        }

        static (int Min, int Max, double Medel) BeräknaStatistik(List<int> numbers)
        {
            return (
                numbers.Min(),
                numbers.Max(),
                numbers.Average()
            );
        }
    }


}
