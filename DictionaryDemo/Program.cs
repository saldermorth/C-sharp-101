namespace DictionaryDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
              //Skapa dictionarys
 Dictionary<string, int> map = new Dictionary<string, int>();
            Dictionary<string, int> kontakter = new();

            //Lägg till objekt
            kontakter.Add("Bob", 555555);
            kontakter.Add("Charlie", 666666);
            kontakter.Add("David", 777777);
            kontakter.Add("Eric", 888888);
            //kontakter.Add("Eric", 888888); Inte tillåter med dubletter

            //Finns nyckeln
            Console.WriteLine(kontakter.ContainsKey("Bob"));

            //Skriv ut värde
            int value = 0;
            kontakter.TryGetValue("Bob", out value);
            Console.WriteLine("Bobs cellphone is: " + value);

            //Ta bort
            kontakter.Remove("Bob");
            Console.WriteLine(kontakter.ContainsKey("Bob")); // false

            //Skriva ut nycklar eller värden         
            foreach (var namnen in kontakter.Keys)
            {
                Console.WriteLine(namnen);
            }

            foreach (var nummer in kontakter.Values)
            {
                Console.WriteLine(nummer);
            }



        }
    }
}
