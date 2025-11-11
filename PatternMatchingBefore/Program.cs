using System;

abstract class Animal
{
    public string Name { get; set; }
    public abstract void MakeSound();
}

class Lion : Animal
{
    public override void MakeSound() => Console.WriteLine("Roar!");
}

class Elephant : Animal
{
    public int TrunkLength { get; set; }
    public override void MakeSound() => Console.WriteLine("Trumpet!");
}

class Monkey : Animal
{
    public bool CanClimb { get; set; }
    public override void MakeSound() => Console.WriteLine("Ooh ooh ah ah!");
}

class Program
{
    static void Main(string[] args)
    {
        Animal[] animals = new Animal[]
        {
            new Lion { Name = "Simba" },
            new Elephant { Name = "Dumbo", TrunkLength = 60 },
            new Monkey { Name = "Rafiki", CanClimb = true },
            new Lion { Name = "Mufasa" }
        };

        foreach (Animal animal in animals)
        {
            animal.MakeSound();

            // Handling animal types before pattern matching
            if (animal is Lion)
            {
                Lion lion = (Lion)animal;
                Console.WriteLine($"{lion.Name} is a mighty lion!");
            }
            else if (animal is Elephant)
            {
                Elephant elephant = (Elephant)animal;
                if (elephant.TrunkLength > 50)
                {
                    Console.WriteLine($"{elephant.Name} has a really long trunk of {elephant.TrunkLength}cm!");
                }
            }
            else if (animal is Monkey)
            {
                Monkey monkey = (Monkey)animal;
                if (monkey.CanClimb)
                {
                    Console.WriteLine($"{monkey.Name} is a climbing monkey!");
                }
            }
        }
    }
}