namespace ListDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 1_000_000; i++)
            {
                Console.Clear();
                Console.WriteLine(DateTime.Now.ToLongTimeString());
                Thread.Sleep(1000);
            }
        }
    }
}
