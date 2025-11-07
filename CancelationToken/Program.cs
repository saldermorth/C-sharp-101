using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.Clear();
        Console.WriteLine("1. Utan cancellation\n2. Med token (ESC)\n3. Med tidsbaserad token\n");
        Console.Write("Välj alternativ: ");
        var choice = Console.ReadKey().KeyChar;
        Console.Clear();

        switch (choice)
        {
            case '1':
                await ProcessLargeFileAsync(); // utan cancellation
                Console.WriteLine("\nBearbetning klar!");
                break;

            case '2':
                await WithUserCancelAsync(); // med ESC-avbryt
                break;

            case '3':
                await WithTimedCancelAsync(); // tidsbaserad
                break;

            default:
                Console.WriteLine("\nOgiltigt val.");
                break;
        }
    }

    // --- 1. Utan cancellation ---
    public static async Task ProcessLargeFileAsync()
    {
        for (int i = 0; i <= 100000; i++)
            await ProcessItemAsync(i, 100000);
    }

    // --- 2. Med användarstyrd cancellation ---
    public static async Task WithUserCancelAsync()
    {
        using CancellationTokenSource cts = new();
        _ = Task.Run(() =>
        {
            Console.Write("Tryck ESC för att avbryta.");
            while (true)
            {
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    cts.Cancel();
                    break;
                }
            }
        });

        try
        {
            for (int i = 0; i < 10000; i++)
            {
                cts.Token.ThrowIfCancellationRequested();
                await ProcessItemAsync(i, 10000);
                await Task.Delay(1);
            }
            Console.WriteLine("\nBearbetning klar!");
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("\nAvbrutet av användaren.");
        }
    }

    // --- 3. Med tidsstyrd cancellation ---
    public static async Task WithTimedCancelAsync()
    {
        using CancellationTokenSource cts = new();
        cts.CancelAfter(3000);

        try
        {
            for (int i = 0; i < 10000; i++)
            {
                cts.Token.ThrowIfCancellationRequested();
                await ProcessItemAsync(i, 10000);
                await Task.Delay(1);
            }
            Console.WriteLine("\nBearbetning klar!");
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("\nAvbrutet efter timeout.");
        }
    }

    // --- Gemensam progressmetod ---
    public static async Task ProcessItemAsync(int i, int total)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.CursorVisible = false;
        Console.SetCursorPosition(5, 5);
        Console.WriteLine($"{(i / (double)total) * 100:0.00}% Complete   ");
        await Task.Yield();
    }
}
