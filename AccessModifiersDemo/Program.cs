using System;

namespace DemoÅtkomst
{
    // ------------------------------
    // PUBLIC – Synlig överallt
    // ------------------------------
    public class PublicBil
    {
        public void Starta() => Console.WriteLine("PublicBil: Bilen startar (public)");
    }

    // ------------------------------
    // PRIVATE – Endast inom samma klass
    // ------------------------------
    public class PrivateBil
    {
        private void Starta() => Console.WriteLine("PrivateBil: Bilen startar (private)");
        public void Test()
        {
            Starta(); // Fungerar – inom samma klass
        }
    }

    // ------------------------------
    // PROTECTED – Synlig i klassen och i subklasser
    // ------------------------------
    public class Fordon
    {
        protected void Kör() => Console.WriteLine("Fordon: Kör fordonet (protected)");
    }

    public class Bil : Fordon
    {
        public void Test()
        {
            Kör(); // Fungerar – inom subklass
        }
    }

    // ------------------------------
    // INTERNAL – Synlig inom samma assembly (projekt)
    // ------------------------------
    internal class InternalBil
    {
        internal void Starta() => Console.WriteLine("InternalBil: Bilen startar (internal)");
    }

    // ------------------------------
    // PROTECTED INTERNAL – Synlig inom samma assembly eller i subklasser i andra assemblies
    // ------------------------------
    public class ProtectedInternalFordon
    {
        protected internal void Kör() => Console.WriteLine("ProtectedInternalFordon: Kör (protected internal)");
    }

    public class ProtectedInternalBil : ProtectedInternalFordon
    {
        public void Test()
        {
            Kör(); // Fungerar – subklass
        }
    }

    // ------------------------------
    // PRIVATE PROTECTED – Endast i subklasser inom samma assembly
    // ------------------------------
    public class PrivateProtectedFordon
    {
        private protected void Kör() => Console.WriteLine("PrivateProtectedFordon: Kör (private protected)");
    }

    public class PrivateProtectedBil : PrivateProtectedFordon
    {
        public void Test()
        {
            Kör(); // Fungerar – subklass i samma assembly
        }
    }

    // ------------------------------
    // HUVUDPROGRAM
    // ------------------------------
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("--- PUBLIC ---");
            var publicBil = new PublicBil();
            publicBil.Starta(); // Fungerar överallt

            Console.WriteLine("\n--- PRIVATE ---");
            var privateBil = new PrivateBil();
            privateBil.Test(); // Fungerar via publik metod
            // privateBil.Starta(); // FEL – private

            Console.WriteLine("\n--- PROTECTED ---");
            var bil = new Bil();
            bil.Test(); // Fungerar i subklass

            Console.WriteLine("\n--- INTERNAL ---");
            var internalBil = new InternalBil();
            internalBil.Starta(); // Fungerar – samma assembly

            Console.WriteLine("\n--- PROTECTED INTERNAL ---");
            var pibil = new ProtectedInternalBil();
            pibil.Test(); // Fungerar – subklass i samma assembly

            Console.WriteLine("\n--- PRIVATE PROTECTED ---");
            var ppbil = new PrivateProtectedBil();
            ppbil.Test(); // Fungerar – subklass inom samma assembly

            Console.WriteLine("\nDemo klar.");
        }
    }
}
