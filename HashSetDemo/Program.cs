namespace HashSetDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            HashSet<string> artikelTags = new HashSet<string>();

            // Lägg till taggar (inga dubletter)
            artikelTags.Add("programmering");
            artikelTags.Add("csharp");
            artikelTags.Add("tutorial");
            artikelTags.Add("csharp");        // Läggs inte till igen
            artikelTags.Add("generics");

            Console.WriteLine("Artikelns taggar:");
            foreach (string tag in artikelTags)
            {
                Console.WriteLine($"#{tag}");
            }

            // Lägg till taggar från en lista (kan innehålla dubletter)
            List<string> nyaTaggar = new List<string>
            { "tutorial", "beginner", "programming", "csharp" };
            artikelTags.UnionWith(nyaTaggar);

            Console.WriteLine($"\nTotalt antal unika taggar: {artikelTags.Count}");


        }
    }
}
