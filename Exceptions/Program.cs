using System;
using System.IO;

class ExceptionDemo
{
    static void Main()
    {
        Console.WriteLine("Demonstration av Vanliga Undantag\n");

        int noll = 0;
        Console.WriteLine("1. DivideByZeroException");
        //Ohanterat fel. Här kommer prgrammet att avslutas
       // int resultatet = 10 / noll;

        // 1. DivideByZeroException
        try
        {
            int zero = 0;
            Console.WriteLine("1. DivideByZeroException");
            int resultat = 10 / zero;
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine( ex);
            Console.WriteLine($"Meddelande: {ex.Message}\n");
        }

        // 2. IndexOutOfRangeException
        try
        {
            Console.WriteLine("2. IndexOutOfRangeException");
            int[] arr = new int[3];
            int value = arr[5]; // Detta kommer att kasta IndexOutOfRangeException
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine($"Fångad: {ex.GetType().Name}");
            Console.WriteLine($"Meddelande: {ex.Message}\n");
        }

        // 3. FileNotFoundException
        try
        {
            Console.WriteLine("3. FileNotFoundException");
            string innehåll = File.ReadAllText("icke_existerande_fil.txt");
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"Fångad: {ex.GetType().Name}");
            Console.WriteLine($"Meddelande: {ex.Message}\n");
        }

        // 4a FormatException
        try
        {
            Console.WriteLine("4a FormatException");
            int tal = int.Parse("inte_ett_tal");
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Fångad: {ex.GetType().Name}");
            Console.WriteLine($"Meddelande: {ex.Message}\n");
        }

        // 4b Try Parse fail
        Console.WriteLine("4b Try Parse fail");
        var lyckats = int.TryParse("inte_ett_tal", out int result);
        if (lyckats)
        {
            Console.WriteLine(result);
        }
        else
        {
            Console.WriteLine("Fail to parse\n");
        }

        // 4c Try Parse success
        Console.WriteLine(" 4c Try Parse success");
        var lyckatsTvå = int.TryParse("100", out int lyckatsResultat);
        if (lyckatsTvå)
        {
            Console.WriteLine("Lyckats parsa : " + lyckatsResultat + "\n");
        }

        // 5. NullReferenceException
        try
        {
            Console.WriteLine("5. NullReferenceException");
            string nullString = null;
            int längd = nullString.Length;
        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine($"Fångad: {ex.GetType().Name}");
            Console.WriteLine($"Meddelande: {ex.Message}\n");
        }

        Console.WriteLine("Tryck på en tangent för att avsluta.");
        Console.ReadKey();
    }
}


