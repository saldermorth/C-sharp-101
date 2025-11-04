using System.Text.Json;

namespace JsonTest
{
    class Car
    {
        public string Make { get; set; }
        public string Modell { get; set; }
  

        public Car(string make, string modell)
        {
            Make = make;
            Modell = modell;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car("Volvo", "V90");
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(car, options);

            File.WriteAllText("jsontest.json", json);

            List<Car> cars = new List<Car>()
            {
                new Car("Volvo", "V70"),
                new Car("Toyota", "Yaris"),
                new Car("Audi", "A4")
            };


        }
    }
}