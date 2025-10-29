# Beginner's Guide to Logging in .NET with Serilog and ILogger

## What is Logging and Why Is It Important?

Logging records what your application is doing. Think of it like a diary for your program. When your app is running in production and something goes wrong, good logging helps you understand:
- What happened
- When it happened
- Where in the code it happened
- What data was involved

## Key Logging Concepts

### 1. Log Levels

Different types of events should be logged at different levels:

| Level | When to Use | Example |
|-------|-------------|---------|
| **Verbose** | Extremely detailed information | "Starting loop iteration 3" |
| **Debug** | Detailed information useful for debugging | "User input received: hello" |
| **Information** | Normal application flow | "User logged in successfully" |
| **Warning** | Potential problems that don't stop the app | "File not found, using default" |
| **Error** | Problems that prevent something from working | "Failed to save data to database" |
| **Fatal** | Critical errors that crash the app | "Out of memory exception" |

### 2. Structured Logging

Traditional logging uses string messages, like:
```csharp
logger.LogInformation("User with ID 123 logged in from 192.168.1.1");
```

Structured logging uses templates with named parameters:
```csharp
logger.LogInformation("User with ID {UserId} logged in from {IpAddress}", 123, "192.168.1.1");
```

This captures both the text AND the data values separately, making it much easier to search and filter logs.

### 3. Log Sinks

A "sink" is a destination for your logs. Common sinks include:
- Console (for development)
- Files (for basic production)
- Databases
- Cloud logging services

## How Logging Works in Our Code

### Step 1: Configure Serilog

```csharp
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("app.log")
    .CreateLogger();
```

### Step 2: Connect Serilog to .NET's logging system

```csharp
services.AddLogging(builder => {
    builder.AddSerilog(dispose: true);
});
```

### Step 3: Inject ILogger into your classes

```csharp
public class AnimalService
{
    private readonly ILogger<AnimalService> _logger;
    
    // Get logger via constructor
    public AnimalService(ILogger<AnimalService> logger)
    {
        _logger = logger;
    }
}
```

### Step 4: Use the logger throughout your code

```csharp
// Log a simple message
_logger.LogInformation("Application started");

// Log with structured data
_logger.LogInformation("Created user {Username} with ID {UserId}", "john", 123);

// Log an exception
try {
    // some code that might fail
}
catch (Exception ex) {
    _logger.LogError(ex, "Failed to process request");
}
```

### Step 5: Always flush logs when your application exits

```csharp
Log.CloseAndFlush();
```

## Logging Best Practices

1. **Use the Right Level**: Don't log everything as Error or Information.

2. **Be Consistent**: Use the same message format for similar events.

3. **Use Structured Logging**: Always use templates with parameters instead of string concatenation:
   ```csharp
   // GOOD:
   _logger.LogInformation("User {UserId} logged in", userId);
   
   // BAD:
   _logger.LogInformation("User " + userId + " logged in");
   ```

4. **Include Context**: Log who, what, when, where, and why.

5. **Don't Log Sensitive Data**: Never log passwords, credit cards, etc.

6. **Use Scopes for Related Operations**: Group logs for a specific operation.

7. **Log at Application Boundaries**: Log when data enters or leaves your system.

8. **Log Exceptions Properly**: Include the exception object for stack traces:
   ```csharp
   // GOOD:
   _logger.LogError(ex, "Failed to save data");
   
   // BAD:
   _logger.LogError("Failed to save data: " + ex.Message);
   ```

9. **Clean Up**: Always call Log.CloseAndFlush() when your application exits.