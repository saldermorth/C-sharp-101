using System;

namespace DemoÅtkomst
{
    // -------------------------------
    // BASKLASS – Person
    // -------------------------------
    public class Person
    {
        public void PublicMetod()
        {
            Console.WriteLine("PublicMetod: synlig överallt");
        }

        private void PrivateMetod()
        {
            Console.WriteLine("PrivateMetod: endast inom Person");
        }

        protected void ProtectedMetod()
        {
            Console.WriteLine("ProtectedMetod: synlig i Person och subklasser");
        }

        internal void InternalMetod()
        {
            Console.WriteLine("InternalMetod: synlig inom samma projekt (assembly)");
        }

        // En metod i samma klass som testar de privata
        public void TestInomKlass()
        {
            Console.WriteLine("TestInomKlass kör alla tillgängliga metoder i Person:");
            PublicMetod();
            PrivateMetod();
            ProtectedMetod();
            InternalMetod();
        }
    }

    // -------------------------------
    // SUBKLASS – Student
    // -------------------------------
    public class Student : Person
    {
        public void TestÅtkomst()
        {
            Console.WriteLine("\nTest från Student (subklass):");

            PublicMetod();    // Fungerar – public
            ProtectedMetod(); // Fungerar – protected
            InternalMetod();  // Fungerar – samma assembly

            // PrivateMetod();  // FEL – kan inte nås i subklass
        }
    }

    // -------------------------------
    // ANNAN KLASS – Skola
    // -------------------------------
    public class Skola
    {
        public void TestÅtkomst()
        {
            Console.WriteLine("\nTest från Skola (ej subklass):");
            var person = new Person();

            person.PublicMetod();   // Fungerar – public
            person.InternalMetod(); // Fungerar – samma assembly

            // person.ProtectedMetod(); // FEL – ej subklass
            // person.PrivateMetod();   // FEL – endast i Person
        }
    }

    // -------------------------------
    // HUVUDPROGRAM
    // -------------------------------
    public class Program
    {
        public static void Main()
        {
            var person = new Person();
            person.TestInomKlass();

            var student = new Student();
            student.TestÅtkomst();

            var skola = new Skola();
            skola.TestÅtkomst();

            Console.WriteLine("\nÖvning klar – jämför vilka som fungerade!");
        }
    }
}
