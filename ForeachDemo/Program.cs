string[] färger = { "röd", "grön", "blå", "gul" };
Console.WriteLine("Tillgängliga färger:");
foreach (var färg in färger)
{
    Console.WriteLine(färg);
}


double[] veckansTemperaturer = { 22.5, 25.3, 18.9, 20.1, 23.4, 19.8, 21.2 };
double summa = 0;
int antalDagar = 0;
double varmastaTemperatur = double.MinValue;

foreach (double temperatur in veckansTemperaturer)
{
    summa += temperatur;
    antalDagar++;
    if (temperatur > varmastaTemperatur)
    {
        varmastaTemperatur = temperatur;
    }
    Console.WriteLine($"Dag {antalDagar}: {temperatur:F1}°C");
}

double medeltemperatur = summa / antalDagar;
Console.WriteLine($"\nMedeltemperatur för veckan: {medeltemperatur:F1}°C");
Console.WriteLine($"Varmaste dagen var: {varmastaTemperatur:F1}°C");
