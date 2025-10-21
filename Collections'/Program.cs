using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericCollectionsDemos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Köra demo för varje collection typ
            Console.WriteLine("===== LIST DEMO =====");
            ListDemo();

            Console.WriteLine("\n===== DICTIONARY DEMO =====");
            DictionaryDemo();

            Console.WriteLine("\n===== HASHSET DEMO =====");
            HashSetDemo();

            Console.WriteLine("\n===== QUEUE DEMO =====");
            QueueDemo();

            Console.WriteLine("\n===== STACK DEMO =====");
            StackDemo();

            Console.WriteLine("\n===== LINKEDLIST DEMO =====");
            LinkedListDemo();

            Console.WriteLine("\n===== SORTEDLIST DEMO =====");
            SortedListDemo();

            Console.WriteLine("\n===== SORTEDDICTIONARY DEMO =====");
            SortedDictionaryDemo();

            Console.WriteLine("\n===== SORTEDHASHSET DEMO =====");
            SortedSetDemo();

            Console.WriteLine("\n===== CONCURRENTDICTIONARY DEMO =====");
            ConcurrentDictionaryDemo();

            Console.ReadKey();
        }

        static void ListDemo()
        {
            // List<T>: Dynamisk array med automatisk storleksförändring
            List<string> fruits = new List<string>();

            // Lägga till element
            fruits.Add("Äpple");
            fruits.Add("Banan");
            fruits.Add("Citron");
            fruits.AddRange(new[] { "Ananas", "Apelsin" });

            Console.WriteLine("List innehåller {0} element", fruits.Count);

            // Åtkomst via index
            Console.WriteLine("Element på index 1: " + fruits[1]);

            // Söka i en lista
            int index = fruits.IndexOf("Citron");
            Console.WriteLine("Citron finns på index: " + index);

            // Sortera listan
            fruits.Sort();
            Console.WriteLine("Sorterad lista: " + string.Join(", ", fruits));

            // Ta bort element
            fruits.Remove("Apelsin");
            fruits.RemoveAt(0); // Ta bort första elementet

            // Iterera genom listan
            Console.WriteLine("Kvarvarande frukter:");
            foreach (var fruit in fruits)
            {
                Console.WriteLine("- " + fruit);
            }

            // Lista med LINQ
            var filteredFruits = fruits.Where(f => f.StartsWith("A")).ToList();
            Console.WriteLine("Frukter som börjar med A: " + string.Join(", ", filteredFruits));
        }

        static void DictionaryDemo()
        {
            // Dictionary<TKey, TValue>: Nyckel-värde par med unika nycklar
            Dictionary<string, int> ages = new Dictionary<string, int>();

            // Lägga till nyckel-värde par
            ages.Add("Anna", 28);
            ages["Erik"] = 32; // Alternativt sätt att lägga till
            ages["Maria"] = 25;

            // Kontrollera om en nyckel existerar
            if (ages.ContainsKey("Erik"))
            {
                Console.WriteLine("Erik är {0} år gammal", ages["Erik"]);
            }

            // TryGetValue undviker KeyNotFoundException
            if (ages.TryGetValue("Johan", out int johansAge))
            {
                Console.WriteLine("Johan är {0} år gammal", johansAge);
            }
            else
            {
                Console.WriteLine("Johan finns inte i ordboken");
            }

            // Iterera genom nycklar och värden
            Console.WriteLine("Alla åldrar:");
            foreach (var pair in ages)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value} år");
            }

            // Få alla nycklar och värden
            var names = ages.Keys;
            var allAges = ages.Values;

            // Ta bort element
            ages.Remove("Maria");

            // Uppdatera värden
            ages["Erik"] = 33;
            Console.WriteLine("Erik har fyllt år och är nu {0}", ages["Erik"]);

            // Dictionary med LINQ
            var olderThan30 = ages.Where(pair => pair.Value > 30)
                                  .ToDictionary(pair => pair.Key, pair => pair.Value);
            Console.WriteLine("Personer över 30: " + string.Join(", ", olderThan30.Keys));
        }

        static void HashSetDemo()
        {
            // HashSet<T>: Unika element utan ordning
            HashSet<int> numbers = new HashSet<int> { 1, 2, 3, 4, 5 };
            HashSet<int> moreNumbers = new HashSet<int> { 4, 5, 6, 7, 8 };

            // Försök lägga till dubblett
            Console.WriteLine("Kunde lägga till 3: " + numbers.Add(3)); // False, finns redan
            Console.WriteLine("Kunde lägga till 10: " + numbers.Add(10)); // True

            // Mängdoperationer
            HashSet<int> union = new HashSet<int>(numbers);
            union.UnionWith(moreNumbers);
            Console.WriteLine("Union: " + string.Join(", ", union));

            HashSet<int> intersection = new HashSet<int>(numbers);
            intersection.IntersectWith(moreNumbers);
            Console.WriteLine("Snitt: " + string.Join(", ", intersection));

            HashSet<int> difference = new HashSet<int>(numbers);
            difference.ExceptWith(moreNumbers);
            Console.WriteLine("Skillnad (numbers - moreNumbers): " + string.Join(", ", difference));

            // Kontrollera delmängd
            Console.WriteLine("intersection är en delmängd av numbers: " + intersection.IsSubsetOf(numbers));

            // Kontrollera om element finns
            Console.WriteLine("Innehåller 5: " + numbers.Contains(5));
            Console.WriteLine("Innehåller 9: " + numbers.Contains(9));
        }

        static void QueueDemo()
        {
            // Queue<T>: FIFO (First In First Out) collection
            Queue<string> orderQueue = new Queue<string>();

            // Lägga till element (Enqueue)
            orderQueue.Enqueue("Order 1");
            orderQueue.Enqueue("Order 2");
            orderQueue.Enqueue("Order 3");

            Console.WriteLine("Antal ordrar i kö: " + orderQueue.Count);

            // Kolla nästa element utan att ta bort (Peek)
            Console.WriteLine("Nästa order att behandla: " + orderQueue.Peek());

            // Ta bort och returnera nästa element (Dequeue)
            string nextOrder = orderQueue.Dequeue();
            Console.WriteLine("Behandlar: " + nextOrder);

            // Kolla om element finns
            Console.WriteLine("Innehåller 'Order 2': " + orderQueue.Contains("Order 2"));

            // Iterera genom kön (utan att ta bort element)
            Console.WriteLine("Återstående ordrar:");
            foreach (var order in orderQueue)
            {
                Console.WriteLine("- " + order);
            }

            // Rensa kön
            orderQueue.Clear();
            Console.WriteLine("Efter Clear(): " + orderQueue.Count + " element");
        }

        static void StackDemo()
        {
            // Stack<T>: LIFO (Last In First Out) collection
            Stack<string> browserHistory = new Stack<string>();

            // Lägga till element (Push)
            browserHistory.Push("https://www.start.se");
            browserHistory.Push("https://www.search.se");
            browserHistory.Push("https://www.result.se");

            Console.WriteLine("Antal webbplatser i historiken: " + browserHistory.Count);

            // Kolla senaste element utan att ta bort (Peek)
            Console.WriteLine("Aktuell webbplats: " + browserHistory.Peek());

            // Ta bort och returnera senaste element (Pop)
            string currentPage = browserHistory.Pop();
            Console.WriteLine("Gick tillbaka från: " + currentPage);
            Console.WriteLine("Nu på: " + browserHistory.Peek());

            // Kolla om element finns
            Console.WriteLine("Har besökt start.se: " + browserHistory.Contains("https://www.start.se"));

            // Iterera genom stacken (utan att ta bort element)
            Console.WriteLine("Historik (i omvänd kronologisk ordning):");
            foreach (var url in browserHistory)
            {
                Console.WriteLine("- " + url);
            }

            // Rensa stacken
            browserHistory.Clear();
            Console.WriteLine("Efter Clear(): " + browserHistory.Count + " element");
        }

        static void LinkedListDemo()
        {
            // LinkedList<T>: Dubbellänkad lista
            LinkedList<string> playlist = new LinkedList<string>();

            // Lägga till element
            playlist.AddLast("Låt 1"); // Lägger till sist
            playlist.AddLast("Låt 3");

            // Skapa en nod och lägg till efter den
            LinkedListNode<string> song1Node = playlist.First;
            playlist.AddAfter(song1Node, "Låt 2");

            // Lägga till i början
            playlist.AddFirst("Låt 0");

            Console.WriteLine("Spellista har {0} låtar", playlist.Count);

            // Åtkomst till första och sista nod
            Console.WriteLine("Första låten: " + playlist.First.Value);
            Console.WriteLine("Sista låten: " + playlist.Last.Value);

            // Hitta en specifik nod
            LinkedListNode<string> song3Node = playlist.Find("Låt 3");
            if (song3Node != null)
            {
                // Lägg till före noden
                playlist.AddBefore(song3Node, "Låt 2.5");
            }

            // Ta bort en nod
            playlist.Remove("Låt 0");

            // Iterera framåt
            Console.WriteLine("Spellista (från början till slut):");
            for (var node = playlist.First; node != null; node = node.Next)
            {
                Console.WriteLine("- " + node.Value);
            }

            // Iterera bakåt
            Console.WriteLine("Spellista (från slut till början):");
            for (var node = playlist.Last; node != null; node = node.Previous)
            {
                Console.WriteLine("- " + node.Value);
            }
        }

        static void SortedListDemo()
        {
            // SortedList<TKey, TValue>: Sorterad nyckel-värde par
            SortedList<string, decimal> stockPrices = new SortedList<string, decimal>();

            // Lägga till element (sorteras automatiskt efter nyckel)
            stockPrices.Add("MSFT", 328.79m);
            stockPrices.Add("AAPL", 187.41m);
            stockPrices.Add("GOOG", 138.45m);
            stockPrices.Add("AMZN", 179.52m);

            Console.WriteLine("Aktier (sorterade alfabetiskt efter symbol):");
            foreach (var stock in stockPrices)
            {
                Console.WriteLine($"{stock.Key}: ${stock.Value}");
            }

            // Åtkomst via index
            Console.WriteLine("Första aktien: " + stockPrices.Keys[0] + " $" + stockPrices.Values[0]);

            // Åtkomst via nyckel
            Console.WriteLine("MSFT pris: $" + stockPrices["MSFT"]);

            // Hitta nyckelns index
            int index = stockPrices.IndexOfKey("AAPL");
            Console.WriteLine("AAPL är på index: " + index);

            // Ta bort via nyckel
            stockPrices.Remove("GOOG");

            // Ta bort via index
            if (stockPrices.Count > 0)
            {
                stockPrices.RemoveAt(0);
            }

            Console.WriteLine("Efter borttagning:");
            foreach (var stock in stockPrices)
            {
                Console.WriteLine($"{stock.Key}: ${stock.Value}");
            }
        }

        static void SortedDictionaryDemo()
        {
            // SortedDictionary<TKey, TValue>: Sorterad nyckel-värde par (träd-baserad)
            SortedDictionary<string, string> countries = new SortedDictionary<string, string>();

            // Lägga till element
            countries.Add("SE", "Sverige");
            countries.Add("NO", "Norge");
            countries.Add("FI", "Finland");
            countries.Add("DK", "Danmark");
            countries.Add("IS", "Island");

            Console.WriteLine("Nordiska länder (sorterade efter landskod):");
            foreach (var country in countries)
            {
                Console.WriteLine($"{country.Key}: {country.Value}");
            }

            // Kontrollera om en nyckel finns
            if (countries.ContainsKey("SE"))
            {
                Console.WriteLine("SE är: " + countries["SE"]);
            }

            // Försök hämta värde
            if (countries.TryGetValue("UK", out string ukName))
            {
                Console.WriteLine("UK är: " + ukName);
            }
            else
            {
                Console.WriteLine("UK finns inte i listan");
            }

            // Ta bort element
            countries.Remove("IS");

            Console.WriteLine("Efter borttagning av Island:");
            foreach (var country in countries)
            {
                Console.WriteLine($"{country.Key}: {country.Value}");
            }
        }

        static void SortedSetDemo()
        {
            // SortedSet<T>: Sorterad uppsättning med unika element
            SortedSet<int> sortedNumbers = new SortedSet<int> { 5, 1, 9, 3, 7, 4, 6, 8, 2 };

            Console.WriteLine("Sorterade nummer: " + string.Join(", ", sortedNumbers));

            // Lägga till element
            sortedNumbers.Add(0);
            sortedNumbers.Add(5); // Lägger inte till duplikat

            // Hitta min/max
            Console.WriteLine("Min: " + sortedNumbers.Min);
            Console.WriteLine("Max: " + sortedNumbers.Max);

            // Arbeta med intervall
            SortedSet<int> subset = sortedNumbers.GetViewBetween(3, 7);
            Console.WriteLine("Subset [3-7]: " + string.Join(", ", subset));

            // Ta bort intervall
            sortedNumbers.RemoveWhere(n => n >= 5 && n <= 8);
            Console.WriteLine("Efter borttagning av [5-8]: " + string.Join(", ", sortedNumbers));

            // Hitta element större än eller lika med
            if (sortedNumbers.TryGetValue(3, out int actualValue))
            {
                Console.WriteLine("Hittade: " + actualValue);
            }
        }

        static void ConcurrentDictionaryDemo()
        {
            // Notera: För att använda ConcurrentDictionary, lägg till:
            // using System.Collections.Concurrent;
            Console.WriteLine("ConcurrentDictionary är trådsäker och lämplig för samtidig åtkomst");
            Console.WriteLine("från flera trådar. Här är en förenklad demo utan faktisk samtidighet:");

            // Skapa en Dictionary för demo
            Dictionary<string, int> visitors = new Dictionary<string, int>();

            // Simulera GetOrAdd-operation
            string page = "home";
            if (!visitors.TryGetValue(page, out int count))
            {
                visitors[page] = 1;
            }
            else
            {
                visitors[page] = count + 1;
            }

            Console.WriteLine($"Sida: {page}, Besökare: {visitors[page]}");

            // Simulera AddOrUpdate-operation
            page = "about";
            if (!visitors.TryGetValue(page, out count))
            {
                visitors[page] = 1;
            }
            else
            {
                visitors[page] = count + 1;
            }

            Console.WriteLine($"Sida: {page}, Besökare: {visitors[page]}");

            Console.WriteLine("\nI en riktig ConcurrentDictionary skulle detta se ut som:");
            Console.WriteLine("visitors.GetOrAdd(page, key => 1);");
            Console.WriteLine("visitors.AddOrUpdate(page, 1, (key, oldValue) => oldValue + 1);");
        }
    }
}