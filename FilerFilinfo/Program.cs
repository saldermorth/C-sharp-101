using System.IO;



  string path = @"C:\Users\GustavBerg\source\repos\C-sharp-101\FilerFilinfo\Hello, World.txt.txt";
FileInfo fileInfo = new FileInfo(path);

if (fileInfo.Exists)
{
    Console.WriteLine($"Filnamn: {fileInfo.Name}");
    Console.WriteLine($"Skapad: {fileInfo.CreationTime}");
    Console.WriteLine($"Ändrad: {fileInfo.LastWriteTime}");
    Console.WriteLine($"Använd: {fileInfo.LastAccessTime}");
    Console.WriteLine($"Attribut: {fileInfo.Attributes}");
    Console.WriteLine($"Katalog: {fileInfo.DirectoryName}");
    Console.WriteLine($"Filändelse: {fileInfo.Extension}");
}


