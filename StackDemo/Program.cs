namespace StackDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Skapa en stack
            Stack<string> stack = new Stack<string>();

            // Lägga till element (Push - "lägg på toppen")
            stack.Push("Första tallriken");
            stack.Push("Andra tallriken");
            stack.Push("Tredje tallriken");

            // Ta ut element (Pop - "ta från toppen")
            string översta = stack.Pop();  // "Tredje tallriken"
            Console.WriteLine($"Tog: {översta}");

            // Kika på översta utan att ta bort (Peek)
            string nästaÖversta = stack.Peek();  // "Andra tallriken" (tas inte bort)
            Console.WriteLine($"Nästa översta: {nästaÖversta}");


        }
    }
}
