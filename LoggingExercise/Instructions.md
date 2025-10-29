# Loggningsövningar för studenter

## Övning 1: Grundläggande konsolloggning

**Mål:** Skapa en enkel konsolapplikation som loggar meddelanden på olika nivåer.

**Instruktioner:**
1. Skapa en ny konsolapplikation
2. Lägg till nödvändiga NuGet-paket för Serilog
3. Konfigurera Serilog för att logga till konsolen
4. Skriv kod som loggar minst ett meddelande på var och en av dessa nivåer:
   - Information
   - Warning
   - Error
   - Debug
5. Kör din applikation och observera resultatet

**Startkod:**
```csharp
using System;
using Serilog;

namespace LoggningsÖvning1
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: Konfigurera Serilog för att logga till konsolen
            
            Console.WriteLine("=== Övning 1: Grundläggande konsolloggning ===");
            
            // TODO: Logga meddelanden på olika nivåer
            
            // Glöm inte att spola loggarna!
            
            Console.WriteLine("Tryck på valfri tangent för att avsluta...");
            Console.ReadKey();
        }
    }
}
```

**NuGet-paket som behövs:**
- Serilog
- Serilog.Sinks.Console

## Övning 2: Filloggning med konfiguration

**Mål:** Utöka din loggning för att skriva till både konsol och fil, med anpassad formatering.

**Instruktioner:**
1. Använd koden från Övning 1 som utgångspunkt
2. Ändra Serilog-konfigurationen för att:
   - Fortsätta logga till konsolen
   - Lägga till loggning till en fil som heter "övning2.log"
   - Ställa in minsta nivå till Debug
   - Använda ett anpassat format för tidsstämplar
3. Lägg till en try/catch-block runt din huvudkod
4. Logga eventuella undantag som uppstår
5. Skapa ett avsiktligt undantag för att testa din felloggning
6. Kontrollera både konsolresultatet och loggfilen

**Startkod:**
```csharp
using System;
using Serilog;

namespace LoggningsÖvning2
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: Konfigurera Serilog för att logga till både konsol och fil
            
            try
            {
                Console.WriteLine("=== Övning 2: Filloggning med konfiguration ===");
                
                // TODO: Logga några normala meddelanden
                
                // TODO: Skapa ett avsiktligt undantag
                // int resultat = 10 / 0; // Avkommentera denna rad för att testa undantagsloggning
            }
            catch (Exception ex)
            {
                // TODO: Logga undantaget
            }
            finally
            {
                // TODO: Spola loggarna
            }
            
            Console.WriteLine("Tryck på valfri tangent för att avsluta...");
            Console.ReadKey();
        }
    }
}
```

**NuGet-paket som behövs:**
- Serilog
- Serilog.Sinks.Console
- Serilog.Sinks.File

## Bonus övningar nedan

## Övning 3: Strukturerad loggning med ILogger

**Mål:** Använd beroendeinjektion och strukturerad loggning i en klassbaserad applikation.

**Instruktioner:**
1. Skapa en konsolapplikation med en `Kalkylator`-klass
2. Konfigurera beroendeinjektion för att tillhandahålla `ILogger<Kalkylator>` till klassen
3. Implementera grundläggande matematiska operationer (Addera, Subtrahera, Multiplicera, Dividera)
4. Använd strukturerad loggning för att logga:
   - Inparametrar för varje operation
   - Resultatet av varje operation
   - Eventuella fel (som division med noll)
5. Använd lämpliga loggnivåer för olika situationer
6. Testa din kalkylator med olika indata, inklusive ogiltiga

