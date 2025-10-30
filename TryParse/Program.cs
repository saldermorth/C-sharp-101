namespace TryParse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TryParse Demo i C#");
            Console.WriteLine("==================");
            Console.WriteLine();

            // Exempel 1: Grundläggande int.TryParse
            BasicIntTryParse();

            // Exempel 2: TryParse med flera datatyper
            MultipleDataTypesTryParse();

            // Exempel 3: Jämförelse med Parse och try-catch
            CompareWithParse();

            // Exempel 4: Praktiskt exempel - Inmatningsvalidering
            ValidateUserInput();

            Console.WriteLine("\nTryck på en tangent för att avsluta...");
            Console.ReadKey();
        }

        static void BasicIntTryParse()
        {
            Console.WriteLine("Exempel 1: Grundläggande int.TryParse");
            Console.WriteLine("----------------------------------");

            // Giltiga värden
            string validInput = "123";
            int validResult;

            bool success = int.TryParse(validInput, out validResult);
            Console.WriteLine($"Inmatning: \"{validInput}\"");
            Console.WriteLine($"Konvertering lyckades: {success}");
            Console.WriteLine($"Resultat: {validResult}");

            // Ogiltiga värden
            string invalidInput = "abc";
            int invalidResult;

            success = int.TryParse(invalidInput, out invalidResult);
            Console.WriteLine($"\nInmatning: \"{invalidInput}\"");
            Console.WriteLine($"Konvertering lyckades: {success}");
            Console.WriteLine($"Resultat: {invalidResult} (standardvärdet för int)");

            Console.WriteLine();
        }

        static void MultipleDataTypesTryParse()
        {
            Console.WriteLine("Exempel 2: TryParse med flera datatyper");
            Console.WriteLine("-------------------------------------");

            // Double
            string doubleInput = "123.45";
            double doubleResult;
            bool success = double.TryParse(doubleInput, out doubleResult);
            Console.WriteLine($"double.TryParse(\"{doubleInput}\"): {success}, Resultat: {doubleResult}");

            // Decimal
            string decimalInput = "9999.99";
            decimal decimalResult;
            success = decimal.TryParse(decimalInput, out decimalResult);
            Console.WriteLine($"decimal.TryParse(\"{decimalInput}\"): {success}, Resultat: {decimalResult}");

            // DateTime
            string dateInput = "2025-10-30";
            DateTime dateResult;
            success = DateTime.TryParse(dateInput, out dateResult);
            Console.WriteLine($"DateTime.TryParse(\"{dateInput}\"): {success}, Resultat: {dateResult.ToShortDateString()}");

            // Guid
            string guidInput = "f47ac10b-58cc-4372-a567-0e02b2c3d479";
            Guid guidResult;
            success = Guid.TryParse(guidInput, out guidResult);
            Console.WriteLine($"Guid.TryParse(\"{guidInput}\"): {success}, Resultat: {guidResult}");

            // Boolean
            string boolInput = "true";
            bool boolResult;
            success = bool.TryParse(boolInput, out boolResult);
            Console.WriteLine($"bool.TryParse(\"{boolInput}\"): {success}, Resultat: {boolResult}");

            Console.WriteLine();
        }

        static void CompareWithParse()
        {
            Console.WriteLine("Exempel 3: Jämförelse med Parse och try-catch");
            Console.WriteLine("-------------------------------------------");

            string input = "abc";

            // Metod 1: Parse med try-catch
            Console.WriteLine("Metod 1: Parse med try-catch");
            try
            {
                int result = int.Parse(input);
                Console.WriteLine($"Resultat: {result}");
            }
            catch (FormatException)
            {
                Console.WriteLine("FormatException: Kunde inte konvertera strängen till en int");
            }
            catch (OverflowException)
            {
                Console.WriteLine("OverflowException: Värdet är för stort eller för litet för en int");
            }

            // Metod 2: TryParse
            Console.WriteLine("\nMetod 2: TryParse");
            int tryParseResult;
            if (int.TryParse(input, out tryParseResult))
            {
                Console.WriteLine($"Resultat: {tryParseResult}");
            }
            else
            {
                Console.WriteLine("Kunde inte konvertera strängen till en int");
            }

            Console.WriteLine();
        }

        static void ValidateUserInput()
        {
            Console.WriteLine("Exempel 4: Praktiskt exempel - Inmatningsvalidering");
            Console.WriteLine("------------------------------------------------");

            // Simulerar användarinmatningar (i en riktig app skulle dessa vara Console.ReadLine())
            string[] inputs = new string[] { "42", "3.14", "hej", "2147483648" };

            foreach (string input in inputs)
            {
                Console.WriteLine($"Validerar inmatning: \"{input}\"");

                int number;
                if (int.TryParse(input, out number))
                {
                    // Endast om konverteringen lyckas
                    Console.WriteLine($"Giltigt heltal: {number}");

                    // Exempel på ytterligare validering efter lyckad konvertering
                    if (number > 0 && number <= 100)
                    {
                        Console.WriteLine("Värdet är inom tillåtet intervall (1-100)");
                    }
                    else
                    {
                        Console.WriteLine("Varning: Värdet är utanför tillåtet intervall (1-100)");
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltig inmatning: Kunde inte konvertera till heltal");
                }

                Console.WriteLine();
            }
        }
    }
}
