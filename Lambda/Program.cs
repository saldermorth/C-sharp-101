
using System;


class Program

{

    static void Main()

    {

        // === Lambda-exempel med både var och Func ===


        // 1) En lambda som dubblar ett tal (typen anges tydligt)

        Func<int, int> doubleIt = x => x * 2;

        int doubled = doubleIt(5);

        Console.WriteLine($"Dubblat: {doubled}");


        // 2) En lambda som kollar om ett tal är positivt (typ infererad med var)

        var isPositive = (int n) => n > 0;

        bool check1 = isPositive(3);

        bool check2 = isPositive(-1);

        Console.WriteLine($"Är 3 positivt? {check1}");

        Console.WriteLine($"Är -1 positivt? {check2}");


        // 3) En lambda som gör en sträng till versaler (tydlig typ med Func)

        Func<string, string> toUpper = s => s.ToUpper();

        string resultUpper = toUpper("hej");

        Console.WriteLine($"Versaler: {resultUpper}");


        // 4) En lambda som räknar tecken (var + tydlig parameter)

        var countChars = (string s) => s.Length;

        int length = countChars("Lambda");

        Console.WriteLine($"Antal tecken: {length}");


        // 5) En lambda som kombinerar två strängar (Func med två parametrar)

        Func<string, string, string> concat = (a, b) => a + " " + b;

        string combined = concat("Hej", "världen");

        Console.WriteLine($"Kombinerat: {combined}");

        // 6) Några matematiska lambda-uttryck utan Func<>

        var add = (double a, double b) => a + b;

        var subtract = (double a, double b) => a - b;

        var multiply = (double a, double b) => a * b;

        var divide = (double a, double b) => b != 0 ? a / b : double.NaN;

        var power = (double x, double y) => Math.Pow(x, y);

        var sqrt = (double x) => Math.Sqrt(x);


        Console.WriteLine("\n--- Matematiska exempel ---");

        Console.WriteLine($"Addition: {add(3, 4)}");

        Console.WriteLine($"Subtraktion: {subtract(10, 5)}");

        Console.WriteLine($"Multiplikation: {multiply(2, 6)}");

        Console.WriteLine($"Division: {divide(12, 4)}");

        Console.WriteLine($"Potens: {power(2, 3)}");

        Console.WriteLine($"Kvadratrot: {sqrt(9)}");


        // 7) Samma lambdas med färdiga variabler

        Console.WriteLine("\n--- Exempel med färdiga variabler ---");

        double num1 = 8;

        double num2 = 3;

        string word1 = "lambda";

        string word2 = "uttryck";


        var addera = () => num1 + num2;


        Console.WriteLine($"Add: {add(num1, num2)}");

        Console.WriteLine($"Subtract: {subtract(num1, num2)}");

        Console.WriteLine($"Multiply: {multiply(num1, num2)}");

        Console.WriteLine($"Divide: {divide(num1, num2)}");

        Console.WriteLine($"Power: {power(num1, num2)}");

        Console.WriteLine($"Kvadratrot av {num1}: {sqrt(num1)}");


        Console.WriteLine($"Versaler: {toUpper(word1)}");

        Console.WriteLine($"Antal tecken i '{word2}': {countChars(word2)}");

        Console.WriteLine($"Kombinerad text: {concat(word1, word2)}");

    }

}



