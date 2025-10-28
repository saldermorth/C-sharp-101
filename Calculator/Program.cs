namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

    }
    public class Calculator
    {
        public int Add(int a, int b, int c) => a + b + c;

        public int Multiply(int a, int b) => a * b;

        public bool IsEven(int number) => number % 2 == 0;

        public string Greet(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return "Hello, stranger";

            return $"Hello, {name}";
        }

        public int Max(int a, int b) => a > b ? a : b;
    }
}
