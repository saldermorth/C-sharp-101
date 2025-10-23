using System;


namespace Random_Minecraft

{

    class Program

    {

        static void Main(string[] args)

        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Advanced Minecraft-inspired 2D Terrain Generator");

            Console.WriteLine("===============================================");


            Random random = new Random();

            int width = 100;  // Width of our terrain

            int maxHeight = 25;  // Maximum height of our terrain


            // Generate and display the terrain

            char[,] terrain = GenerateTerrain(random, width, maxHeight);

            DisplayTerrain(terrain);


            Console.WriteLine("\nLegend:");

            Console.WriteLine("^ - Mountain peak");

            Console.WriteLine("▲ - Mountain");

            Console.WriteLine("● - Hill");

            Console.WriteLine("♠ - Tree");

            Console.WriteLine("░ - Grass");

            Console.WriteLine("▒ - Dirt");

            Console.WriteLine("▓ - Stone");

            Console.WriteLine("☼ - Ore");

            Console.WriteLine("≈ - Water");

            Console.WriteLine("□ - Cave");


            Console.WriteLine("\nPress any key to generate a new terrain...");

            while (Console.ReadKey(true).Key != ConsoleKey.Escape)

            {

                terrain = GenerateTerrain(random, width, maxHeight);

                DisplayTerrain(terrain);

            }

        }


        static char[,] GenerateTerrain(Random random, int width, int maxHeight)

        {

            char[,] terrain = new char[maxHeight, width];

            int[] heightMap = new int[width];

            int height = maxHeight / 2;


            // Generate height map

            for (int x = 0; x < width; x++)

            {

                height += random.Next(-1, 2);

                height = Math.Max(1, Math.Min(height, maxHeight - 1));

                heightMap[x] = height;


                // Add random peaks

                if (random.Next(20) == 0)

                {

                    heightMap[x] = Math.Min(height + random.Next(1, 5), maxHeight - 1);

                }

            }


            // Generate terrain based on height map

            for (int x = 0; x < width; x++)

            {

                for (int y = 0; y < maxHeight; y++)

                {

                    if (y > heightMap[x])

                    {

                        terrain[y, x] = ' '; // Air

                    }

                    else if (y == heightMap[x])

                    {

                        if (y > maxHeight * 0.7) terrain[y, x] = '^'; // Mountain peak

                        else if (y > maxHeight * 0.6) terrain[y, x] = '▲'; // Mountain

                        else if (y > maxHeight * 0.5) terrain[y, x] = '●'; // Hill

                        else if (random.Next(10) == 0) terrain[y, x] = '♠'; // Tree

                        else terrain[y, x] = '░'; // Grass

                    }

                    else if (y > heightMap[x] - 3)

                    {

                        terrain[y, x] = '▒'; // Dirt

                    }

                    else

                    {

                        terrain[y, x] = '▓'; // Stone

                    }

                }

            }


            // Add water

            int waterLevel = maxHeight / 3;

            for (int x = 0; x < width; x++)

            {

                for (int y = waterLevel; y < heightMap[x]; y++)

                {

                    terrain[y, x] = '≈';

                }

            }


            // Add caves and ore

            for (int i = 0; i < width * maxHeight / 50; i++)

            {

                int caveX = random.Next(width);

                int caveY = random.Next(waterLevel, maxHeight);

                GenerateCave(terrain, caveX, caveY, random);

            }


            return terrain;

        }


        static void GenerateCave(char[,] terrain, int startX, int startY, Random random)

        {

            int maxHeight = terrain.GetLength(0);

            int width = terrain.GetLength(1);

            int length = random.Next(5, 15);


            for (int i = 0; i < length; i++)

            {

                int x = (startX + i) % width;

                int y = Math.Min(Math.Max(startY + random.Next(-1, 2), 0), maxHeight - 1);


                if (terrain[y, x] != '≈' && terrain[y, x] != ' ')

                {

                    terrain[y, x] = '□'; // Cave


                    // Occasionally add ore

                    if (random.Next(10) == 0)

                    {

                        int oreX = Math.Min(Math.Max(x + random.Next(-1, 2), 0), width - 1);

                        int oreY = Math.Min(Math.Max(y + random.Next(-1, 2), 0), maxHeight - 1);

                        if (terrain[oreY, oreX] == '▓')

                        {

                            terrain[oreY, oreX] = '☼'; // Ore

                        }

                    }

                }

            }

        }


        static void DisplayTerrain(char[,] terrain)

        {

            Console.Clear();

            int maxHeight = terrain.GetLength(0);

            int width = terrain.GetLength(1);


            for (int y = 0; y < maxHeight; y++)

            {

                for (int x = 0; x < width; x++)

                {

                    Console.ForegroundColor = GetColorForTile(terrain[y, x]);

                    Console.Write(terrain[y, x]);

                }

                Console.WriteLine();

            }

            Console.ResetColor(); // Reset color after drawing

        }


        static ConsoleColor GetColorForTile(char tile)

        {

            switch (tile)

            {

                case '^':

                case '▲':

                    return ConsoleColor.DarkGray;

                case '●':

                    return ConsoleColor.DarkYellow;

                case '♠':

                    return ConsoleColor.Green;

                case '░':

                    return ConsoleColor.DarkGreen;

                case '▒':

                    return ConsoleColor.DarkRed;

                case '▓':

                    return ConsoleColor.Gray;

                case '☼':

                    return ConsoleColor.Yellow;

                case '≈':

                    return ConsoleColor.Blue;

                case '□':

                    return ConsoleColor.DarkMagenta;

                default:

                    return ConsoleColor.White;

            }

        }

    }

}