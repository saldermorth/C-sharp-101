// DEMO: File Write-metoder

// Fokuserad demo på att skriva och lägga till i filer


using System;

using System.IO;

using System.Text;


namespace FileWriteDemo

{

    class Program

    {
        // Skapa testfiler för demon
        static void PrepareTestFiles()
        {
            // Namnfil
            File.WriteAllLines("names.txt", new[]
            {
        "Anna Andersson",
        "Bertil Bengtsson",
        "Cecilia Carlsson"
    });

            // Adressfil
            File.WriteAllLines("addresses.txt", new[]
            {
        "Storgatan 1",
        "Lillgatan 2",
        "Centralvägen 3"
    });
        }


        static void Main(string[] args)

        {

            Console.WriteLine("=== DEMO: File Write-metoder ===\n");



            // Rensa gamla filer om de finns

            CleanupFiles();



            // DEMO 1: WriteAllText - Enklaste sättet

            Demo1_WriteAllText();



            // DEMO 2: WriteAllLines - Skriva flera rader

            Demo2_WriteAllLines();



            // DEMO 3: WriteAllBytes - Binär data

            Demo3_WriteAllBytes();



            // DEMO 4: AppendAllText - Lägga till text

            Demo4_AppendAllText();



            // DEMO 5: AppendAllLines - Lägga till rader

            Demo5_AppendAllLines();



            // DEMO 6: Praktiskt exempel - Loggning

            Demo6_PracticalExample();



            // Visa resultat

            ShowResults();



            Console.WriteLine("\n=== Demo slutförd! ===");

        }



        // DEMO 1: File.WriteAllText() - Skriva text till fil

        static void Demo1_WriteAllText()

        {

            Console.WriteLine("=== DEMO 1: File.WriteAllText() ===");



            // Enkelt exempel

            string content = "Detta är min första textfil!";

            File.WriteAllText("demo1.txt", content);

            Console.WriteLine("✓ Skapade demo1.txt med enkel text");



            // Med radbrytningar

            string multiLineContent = "Rad 1\nRad 2\nRad 3";

            File.WriteAllText("demo1_multiline.txt", multiLineContent);

            Console.WriteLine("✓ Skapade demo1_multiline.txt med flera rader");



            // Skriver över befintlig fil

            File.WriteAllText("demo1.txt", "Nytt innehåll som skriver över det gamla!");

            Console.WriteLine("✓ Skrev över demo1.txt med nytt innehåll");



            // Med svenska tecken

            string swedishText = "Åsa åker till Göteborg för att äta äpplen";

            File.WriteAllText("demo1_svenska.txt", swedishText);

            Console.WriteLine("✓ Skapade demo1_svenska.txt med svenska tecken");



            Console.WriteLine("WriteAllText() skriver ÖVER befintlig fil!\n");

        }



        // DEMO 2: File.WriteAllLines() - Skriva array av strängar

        static void Demo2_WriteAllLines()

        {

            Console.WriteLine("=== DEMO 2: File.WriteAllLines() ===");



            // Array av strängar

            string[] shoppingList = {

                "Mjölk",

                "Bröd",

                "Äpplen",

                "Kaffe",

                "Pasta"

            };

            File.WriteAllLines("demo2_handlingar.txt", shoppingList);

            Console.WriteLine("✓ Skapade handlingslista med WriteAllLines()");



            // Lista med namn

            string[] students = {

                "Anna Andersson",

                "Bertil Bengtsson",

                "Cecilia Carlsson",

                "David Davidsson"

            };

            File.WriteAllLines("demo2_studenter.txt", students);

            Console.WriteLine("✓ Skapade studentlista");



            // Automatisk radbrytning

            string[] codeLines = {

                "using System;",

                "class Program {",

                "    static void Main() {",

                "        Console.WriteLine(\"Hello World!\");",

                "    }",

                "}"

            };

            File.WriteAllLines("demo2_kod.txt", codeLines);

            Console.WriteLine("✓ Skapade kodfil med automatiska radbrytningar");



            Console.WriteLine("WriteAllLines() lägger automatiskt till radbrytningar!\n");

        }



        // DEMO 3: File.WriteAllBytes() - Skriva byte-array

        static void Demo3_WriteAllBytes()

