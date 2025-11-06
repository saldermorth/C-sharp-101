using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqDemo
{
    class Kund
    {
        public string Namn { get; set; }
        public bool Aktiv { get; set; }
        public double KöpTotalt { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var kunder = new List<Kund>
            {
                new Kund { Namn = "Anna", Aktiv = true, KöpTotalt = 1500 },
                new Kund { Namn = "Anders", Aktiv = false, KöpTotalt = 800 },
                new Kund { Namn = "Ali", Aktiv = true, KöpTotalt = 2200 },
                new Kund { Namn = "Bertil", Aktiv = true, KöpTotalt = 500 }
            };

            var aktivaKunder = kunder
                .Where(k => k.Aktiv && k.Namn.StartsWith("A"))
                .Select(k => new
                {
                    k.Namn,
                    Rabatt = BeräknaRabatt(k.KöpTotalt)
                });

            Console.WriteLine("Aktiva kunder vars namn börjar med 'A':");
            foreach (var kund in aktivaKunder)
            {
                Console.WriteLine($"{kund.Namn} - Rabatt: {kund.Rabatt} kr");
            }
        }

        static double BeräknaRabatt(double köpTotalt)
        {
            // Enkel logik för rabattberäkning
            if (köpTotalt > 2000)
                return 200;
            else if (köpTotalt > 1000)
                return 100;
            else
                return 0;
        }
    }
}
