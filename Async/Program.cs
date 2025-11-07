

using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("=== Live Demo: Task och Async ===\n");

        // 1. Enkel Task
        Console.WriteLine("1. Task.Run:");
        Task.Run(() => Console.WriteLine("Kör i bakgrund"));

        // 2. Await en Task
        Console.WriteLine("2. Await Task:");
        await Task.Run(() =>
        {
            Task.Delay(1000).Wait(); // Simulera arbete
            Console.WriteLine("Task klar!");
        });

        // 3. Task med resultat
        Console.WriteLine("3. Task med resultat:");
        int result = await Task.Run(() => 5 + 3);
        Console.WriteLine($"Resultat: {result}");

        // 4. Async metod
        Console.WriteLine("4. Async metod:");
        string data = await HämtaDataAsync();
        Console.WriteLine($"Data: {data}");

        // 5. Parallellt
        Console.WriteLine("5. Parallellt:");
        Task<int> task1 = BeräknaAsync(10);
        Task<int> task2 = BeräknaAsync(20);
        Task<int> task3 = BeräknaAsync(10);
        Task<int> task4 = BeräknaAsync(20);
        Task<int> task5 = BeräknaAsync(10);
        Task<int> task6 = BeräknaAsync(20);

        int[] resultat = await Task.WhenAll(task1, task2, task3, task4, task5, task6);
        Console.WriteLine($"Resultat: {resultat[0]}, {resultat[1]}, {resultat[2]}, { resultat[3]}, {resultat[4]}, {resultat[5]}");
    }

    static async Task<string> HämtaDataAsync()
    {
        await Task.Delay(500); // Simulera hämtning
        return "Hämtad data";
    }

    static async Task<int> BeräknaAsync(int tal)
    {
        await Task.Delay(300);
        return tal * 2;
    }
}





