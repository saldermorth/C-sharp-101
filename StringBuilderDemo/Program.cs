using System.Diagnostics;
using System.Text;

namespace StringBuilderDemo
{
    internal class Program
    {
       
            static void Main()
            {
                // Grundläggande användning
                StringBuilder sb = new StringBuilder();
                sb.Append("Hej");
                sb.Append(" ");
                sb.Append("världen");
                Console.WriteLine(sb.ToString()); // Skriver ut: Hej världen

                // Initiera med startkapacitet
                StringBuilder sb2 = new StringBuilder(50);

                // Initiera med startvärde
                StringBuilder sb3 = new StringBuilder("Välkommen");

                // AppendLine - lägger till text med radbrytning
                StringBuilder sb4 = new StringBuilder();
                sb4.AppendLine("Första raden");
                sb4.AppendLine("Andra raden");
                sb4.AppendLine("Tredje raden");
                Console.WriteLine(sb4.ToString());

                // Insert - infoga text på specifik position
                StringBuilder sb5 = new StringBuilder("Hej världen");
                sb5.Insert(4, "vackra "); // Position 4 är efter "Hej "
                Console.WriteLine(sb5.ToString()); // Skriver ut: Hej vackra världen

                // Remove - ta bort text
                StringBuilder sb6 = new StringBuilder("Hej på dig världen");
                sb6.Remove(4, 7); // Ta bort "på dig "
                Console.WriteLine(sb6.ToString()); // Skriver ut: Hej världen

                // Replace - ersätt text
                StringBuilder sb7 = new StringBuilder("Hej världen");
                sb7.Replace("världen", "Sverige");
                Console.WriteLine(sb7.ToString()); // Skriver ut: Hej Sverige

                // Clear - töm StringBuilder
                StringBuilder sb8 = new StringBuilder("Något text");
                sb8.Clear();
                sb8.Append("Ny text");
                Console.WriteLine(sb8.ToString()); // Skriver ut: Ny text

                // StringBuilder med formatering
                StringBuilder sb9 = new StringBuilder();
                for (int i = 1; i <= 3; i++)
                {
                    sb9.AppendFormat("Rad {0}: {1}\n", i, i * 10);
                }
                Console.WriteLine(sb9.ToString());

                // Kapacitet och Length
                StringBuilder sb10 = new StringBuilder(20);
                Console.WriteLine($"Kapacitet: {sb10.Capacity}"); // 20
                Console.WriteLine($"Längd: {sb10.Length}"); // 0
                sb10.Append("Test text");
                Console.WriteLine($"Ny längd: {sb10.Length}"); // 9

                // Kedjning av metoder
                StringBuilder sb11 = new StringBuilder()
                    .Append("Hej ")
                    .Append("på ")
                    .Append("dig!")
                    .Replace("dig", "er");
                Console.WriteLine(sb11.ToString()); // Skriver ut: Hej på er!
            }
        }




//class StringVsStringBuilderDemo
//        {
//            static void Main()
//            {
//                const int iterationer = 100000;

//                Console.WriteLine("Jämförelse mellan String och StringBuilder");
//                Console.WriteLine("Antal iterationer: " + iterationer);
//                Console.WriteLine();

//                // Test med String
//                GC.Collect(); // Tvinga skräpinsamling innan testet
//                long stringMemoryBefore = GC.GetTotalMemory(true);
//                long stringStartTime = Stopwatch.GetTimestamp();
//                string stringResult = StringConcatenation(iterationer);
//                long stringEndTime = Stopwatch.GetTimestamp();
//                long stringMemoryAfter = GC.GetTotalMemory(false);

//                // Test med StringBuilder
//                GC.Collect(); // Tvinga skräpinsamling innan testet
//                long sbMemoryBefore = GC.GetTotalMemory(true);
//                long sbStartTime = Stopwatch.GetTimestamp();
//                string sbResult = StringBuilderConcatenation(iterationer);
//                long sbEndTime = Stopwatch.GetTimestamp();
//                long sbMemoryAfter = GC.GetTotalMemory(false);

//                // Beräkna och visa resultat
//                double stringElapsed = (stringEndTime - stringStartTime) / (double)Stopwatch.Frequency * 1_000_000; // Mikrosekunder
//                double sbElapsed = (sbEndTime - sbStartTime) / (double)Stopwatch.Frequency * 1_000_000; // Mikrosekunder
//                long stringMemoryUsed = stringMemoryAfter - stringMemoryBefore;
//                long sbMemoryUsed = sbMemoryAfter - sbMemoryBefore;

//                Console.WriteLine("String:");
//                Console.WriteLine($"Tid: {stringElapsed:F2} mikrosekunder");
//                Console.WriteLine($"Minnesanvändning: {stringMemoryUsed:N0} bytes");
//                Console.WriteLine($"Resultatets längd: {stringResult.Length}");
//                Console.WriteLine();

//                Console.WriteLine("StringBuilder:");
//                Console.WriteLine($"Tid: {sbElapsed:F2} mikrosekunder");
//                Console.WriteLine($"Minnesanvändning: {sbMemoryUsed:N0} bytes");
//                Console.WriteLine($"Resultatets längd: {sbResult.Length}");
//                Console.WriteLine();

//                // Jämförelse
//                double speedDifference = stringElapsed / sbElapsed;
//                double memoryDifference = (double)stringMemoryUsed / sbMemoryUsed;
//                Console.WriteLine($"StringBuilder är ca {speedDifference:F2} gånger snabbare än String i detta test.");
//                Console.WriteLine($"String använder ca {memoryDifference:F2} gånger mer minne än StringBuilder i detta test.");
//            }

//            static string StringConcatenation(int iterations)
//            {
//                string result = "";
//                for (int i = 0; i < iterations; i++)
//                {
//                    result += "a";
//                }
//                return result;
//            }

//            static string StringBuilderConcatenation(int iterations)
//            {
//                StringBuilder sb = new StringBuilder();
//                for (int i = 0; i < iterations; i++)
//                {
//                    sb.Append("a");
//                }
//                return sb.ToString();
//            }
//        }

//    }
}

