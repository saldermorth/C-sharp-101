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
    }
}