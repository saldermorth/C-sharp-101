namespace Demos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
    public interface IVehicle
    {
        void Start();
        int MaxSpeed { get; }
    }

    class car : IVehicle
    {
        public int MaxSpeed => throw new NotImplementedException();

        public void Start()
        {
            throw new NotImplementedException();
        }
    }
}
