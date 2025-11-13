using System;
using System.Collections.Generic;

// ====== ENUMERATION ======
public enum AnimalStatus
{
    Healthy,
    Sick,
    Sleeping
}

// ====== INTERFACE ======
public interface IFeedable
{
    void Feed();
}

// ====== ABSTRAKT SUPERTYP ======
public abstract class Animal : IFeedable
{
    public string Name { get; set; }
    public int Age { get; set; }
    public AnimalStatus Status { get; set; }

    public abstract void MakeSound();
    public virtual void Feed()
    {
        Console.WriteLine($"{Name} is being fed.");
    }
}

// ====== SUBKLASSER (ARV) ======
public class Lion : Animal
{
    public override void MakeSound() => Console.WriteLine("Roar!");
}

public class Elephant : Animal
{
    public override void MakeSound() => Console.WriteLine("Trumpet!");
}

// ====== SAMMANSÄTTNING (KOMPOSITION) ======
public class Enclosure
{
    public string Name { get; set; }
    public List<Animal> Animals { get; set; } = new();

    public void Clean() => Console.WriteLine($"{Name} enclosure cleaned.");
}

// ====== AGGREGATION (ZOO HAR FLERA ENCLOSURES) ======
public class Zoo
{
    public string Name { get; set; }
    public List<Enclosure> Enclosures { get; set; } = new();
    public List<ZooKeeper> Keepers { get; set; } = new();

    public void AddEnclosure(Enclosure e) => Enclosures.Add(e);
}

// ====== ASSOCIATION (Zookeeper TAR HAND OM DYR) ======
public class ZooKeeper
{
    public string FullName { get; set; }
    public List<Animal> AssignedAnimals { get; set; } = new();

    public void FeedAnimal(Animal animal)
    {
        animal.Feed();
    }
}

// ====== DEPENDENCY (VETERINÄR ANVÄNDER ANIMAL SOM PARAMETER) ======
public class Veterinarian
{
    public void CheckHealth(Animal a)
    {
        Console.WriteLine($"{a.Name} is checked by vet.");
    }
}


