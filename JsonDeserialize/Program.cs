//Demo 1
//using System;
//using System.IO;
//using System.Text.Json;

//class Person
//{
//    public string Name { get; set; }
//    public int Age { get; set; }
//}

//class Program
//{
//    static void Main()
//    {
//        string json = File.ReadAllText("person.json");

//        Person person = JsonSerializer.Deserialize<Person>(json);

//        Console.WriteLine($"{person.Name} is {person.Age} years old.");
//    }
//}

//Demo 2
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Address
{
    public string Street { get; set; }
    public string City { get; set; }
}

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public Address Address { get; set; }
}

class Program
{
    static void Main()
    {
        string json = File.ReadAllText("people_with_addresses.json");

        List<Person> people = JsonSerializer.Deserialize<List<Person>>(json);

        foreach (var p in people)
            Console.WriteLine($"{p.Name} lives on {p.Address.Street} in {p.Address.City}");
    }
}
