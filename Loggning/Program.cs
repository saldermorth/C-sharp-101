using Serilog;
using System;

namespace SuperSimpleSerilog
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setup Serilog
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("Vårloggfil.log")
                .CreateLogger();

            // Basic logging
            Log.Information("Application started");
            Log.Warning("This is a warning");

            try
            {
                Log.Debug("About to do something");
                // Simulate error
                throw new Exception("Demo exception");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred");
            }

            Log.Information("Application ending");

            // Important: flush logs when done
            Log.CloseAndFlush();
        }
    }
}