        {

            Console.WriteLine("=== DEMO 3: File.WriteAllBytes() ===");



            // Konvertera text till bytes

            string text = "Detta blir bytes!";

            byte[] textAsBytes = Encoding.UTF8.GetBytes(text);

            File.WriteAllBytes("demo3_bytes.txt", textAsBytes);

            Console.WriteLine("✓ Skrev text som bytes till demo3_bytes.txt");

            Console.WriteLine($"   Text: '{text}' blev {textAsBytes.Length} bytes");



            // Skapa binär data (exempel med siffror)

            byte[] binaryData = { 0x48, 0x65, 0x6C, 0x6C, 0x6F }; // "Hello" i ASCII

            File.WriteAllBytes("demo3_binary.dat", binaryData);

            Console.WriteLine("✓ Skrev binär data till demo3_binary.dat");



            // Skapa "fake" bildfil (bara för demo)

            byte[] fakeImageHeader = {

                0xFF, 0xD8, 0xFF, 0xE0, // JPEG header start

                0x00, 0x10, 0x4A, 0x46  // Fortsättning av JPEG header

            };

            File.WriteAllBytes("demo3_fake.jpg", fakeImageHeader);

            Console.WriteLine("✓ Skapade fake JPEG-fil (bara header)");



            Console.WriteLine("WriteAllBytes() används för binär data (bilder, ljud, etc.)\n");

        }



        // DEMO 4: File.AppendAllText() - Lägga till text

        static void Demo4_AppendAllText()

        {

            Console.WriteLine("=== DEMO 4: File.AppendAllText() ===");



            // Skapa grundfil

            File.WriteAllText("demo4_logg.txt", "LOGGFIL STARTAD\n");

            Console.WriteLine("✓ Skapade grundloggfil");



            // Lägg till flera poster

            File.AppendAllText("demo4_logg.txt", "[10:00] Användaren loggade in\n");

            File.AppendAllText("demo4_logg.txt", "[10:15] Fil öppnad\n");

            File.AppendAllText("demo4_logg.txt", "[10:30] Data sparad\n");

            Console.WriteLine("✓ Lade till 3 loggposter");



            // Lägg till utan radbrytning

            File.AppendAllText("demo4_logg.txt", "[10:45] Status: ");

            File.AppendAllText("demo4_logg.txt", "OK\n");

            Console.WriteLine("✓ Lade till status på samma rad");



            // Simulera fel

            File.AppendAllText("demo4_logg.txt", "[10:50] FEL: Något gick snett!\n");

            File.AppendAllText("demo4_logg.txt", "LOGGFIL AVSLUTAD\n");

            Console.WriteLine("✓ Lade till fel och avslutning");



            Console.WriteLine("AppendAllText() BEHÅLLER befintligt innehåll!\n");

        }



        // DEMO 5: File.AppendAllLines() - Lägga till rader

        static void Demo5_AppendAllLines()

        {

            Console.WriteLine("=== DEMO 5: File.AppendAllLines() ===");



            // Skapa initial lista

            string[] initialFriends = { "Anna", "Bertil", "Cecilia" };

            File.WriteAllLines("demo5_vänner.txt", initialFriends);

            Console.WriteLine("✓ Skapade initial vännerlista");



            // Lägg till fler vänner

            string[] moreFriends = { "David", "Eva" };

            File.AppendAllLines("demo5_vänner.txt", moreFriends);

            Console.WriteLine("✓ Lade till 2 vänner");



            // Lägg till en vän till

            string[] evenMoreFriends = { "Fredrik" };

            File.AppendAllLines("demo5_vänner.txt", evenMoreFriends);

            Console.WriteLine("✓ Lade till 1 vän till");



            // Skapa uppgiftslista

            File.WriteAllText("demo5_uppgifter.txt", "MINA UPPGIFTER:\n");



            string[] mondayTasks = { "- Handla mat", "- Träna" };

            File.AppendAllLines("demo5_uppgifter.txt", mondayTasks);



            string[] tuesdayTasks = { "- Städa", "- Plugga C#" };

            File.AppendAllLines("demo5_uppgifter.txt", tuesdayTasks);



            Console.WriteLine("✓ Skapade veckouppgifter");

            Console.WriteLine("AppendAllLines() lägger till rader EFTER befintligt innehåll!\n");

        }



        // DEMO 6: Praktiskt exempel - Enkel loggklass

        static void Demo6_PracticalExample()

