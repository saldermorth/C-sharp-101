using System;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        var cars = new List<Car>{
            new Car("bmw", "black", new Owner("Hampus")),
            new Car("volvo", "red", new Owner("Bente")),
            new Car("bmw", "gray", new Owner("Wisam"))
        };

        var options = new JsonSerializerOptions { WriteIndented = true };

        string json = JsonSerializer.Serialize(cars, options);

        File.WriteAllText("cars.json", json);

        var jsonCars = File.ReadAllText("cars.json");

        var carsArr = JsonSerializer.Deserialize<List<Car>>(jsonCars);

        foreach (var car in carsArr) Console.WriteLine($"{car.Brand} {car.Brand}, {car.Owner}");


    }
    public string Sant(bool Availibel)
    {
        if (Availibel == true)
        {
            return "Sant";
        }
        else
        {
            return "Falskt";
        }
    }
}

class Owner
{
    public string Name { get; set; }

    public Owner(string name)
    {
        Name = name;
    }
    public Owner() { }
}

class Car
{
    public string Brand { get; set; }
    public string Color { get; set; }
    public Owner Owner { get; set; }

    public Car(string brand, string color, Owner owner)
    {
        Brand = brand;
        Color = color;
        Owner = owner;
    }
    public Car() { }
}