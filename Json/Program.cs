using System.Text.Json;

namespace Json
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Spara ett objekt
            //Console.WriteLine("Hello, World!");
            //var person = new Person ( "Anna", 25 );
            //var options = new JsonSerializerOptions { WriteIndented = true };
            //string json = JsonSerializer.Serialize(person, options);
            //File.WriteAllText("person.json", json);

            //Spara samling av objekt
            //    var personer = new List<Person>
            //{
            //    new Person ("Anna",  25 ),
            //    new Person ("Bob",  50 ),
            //    new Person ("Leon",  42 ),
            //    new Person ("Ester",  3 ),

            //};

            //    // Alternativ för formatering med indrag
            //    var options = new JsonSerializerOptions { WriteIndented = true };

            //    // Serialisera listan till JSON
            //    string json = JsonSerializer.Serialize(personer);

            //    // Spara till fil
            //    File.WriteAllText("personer.json", json);



            //Spara samling av nästade objekt
            // Skapa en lista med personer som har adresser (nästade objekt)
            var personer = new List<Person>
            {
                new Person("Anna", 25, new Address("Storgatan 1", "Stockholm")),
                new Person("Bob", 50, new Address("Lillgatan 12", "Göteborg")),
                new Person("Leon", 42, new Address("Brogatan 7", "Malmö")),
                new Person("Ester", 3, new Address("Solvägen 3", "Uppsala"))
            };

            // Alternativ för formatering med indrag
            var options = new JsonSerializerOptions { WriteIndented = true };

            // Serialisera listan till JSON
            string json = JsonSerializer.Serialize(personer, options);

            // Spara till fil
            File.WriteAllText("personer.json", json);

            Console.WriteLine("Listan med nästade objekt har serialiserats och sparats till personer.json");
        }


    }

    public class Person
    {
        public string Namn { get; set; }
        public int Age { get; set; }
        public Address Address { get; set; }

        public Person(string name, int age, Address address)
        {
            Namn = name;
            Age = age;
            Address = address;
        }
    }

    public class Address
    {
        public string Gata { get; set; }
        public string Stad { get; set; }

        public Address(string gata, string stad)
        {
            Gata = gata;
            Stad = stad;
        }
    }
}
//   public  class Person
//    {
//        public string Namn { get; set; }
//        public int Age { get; set; }
//        public Person(string name, int age)
//        {
//            Namn = name;
//            Age = age;
//        }
//    }
//}
