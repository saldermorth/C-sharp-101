

using System.IO;

namespace Filhantering
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string windowsPath = @"C:\Windows";
            var empty = !Directory.EnumerateFileSystemEntries(windowsPath).Any();
            //Finns mappen
            if (Directory.Exists(windowsPath))
            {
                Console.WriteLine("Windows mappen finns");
            }

            //Skapa Mapp
            string newPath = @"C:/DeleteMe";
            Directory.CreateDirectory(newPath);

            if (Directory.Exists(newPath))
            {
                Console.WriteLine("DeleteMe mappen finns, nu.");
            }

            //Lista filer
            string[] filer = Directory.GetFiles(windowsPath);
            Console.WriteLine("Alla filer i Windowsmappen");
            foreach (var fil in filer)
            {
                Console.WriteLine(fil);
            }

            //Lista undermappar
            string[] mappar = Directory.GetDirectories(windowsPath);
            Console.WriteLine("Alla filer i Windowsmappen");
            foreach (var mapp in mappar)
            {
                Console.WriteLine(mapp);
            }

            //Ta bort mapp. Försiktig!! . true = tar bort även om mappen har innehåll
            Directory.Delete(@"C:/DeleteMe", false);
        }
    }
}