**Startkod:**
```csharp
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace LoggningsÖvning3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Konfigurera Serilog
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("kalkylator.log")
                .CreateLogger();
                
            try
            {
                // Konfigurera beroendeinjektion
                var services = new ServiceCollection();
                
                // TODO: Lägg till loggning i service collection
                
                // TODO: Registrera Kalkylator-klassen
                
                var serviceProvider = services.BuildServiceProvider();
                
                // TODO: Hämta Kalkylator och kör några operationer
                
                Log.Information("Applikationen avslutades framgångsrikt");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Applikationen avslutades oväntat");
            }
            finally
            {
                Log.CloseAndFlush();
            }
            
            Console.WriteLine("Tryck på valfri tangent för att avsluta...");
            Console.ReadKey();
        }
    }
    
    public class Kalkylator
    {
        private readonly ILogger<Kalkylator> _logger;
        
        // TODO: Konstruktor med ILogger-parameter
        
        // TODO: Implementera metoderna Addera, Subtrahera, Multiplicera och Dividera
        // med lämplig strukturerad loggning
    }
}
```

**NuGet-paket som behövs:**
- Microsoft.Extensions.DependencyInjection
- Microsoft.Extensions.Logging
- Serilog
- Serilog.Extensions.Logging
- Serilog.Sinks.Console
- Serilog.Sinks.File

## Övning 4: Avancerade loggningsfunktioner

**Mål:** Skapa ett simulerat orderhanteringssystem med avancerade loggningsfunktioner.

**Instruktioner:**
1. Skapa en konsolapplikation med dessa klasser:
   - `Order` (modellklass med Id, KundNamn, Belopp)
   - `OrderValidator` (validerar ordrar)
   - `OrderProcessor` (bearbetar giltiga ordrar)
2. Använd beroendeinjektion för alla klasser
3. Implementera avancerade loggningsfunktioner:
   - Använd loggningssektioner (scopes) för att spåra bearbetning av varje order
   - Lägg till kontextuella egenskaper i loggar (order-ID, kund)
   - Använd lämpliga loggnivåer för olika situationer
   - Logga indata-validering
   - Logga bearbetningssteg
   - Logga lyckat/misslyckat resultat
4. Skapa en testmiljö som bearbetar flera ordrar, inklusive några ogiltiga
5. Gör din loggutdata läsbar och användbar för felsökning

**Startkod:**
```csharp
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace LoggningsÖvning4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Konfigurera Serilog
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .Enrich.FromLogContext() // Viktigt för loggningssektioner!
                .WriteTo.Console(outputTemplate: 
                    "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.File("ordrar.log",
                    rollingInterval: RollingInterval.Day)
                .CreateLogger();
                
            try
            {
                Log.Information("Orderhanteringssystem startar");
                
                // Konfigurera beroendeinjektion
                var services = new ServiceCollection();
                
                // Lägg till loggning
                services.AddLogging(builder => {
                    builder.AddSerilog(dispose: true);
                });
                
                // Registrera tjänster
                services.AddTransient<OrderValidator>();
                services.AddTransient<OrderProcessor>();
                services.AddTransient<OrderService>();
                
                var serviceProvider = services.BuildServiceProvider();
                
                // Hämta tjänst och bearbeta testordrar
                var orderService = serviceProvider.GetRequiredService<OrderService>();
                orderService.ProcessTestOrders();
                
                Log.Information("Orderhanteringssystem avslutades framgångsrikt");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Orderhanteringssystem avslutades oväntat");
            }
            finally
            {
                Log.CloseAndFlush();
            }
            
            Console.WriteLine("Tryck på valfri tangent för att avsluta...");
            Console.ReadKey();
        }
    }
    
    // Modell
    public class Order
    {
        public int Id { get; set; }
        public string KundNamn { get; set; }
        public decimal Belopp { get; set; }
    }
    
    // TODO: Implementera OrderValidator-klass med ILogger
    
    // TODO: Implementera OrderProcessor-klass med ILogger
    
    // TODO: Implementera OrderService-klass med testdata och bearbetning
}
```

**NuGet-paket som behövs:**
- Microsoft.Extensions.DependencyInjection
- Microsoft.Extensions.Logging
- Serilog
- Serilog.Extensions.Logging
- Serilog.Sinks.Console
- Serilog.Sinks.File
- Serilog.Enrichers.Thread
- Serilog.Extensions.Hosting