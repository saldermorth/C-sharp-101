namespace Filhantering
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Kombinera sökvägar säkert
            string basePath = @"C:\Users\Student";
            string fileName = "dokument.txt";
            string fullPath = Path.Combine(basePath, fileName);

            // Hämta olika delar av en sökväg
            string filePath = @"C:\Projekt\MinApp\data\settings.json";
            string directory = Path.GetDirectoryName(filePath);    // C:\Projekt\MinApp\data
            string fileName2 = Path.GetFileName(filePath);         // settings.json
            string extension = Path.GetExtension(filePath);        // .json
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(filePath); // settings

            // Absolut sökväg - komplett sökväg från root
            string absolutePath = @"C:\Users\Student\Documents\fil.txt";

            // Relativ sökväg - relativt till nuvarande katalog
            string relativePath = @"Documents\fil.txt";


            Console.WriteLine(AppPaths.UserProfile);
        }

        // Plattformsoberoende sätt att hitta systemkataloger
        public static class AppPaths
        {
            public static string UserDocuments =>
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            public static string AppData =>
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            public static string LocalAppData =>
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            public static string UserProfile =>
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            public static string Desktop =>
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // Skapa applikationsspecifik mapp
            public static string GetAppDataPath(string appName)
            {
                return Path.Combine(AppData, appName);
            }
        }
    }
}


