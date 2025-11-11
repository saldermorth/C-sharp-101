// ÖVNING: TYNGDLYFTARE-KLASS MED OPERATOR OVERLOAD

/* 
 * Skapa en klass Weightlifter som representerar en tyngdlyftare.
 * Klassen ska innehålla egenskaper för namn, vikt och personligt rekord (PR) i kg.
 * 
 * Implementera följande operatoröverlagringar:
 * 1. > och < för att jämföra tyngdlyftare baserat på deras personliga rekord
 * 2. + för att kombinera två tyngdlyftare till ett "lyftarteam" 
 *    där det nya teamets PR är summan av de individuella rekorden
 * 
 * Tips:
 * - Använd en egenskap PersonalRecord för tyngdlyftarens personliga rekord
 * - För +-operatorn, skapa en ny Weightlifter som representerar "teamet"
 * - När du skapar teamet, kombinera namnen från de två lyftarna
 */

// KODEXEMPEL:

using System;

namespace WeightlifterDemo
{
    public class Weightlifter
    {
        public string Name { get; private set; }
        public double Weight { get; private set; }        // Vikt i kg
        public double PersonalRecord { get; private set; } // Personligt rekord i kg

        // Konstruktor
        public Weightlifter(string name, double weight, double personalRecord)
        {
            Name = name;
            Weight = weight;
            PersonalRecord = personalRecord;
        }

        // TODO: Implementera operator > 

        // TODO: Implementera operator 

        // TODO: Implementera operator +

        // Override ToString för snyggare utskrift
        public override string ToString()
        {
            return $"{Name} ({Weight} kg) - PR: {PersonalRecord} kg";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Skapa några tyngdlyftare
            Weightlifter anna = new Weightlifter("Anna", 65, 120);
            Weightlifter erik = new Weightlifter("Erik", 85, 150);
            Weightlifter maria = new Weightlifter("Maria", 70, 135);

            // Skriv ut information om lyftarna
            Console.WriteLine(anna);
            Console.WriteLine(erik);
            Console.WriteLine(maria);
            Console.WriteLine();

            // Jämför lyftare
            Console.WriteLine($"Är {erik.Name} starkare än {anna.Name}? {erik > anna}");
            Console.WriteLine($"Är {maria.Name} starkare än {erik.Name}? {maria > erik}");
            Console.WriteLine();

            // Skapa ett lyftarteam
            Weightlifter team = anna + erik;
            Console.WriteLine($"Nytt team: {team}");
        }
    }
}

/* FÖRVÄNTAT RESULTAT:
Anna (65 kg) - PR: 120 kg
Erik (85 kg) - PR: 150 kg
Maria (70 kg) - PR: 135 kg

Är Erik starkare än Anna? True
Är Maria starkare än Erik? False

Nytt team: Anna & Erik (150 kg) - PR: 270 kg
*/