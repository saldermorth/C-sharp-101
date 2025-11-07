// En enkel ordlista med svenska-engelska översättningar
public class SimpleTranslator
{
    // Använd en vanlig Dictionary för att lagra översättningarna
    private Dictionary<string, string> _translations = new Dictionary<string, string>();

    // Konstruktor som lägger till några grundläggande översättningar
    public SimpleTranslator()
    {
        // Lägg till några översättningar
        _translations.Add("hej", "hello");
        _translations.Add("hus", "house");
        _translations.Add("katt", "cat");
        _translations.Add("hund", "dog");
    }

    // Indexer - låter oss använda translator["ord"] syntax
    public string this[string swedishWord]
    {
        // När vi gör translator["hej"] körs denna get-metod
        get
        {
            // Kolla om ordet finns i vår ordlista
            if (_translations.ContainsKey(swedishWord))
            {
                return _translations[swedishWord];
            }
            else
            {
                // Om ordet inte finns, returnera ett meddelande
                return "Översättning saknas";
            }
        }

        // När vi gör translator["bil"] = "car" körs denna set-metod
        set
        {
            // Om ordet redan finns, uppdatera översättningen
            if (_translations.ContainsKey(swedishWord))
            {
                _translations[swedishWord] = value;
            }
            else
            {
                // Annars, lägg till en ny översättning
                _translations.Add(swedishWord, value);
            }
        }
    }

    // Metod för att visa alla översättningar
    public void ShowAllTranslations()
    {
        Console.WriteLine("Alla översättningar:");
        foreach (var pair in _translations)
        {
            Console.WriteLine($"  {pair.Key} = {pair.Value}");
        }
    }
}

// Så här använder du klassen
class Program
{
    static void Main()
    {
        // Skapa en ny translator
        SimpleTranslator translator = new SimpleTranslator();

        // Använd indexern för att hämta en översättning
        Console.WriteLine($"'hej' på engelska är '{translator["hej"]}'");

        // Använd indexern för att lägga till en ny översättning
        translator["bil"] = "car";

        // Uppdatera en befintlig översättning
        translator["katt"] = "kitty";

        // Visa alla översättningar
        translator.ShowAllTranslations();

        // Testa att hämta ett ord som inte finns
        Console.WriteLine($"'dator' på engelska är '{translator["dator"]}'");



        // Example use
        var list = new PokemonList(new[]
        {
           new Pokemon("Charmander"),
           new Pokemon("Pikachu"),
           new Pokemon("Bulbasaur")
        });

        Console.WriteLine(list[0].Name);
        Console.ReadLine();

    }
}
public class Pokemon
{
    public string Name { get; set; }
    public Pokemon(string name)
    {
        Name = name;
    }
}

/*An indexer in C# lets you make an object act like an array.
You can access elements using brackets [], but behind the scenes it runs code you define.
Make a class give in array like features
 */
public class PokemonList
{
    // array that we do not want to expose
    private readonly Pokemon[] pokemons;

    // we will instead let it be used like an array
    // we want an instanse of the Pokemon list be used to access an item stored in the array

    // this is a read-only indexer
    public Pokemon this[int index] => pokemons[index];
    // range indexer
    public Pokemon[] this[Range range] => pokemons[range];

    public PokemonList(Pokemon[] pokemons)
    {
        this.pokemons = pokemons;
    }
    // slice the array


    /*
     Use when:
   1.Use indexers only when they make semantic sense

Good example:

list[2] — for a collection that stores items by position

dictionary["Key"] — for something with unique keys

    2.Keep indexers simple and fast

Indexers should act like array access — no heavy logic, no database queries.
     


    When not to use:

    When not to use an indexer
Situation	Better Alternative
You’re performing a search or filter	Use a method (e.g., FindByName("Pikachu"))
You need to return multiple results	Use a method or property returning a collection
Access logic is complex or slow	Use named methods for clarity
It’s unclear what the “index” or “key” represents	Avoid indexers altogether


    Use indexers only when your class feels like a collection.
Otherwise, use methods — they’re more descriptive and safer.
     */

}