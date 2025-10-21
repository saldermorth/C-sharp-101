namespace ListDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Skapa listor

            List<int> list = new List<int>();

            List<string> list2 = new();


            //Lägg till objekt

            list.Add(1);


            //Lägg till en miljon objekt

            for (int i = 1; i < 1_000_000; i++)

            {

                list.Add(i);

            }


            //Skriv ut index 800000

            Console.WriteLine(list.ElementAt(800_000));


            //Sortera fallande

            list.Reverse();


            //Skriv ut igen

            Console.WriteLine(list.ElementAt(800_000));


            //Sortera

            list.Sort();


            //Ta bort element - Elementet tas bort och alla element efter "hoppar till vänster"

            list.RemoveAt(800_000);

            Console.WriteLine(list.ElementAt(800_000));


            //Antalet objekt

            Console.WriteLine(list.Count);


            //Använd med foreach

            foreach (var item in list)

            {

                Console.WriteLine("NR: " + item);

            }
            Console.WriteLine();
        }
    }
}
