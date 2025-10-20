namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Zoo<Cat> catZoo = new Zoo<Cat>();
            catZoo.AddAnimal(new Cat { Name = "Whiskers" });
            catZoo.AddAnimal(new Cat { Name = "Mittens" });

            Zoo<Dog> dogZoo = new Zoo<Dog>();
            dogZoo.AddAnimal(new Dog { Name = "Buddy" });
            dogZoo.AddAnimal(new Dog { Name = "Daisy" });

            catZoo.AllAnimalsMakeSound();
            dogZoo.AllAnimalsMakeSound();
        }
    }
    public interface IAnimalFeeder<T> where T : Animal
    {
        void FeedAnimal(T animal);
    }

    public class CatFeeder : IAnimalFeeder<Cat>
    {
        public void FeedAnimal(Cat animal)
        {
            Console.WriteLine($"Feeding cat: {animal.Name}");
            // Code to feed the cat
        }
    }

    public class DogFeeder : IAnimalFeeder<Dog>
    {
        public void FeedAnimal(Dog animal)
        {
            Console.WriteLine($"Feeding dog: {animal.Name}");
            // Code to feed the dog
        }
    }

    public abstract class Animal
    {
        public string Name { get; set; }
        public abstract void MakeSound();
    }
    public class Cat : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Meow!");
        }
    }
    public class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Woof!");
        }
    }
    public class Zoo<T> where T : Animal
    {
        private List<T> animals = new List<T>();

        public void AddAnimal(T animal)
        {
            animals.Add(animal);
        }

        public void AllAnimalsMakeSound()
        {
            foreach (T animal in animals)
            {
                animal.MakeSound();
            }
        }
    }
}
