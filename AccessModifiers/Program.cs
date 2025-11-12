using System;

// Bas-klass
public class Fordon
{
    // PUBLIC – synlig överallt
    public string publicFalt = "Public fält";
    public void PublicMetod() => Console.WriteLine("Public metod – synlig överallt");

    // PRIVATE – endast inom denna klass
    private string privateFalt = "Private fält";
    private void PrivateMetod() => Console.WriteLine("Private metod – endast i klassen");

    // PROTECTED – synlig i denna klass och i subklasser
    protected string protectedFalt = "Protected fält";
    protected void ProtectedMetod() => Console.WriteLine("Protected metod – i subklass");

    // INTERNAL – synlig inom samma assembly (projekt)
    internal string internalFalt = "Internal fält";
    internal void InternalMetod() => Console.WriteLine("Internal metod – inom projektet");

    // PROTECTED INTERNAL – synlig inom samma assembly eller i subklasser i andra assemblies
    protected internal string protectedInternalFalt = "Protected Internal fält";
    protected internal void ProtectedInternalMetod() => Console.WriteLine("Protected Internal metod – inom asm eller subklass");

    // PRIVATE PROTECTED – synlig endast i subklasser inom samma assembly
    private protected string privateProtectedFalt = "Private Protected fält";
    private protected void PrivateProtectedMetod() => Console.WriteLine("Private Protected metod – i subklass inom samma asm");

    // Testmetod för att visa interna anrop
    public void TestInomKlassen()
    {
        Console.WriteLine(privateFalt);
        PrivateMetod(); // Tillåtet – inom samma klass
    }
}

// Subklass som ärver Fordon
public class Bil : Fordon
{
    public void TestaÅtkomst()
    {
        // PUBLIC – fungerar
        Console.WriteLine(publicFalt);
        PublicMetod();

        // PROTECTED – fungerar i subklass
        Console.WriteLine(protectedFalt);
        ProtectedMetod();

        // INTERNAL – fungerar (samma assembly)
        Console.WriteLine(internalFalt);
        InternalMetod();

        // PROTECTED INTERNAL – fungerar (samma assembly + subklass)
        Console.WriteLine(protectedInternalFalt);
        ProtectedInternalMetod();

        // PRIVATE PROTECTED – fungerar (subklass inom samma assembly)
        Console.WriteLine(privateProtectedFalt);
        PrivateProtectedMetod();

        // PRIVATE – fungerar inte (endast inom bas-klassen)
        // Console.WriteLine(privateFalt);        // FEL
        // PrivateMetod();                         // FEL
    }
}

// Klass i samma assembly (ej subklass)
public class Verkstad
{
    public void Testa()
    {
        var bil = new Bil();

        // PUBLIC – fungerar
        Console.WriteLine(bil.publicFalt);
        bil.PublicMetod();

        // INTERNAL – fungerar (inom samma projekt)
        Console.WriteLine(bil.internalFalt);
        bil.InternalMetod();

        // PROTECTED INTERNAL – fungerar (inom samma projekt)
        Console.WriteLine(bil.protectedInternalFalt);
        bil.ProtectedInternalMetod();

        // PROTECTED, PRIVATE, PRIVATE PROTECTED – fungerar inte
        // Console.WriteLine(bil.protectedFalt);        // FEL
        // bil.ProtectedMetod();                        // FEL
        // Console.WriteLine(bil.privateProtectedFalt); // FEL
        // bil.PrivateProtectedMetod();                 // FEL
        // Console.WriteLine(bil.privateFalt);          // FEL
        // bil.PrivateMetod();                          // FEL
    }
}

// Huvudprogram
public class Program
{
    public static void Main()
    {
        var bil = new Bil();
        bil.TestaÅtkomst();

        var verkstad = new Verkstad();
        verkstad.Testa();

        Console.WriteLine("Klart!");
    }
}
