namespace QueueDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> köTillKassa = new Queue<string>();

            köTillKassa.Dequeue();//först i kön
            köTillKassa.Enqueue("Bob");
            köTillKassa.Enqueue("Charlie");
            köTillKassa.Enqueue("David");
            köTillKassa.Enqueue("Eric");
            köTillKassa.Enqueue("Fredrik"); //sist i kön

            //Annas tur i kassan
            string kund = köTillKassa.Dequeue();
            Console.WriteLine("Först i kassan: " + kund);

            //Vi tittar vem som står först i kön utan att släppa fram dem
            string nästaKund = köTillKassa.Peek();

            //Vi ropar upp David och ser om han finns i kön
            Console.WriteLine(köTillKassa.Contains("David"));

            //Hur många står i kön?
            Console.WriteLine(köTillKassa.Count);

            //Släpp fram en i taget
            foreach (var kundLängstFram in köTillKassa)
            {
                Console.WriteLine("Nästa!");
                Console.ReadLine();
                Console.WriteLine("Framme i kassan är " + kundLängstFram);
            }



        }
    }
}
