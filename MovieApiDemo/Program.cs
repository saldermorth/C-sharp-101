using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieInfoConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Write("Skriv filmens titel: ");
            string title = Console.ReadLine();

            // Byt ut här med din egen OMDb-API-nyckel
            string apiKey = "1626a87a";
            string url = $"https://www.omdbapi.com/?t={Uri.EscapeDataString(title)}&apikey={apiKey}&plot=short&r=json";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    string json = await response.Content.ReadAsStringAsync();

                    MovieResult result = JsonConvert.DeserializeObject<MovieResult>(json);

                    if (result != null && result.Response == "True")
                    {
                        Console.WriteLine($"Titel: {result.Title}");
                        Console.WriteLine($"År: {result.Year}");
                        Console.WriteLine($"Genre: {result.Genre}");
                        Console.WriteLine($"Regissör: {result.Director}");
                        Console.WriteLine($"Handling: {result.Plot}");
                    }
                    else
                    {
                        Console.WriteLine("Ingen film hittades eller fel inträffade.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fel vid hämtning: {ex.Message}");
                }
            }

            Console.WriteLine("Tryck på valfri tangent för att avsluta.");
            Console.ReadKey();
        }

        // Klass för att mappa JSON-svar
        public class MovieResult
        {
            [JsonProperty("Title")]
            public string Title { get; set; }

            [JsonProperty("Year")]
            public string Year { get; set; }

            [JsonProperty("Genre")]
            public string Genre { get; set; }

            [JsonProperty("Director")]
            public string Director { get; set; }

            [JsonProperty("Plot")]
            public string Plot { get; set; }

            [JsonProperty("Response")]
            public string Response { get; set; }
        }
    }
}
