using System;

class Program
{
    static void Main(string[] args)
    {
        int[] heltal = { 1, 2, 3 };
        double[] decimaltal = { 1.0, 2.0, 3.0 };
        string[] ord = { "1", "2", "3" };

        // Skriva ut med tre olika metoder
        SkrivUt(heltal);
        SkrivUt(decimaltal);
        SkrivUt(ord);

        // Visa mängden kod
        // Här har vi tre nästan identiska metoder, vilket leder till kodupprepning

        // Om vi behöver ändra utskriftslogiken måste vi ändra på tre ställen

        // Gör en generisk metod
        SkrivUtGenerisk(heltal);
        SkrivUtGenerisk(decimaltal);
        SkrivUtGenerisk(ord);
    }

    public static void SkrivUt(int[] talen)
    {
        foreach (var item in talen)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    public static void SkrivUt(double[] talen)
    {
        foreach (var item in talen)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    public static void SkrivUt(string[] talen)
    {
        foreach (var item in talen)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    // Generisk metod
    public static void SkrivUtGenerisk<T>(T[] talen)
    {
        foreach (var item in talen)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}