        {

            Console.WriteLine("=== DEMO 6: Praktiskt exempel - Logger ===");



            // Simulera en enkel applikation med loggning

            SimpleLogger.Initialize("app.log");



            SimpleLogger.Log("Applikationen startad");

            SimpleLogger.Log("Användaren 'Anna' loggade in");

            SimpleLogger.LogError("Kunde inte ansluta till databas");

            SimpleLogger.Log("Försöker ansluta igen...");

            SimpleLogger.Log("Anslutning lyckades");

            SimpleLogger.LogWarning("Diskutrymme blir lågt");

            SimpleLogger.Log("Användaren loggade ut");

            SimpleLogger.Log("Applikationen avslutas");



            Console.WriteLine("✓ Simulerade applikation med loggning");

            Console.WriteLine("Se app.log för resultatet\n");

        }



        // Visa innehållet i skapade filer

        static void ShowResults()

        {

            Console.WriteLine("=== RESULTAT AV DEMO ===");



            // Visa några exempel på vad som skapades

            if (File.Exists("demo1.txt"))

            {

                Console.WriteLine("\ndemo1.txt innehåll:");

                Console.WriteLine($"'{File.ReadAllText("demo1.txt")}'");
            }

            if (File.Exists("demo2_handlingar.txt"))
            {
                Console.WriteLine("\ndemo2_handlingar.txt innehåll:");

                string[] lines = File.ReadAllLines("demo2_handlingar.txt");

                for (int i = 0; i < lines.Length; i++)

                {

                    Console.WriteLine($"  Rad {i + 1}: {lines[i]}");

                }

            }



            if (File.Exists("demo4_logg.txt"))

            {

                Console.WriteLine("\ndemo4_logg.txt innehåll:");

                string logContent = File.ReadAllText("demo4_logg.txt");

                Console.WriteLine(logContent);

            }

        }



        // Rensa gamla filer

        static void CleanupFiles()

        {

            string[] filesToDelete = {

                "demo1.txt", "demo1_multiline.txt", "demo1_svenska.txt",

                "demo2_handlingar.txt", "demo2_studenter.txt", "demo2_kod.txt",

                "demo3_bytes.txt", "demo3_binary.dat", "demo3_fake.jpg",

                "demo4_logg.txt", "demo5_vänner.txt", "demo5_uppgifter.txt",

                "app.log"

            };



            foreach (string file in filesToDelete)

            {

                if (File.Exists(file))

                {

                    File.Delete(file);

                }

            }

        }

    }



    // Enkel logger-klass för demonstration

    public static class SimpleLogger

    {

        private static string _logFile;



        public static void Initialize(string logFileName)

        {

            _logFile = logFileName;

            // Rensa gammal logg

            if (File.Exists(_logFile))

                File.Delete(_logFile);



            File.WriteAllText(_logFile, $"=== LOGG STARTAD {DateTime.Now} ===\n");

        }



        public static void Log(string message)

        {

            string logEntry = $"[{DateTime.Now:HH:mm:ss}] INFO: {message}\n";

            File.AppendAllText(_logFile, logEntry);

        }



        public static void LogError(string message)

        {

            string logEntry = $"[{DateTime.Now:HH:mm:ss}] ERROR: {message}\n";

            File.AppendAllText(_logFile, logEntry);

        }



        public static void LogWarning(string message)

        {

            string logEntry = $"[{DateTime.Now:HH:mm:ss}] WARNING: {message}\n";

            File.AppendAllText(_logFile, logEntry);

        }

    }

}


/*

SAMMANFATTNING AV WRITE-METODERNA:


1. File.WriteAllText(fil, text)

   - Skriver text till fil

   - SKRIVER ÖVER befintlig fil

   - Automatisk UTF-8 encoding

   - Enklast för enkla texter


2. File.WriteAllLines(fil, string[])

   - Skriver array av strängar

   - SKRIVER ÖVER befintlig fil  

   - Automatiska radbrytningar

   - Perfekt för listor


3. File.WriteAllBytes(fil, byte[])

   - Skriver byte-array

   - SKRIVER ÖVER befintlig fil

   - För binär data

   - Bilder, ljud, etc.


4. File.AppendAllText(fil, text)

   - LÄGGER TILL text i slutet

   - Behåller befintligt innehåll

   - Ingen automatisk radbrytning

   - Perfekt för loggning


5. File.AppendAllLines(fil, string[])

   - LÄGGER TILL rader i slutet

   - Behåller befintligt innehåll

   - Automatiska radbrytningar

   - Bygg upp filer steg för steg


VIKTIGT: Write = Skriver över, Append = Lägger till!

*/