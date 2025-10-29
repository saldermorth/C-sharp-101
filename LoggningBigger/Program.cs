using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Extensions.Logging; // Required for the AddSerilog extension method
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimalStore
{
    class Program
    {
        static void Main(string[] args)
        {
            //----------------------------------------------------------------
            // STEP 1: Configure Serilog first before anything else
            //----------------------------------------------------------------
            // This creates a global logger that will be used by your application
            Log.Logger = new LoggerConfiguration()
                // Set the minimum level for all logging output
                .MinimumLevel.Debug() // Debug is the most detailed level - shows all logs

                // Add Console output with custom format 
                .WriteTo.Console(outputTemplate:
                    "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")

                // Add File output with custom format and daily rolling
                // This means a new log file will be created each day
                .WriteTo.File("animalstore.log",
                    rollingInterval: RollingInterval.Day,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}")

                // Build the logger
                .CreateLogger();

            try
            {
                // Use the global logger directly for application-level events
                Log.Information("Starting AnimalStore application");

                //----------------------------------------------------------------
                // STEP 2: Setup Dependency Injection container
                //----------------------------------------------------------------
                var services = new ServiceCollection();

                //----------------------------------------------------------------
                // STEP 3: Register Serilog with the .NET logging system
                //----------------------------------------------------------------
                // This allows classes to use ILogger<T> for logging
                services.AddLogging(builder => {
                    // Connect Serilog to the Microsoft logging infrastructure
                    // dispose: true means Serilog will be disposed when the application closes
                    builder.AddSerilog(dispose: true);
                });

                //----------------------------------------------------------------
                // STEP 4: Register your application services
                //----------------------------------------------------------------
                // Singleton: One instance for the entire application
                services.AddSingleton<IAnimalRepository, AnimalRepository>();
                // Transient: New instance created every time it's requested
                services.AddTransient<AnimalService>();

                // Build the service provider - this creates all the services
                var serviceProvider = services.BuildServiceProvider();

                // Get our service and run the demo
                var animalService = serviceProvider.GetRequiredService<AnimalService>();
                RunDemo(animalService);

                Log.Information("AnimalStore application shutting down normally");
            }
            catch (Exception ex)
            {
                // Log fatal errors - these are unrecoverable application crashes
                Log.Fatal(ex, "Application terminated unexpectedly");
            }
            finally
            {
                //----------------------------------------------------------------
                // STEP 5: Always flush logs before the application exits
                //----------------------------------------------------------------
                // This ensures all logs are written to their destinations
                Log.CloseAndFlush();
            }
        }

        static void RunDemo(AnimalService service)
        {
            Console.WriteLine("\n=== ANIMAL STORE CRUD DEMO ===\n");

            // Create some animals
            var dog = service.CreateAnimal("Dog", "Buddy", 3);
            var cat = service.CreateAnimal("Cat", "Whiskers", 2);
            service.CreateAnimal("Parrot", "Polly", 5);

            // Display all animals
            Console.WriteLine("\n--- All Animals ---");
            var allAnimals = service.GetAllAnimals();
            foreach (var animal in allAnimals)
            {
                Console.WriteLine($"{animal.Id}: {animal.Name} ({animal.Type}), Age: {animal.Age}");
            }

            // Update an animal
            Console.WriteLine("\n--- Updating an Animal ---");
            dog.Name = "Max";
            dog.Age = 4;
            service.UpdateAnimal(dog);

            // Get a specific animal
            Console.WriteLine("\n--- Get Animal By ID ---");
            var foundAnimal = service.GetAnimalById(dog.Id);
            if (foundAnimal != null)
            {
                Console.WriteLine($"Found: {foundAnimal.Name} ({foundAnimal.Type}), Age: {foundAnimal.Age}");
            }

            // Delete an animal
            Console.WriteLine("\n--- Deleting an Animal ---");
            service.DeleteAnimal(cat.Id);

            // Attempt to find a non-existent animal (will log an error)
            Console.WriteLine("\n--- Trying to find non-existent animal ---");
            service.GetAnimalById(999);

            // Display the updated list
            Console.WriteLine("\n--- Final Animal List ---");
            allAnimals = service.GetAllAnimals();
            foreach (var animal in allAnimals)
            {
                Console.WriteLine($"{animal.Id}: {animal.Name} ({animal.Type}), Age: {animal.Age}");
            }
        }
    }

    //----------------------------------------------------------------
    // Model class - represents the data we're working with
    //----------------------------------------------------------------
    public class Animal
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    //----------------------------------------------------------------
    // Repository Interface - defines what operations are available
    //----------------------------------------------------------------
    public interface IAnimalRepository
    {
        List<Animal> GetAll();
        Animal GetById(int id);
        Animal Create(Animal animal);
        bool Update(Animal animal);
        bool Delete(int id);
    }

    //----------------------------------------------------------------
    // Repository Implementation - handles data storage
    //----------------------------------------------------------------
    public class AnimalRepository : IAnimalRepository
    {
        // LOGGING: Inject ILogger<T> to log from this class
        // The generic parameter <AnimalRepository> adds the class name to log entries
        private readonly ILogger<AnimalRepository> _logger;

        // In-memory data storage (in a real app, this would be a database)
        private List<Animal> _animals = new List<Animal>();
        private int _nextId = 1;

        // Constructor that receives the logger via dependency injection
        public AnimalRepository(ILogger<AnimalRepository> logger)
        {
            _logger = logger;
            // Log that this component has been created
            _logger.LogInformation("AnimalRepository initialized");
        }

        public List<Animal> GetAll()
        {
            // LOGGING: Debug level for detailed flow information
            // Adding structured data: {Count} will be replaced with _animals.Count
            _logger.LogDebug("Getting all animals. Count: {Count}", _animals.Count);
            return _animals.ToList();
        }

        public Animal GetById(int id)
        {
            // LOGGING: Debug level for detailed flow information
            _logger.LogDebug("Getting animal by id: {AnimalId}", id);
            var animal = _animals.FirstOrDefault(a => a.Id == id);

            if (animal == null)
            {
                // LOGGING: Warning level for potential problems that don't cause failures
                _logger.LogWarning("Animal with ID {AnimalId} not found", id);
            }

            return animal;
        }

        public Animal Create(Animal animal)
        {
            animal.Id = _nextId++;
            _animals.Add(animal);

            // LOGGING: Information level for normal application flow events
            // Using structured logging: multiple named parameters will be captured
            _logger.LogInformation("Created new {AnimalType} named {AnimalName} with ID {AnimalId}",
                animal.Type, animal.Name, animal.Id);
            return animal;
        }

        public bool Update(Animal animal)
        {
            _logger.LogDebug("Attempting to update animal with ID {AnimalId}", animal.Id);

            var existingIndex = _animals.FindIndex(a => a.Id == animal.Id);
            if (existingIndex == -1)
            {
                // LOGGING: Warning when something unexpected happens but can be handled
                _logger.LogWarning("Cannot update: Animal with ID {AnimalId} not found", animal.Id);
                return false;
            }

            _animals[existingIndex] = animal;
            _logger.LogInformation("Updated {AnimalType} with ID {AnimalId}", animal.Type, animal.Id);
            return true;
        }

        public bool Delete(int id)
        {
            _logger.LogDebug("Attempting to delete animal with ID {AnimalId}", id);

            var animal = _animals.FirstOrDefault(a => a.Id == id);
            if (animal == null)
            {
                _logger.LogWarning("Cannot delete: Animal with ID {AnimalId} not found", id);
                return false;
            }

            _animals.Remove(animal);
            _logger.LogInformation("Deleted {AnimalType} named {AnimalName} with ID {AnimalId}",
                animal.Type, animal.Name, animal.Id);
            return true;
        }
    }

    //----------------------------------------------------------------
    // Service Layer - business logic, uses the repository
    //----------------------------------------------------------------
    public class AnimalService
    {
        private readonly IAnimalRepository _repository;

        // LOGGING: Inject ILogger<T> to log from this class
        private readonly ILogger<AnimalService> _logger;

        // Constructor uses dependency injection to get services
        public AnimalService(IAnimalRepository repository, ILogger<AnimalService> logger)
        {
            _repository = repository;
            _logger = logger;
            _logger.LogInformation("AnimalService initialized");
        }

        public List<Animal> GetAllAnimals()
        {
            _logger.LogInformation("Getting all animals");
            return _repository.GetAll();
        }

        public Animal GetAnimalById(int id)
        {
            _logger.LogInformation("Getting animal with ID {AnimalId}", id);
            try
            {
                var animal = _repository.GetById(id);

                if (animal == null)
                {
                    // LOGGING: Error level for problems that prevent operations from succeeding
                    _logger.LogError("Animal with ID {AnimalId} not found", id);
                }

                return animal;
            }
            catch (Exception ex)
            {
                // LOGGING: Error with exception - logs both message and stack trace
                _logger.LogError(ex, "Error retrieving animal with ID {AnimalId}", id);
                return null;
            }
        }

        public Animal CreateAnimal(string type, string name, int age)
        {
            _logger.LogInformation("Creating new {AnimalType} named {AnimalName}", type, name);

            try
            {
                // LOGGING: Using a scope to group related log entries
                // All logs inside this using block will have "Animal creation" context
                using (_logger.BeginScope("Animal creation"))
                {
                    // Input validation example
                    if (string.IsNullOrEmpty(type))
                    {
                        _logger.LogError("Cannot create animal: Type is required");
                        throw new ArgumentException("Type is required", nameof(type));
                    }

                    if (string.IsNullOrEmpty(name))
                    {
                        _logger.LogError("Cannot create animal: Name is required");
                        throw new ArgumentException("Name is required", nameof(name));
                    }

                    if (age < 0)
                    {
                        _logger.LogError("Cannot create animal: Age cannot be negative");
                        throw new ArgumentException("Age cannot be negative", nameof(age));
                    }

                    var animal = new Animal
                    {
                        Type = type,
                        Name = name,
                        Age = age
                    };

                    _logger.LogDebug("Calling repository to save new animal");
                    return _repository.Create(animal);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating {AnimalType} named {AnimalName}", type, name);
                throw; // Re-throw to allow calling code to handle it
            }
        }

        public bool UpdateAnimal(Animal animal)
        {
            _logger.LogInformation("Updating animal with ID {AnimalId}", animal.Id);

            try
            {
                return _repository.Update(animal);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating animal with ID {AnimalId}", animal.Id);
                return false;
            }
        }

        public bool DeleteAnimal(int id)
        {
            _logger.LogInformation("Deleting animal with ID {AnimalId}", id);

            try
            {
                return _repository.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting animal with ID {AnimalId}", id);
                return false;
            }
        }
    }
}