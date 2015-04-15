using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCiv.Model.World
{
    class CaveGeneration
    {
        public static string[] generateASCIIMap(int playerX, int playerY)
        {
            int iterations = 15;
            double openness = 0.3;
            double grass = 0.5;
            int sizeX = 30;
            int sizeY = 30;

            char FILL = 'u';
            char WALL = 'x';
            char FLOOR = ' ';
            char ROCK = 'b';
            char GRASS = 'w';

            List<char> WALKABLE = new List<char>();
            WALKABLE.Add(GRASS);
            WALKABLE.Add(FLOOR);

            // init
            StringBuilder[] grid = new StringBuilder[sizeY];
            for (int Y = 0; Y < sizeY; Y++)
            {
                grid[Y] = new StringBuilder();
                for (int X = 0; X < sizeX; X++)
                {
                    grid[Y].Append(FILL);
                }
            }
            grid[playerY][playerX] = FLOOR;

            // expand the cave
            for (int i = 0; i < iterations; i++)
            {
                for (int Y = 2; Y < sizeY-2; Y++)
                {
                    for (int X = 2; X < sizeX-2; X++)
                    {
                        if (nextTo(grid, X, Y, WALKABLE, false) > 0 && Mechanics.random.NextDouble() < openness)
                        {
                            if (Mechanics.random.NextDouble() < grass)
                            {
                                grid[Y][X] = GRASS;
                            }
                            else
                            {
                                grid[Y][X] = FLOOR;
                            }
                        }
                    }
                }
            }

            // set walls
            bool change = true;
            List<char> FILLLIST = new List<char>();
            FILLLIST.Add(FILL);
            while (change)
            {
                change = false;
                string[] oldGrid = toStringArray(grid);
                for (int Y = 1; Y < sizeY-1; Y++)
                {
                    for (int X = 1; X < sizeX-1; X++)
                    {
                        if (oldGrid[Y][X] == FILL)
                        {
                            if (nextTo(oldGrid, X, Y, WALKABLE, true) > 0)
                            {
                                grid[Y][X] = WALL;
                                change = true;
                            }
                        }
                        if (oldGrid[Y][X] == WALL && nextTo(oldGrid, X, Y, FILLLIST, true) == 0)
                        {
                            grid[Y][X] = ROCK;
                            change = true;
                        }
                    }
                }
            }
            return toStringArray(grid);
        }

        private static int nextTo(StringBuilder[] grid, int x, int y, List<char> charlist, bool corners)
        {
            return nextTo(toStringArray(grid), x, y, charlist, corners);
        }

        private static int nextTo(string[] grid, int x, int y, List<char> charlist, bool corners)
        {
            int num = 0;

            if (charlist.Contains(grid[y-1][x]))
            {
                num += 1;
            }
            if (charlist.Contains(grid[y+1][x]))
            {
                num += 1;
            }
            if (charlist.Contains(grid[y][x-1]))
            {
                num += 1;
            }
            if (charlist.Contains(grid[y][x+1]))
            {
                num += 1;
            }
            if (corners)
            {
                if (charlist.Contains(grid[y-1][x-1]))
                {
                    num += 1;
                }
                if (charlist.Contains(grid[y+1][x+1]))
                {
                    num += 1;
                }
                if (charlist.Contains(grid[y+1][x-1]))
                {
                    num += 1;
                }
                if (charlist.Contains(grid[y-1][x+1]))
                {
                    num += 1;
                }
            }
            return num;
        }

        private static string[] toStringArray(StringBuilder[] grid)
        {
            string[] stringarr = new string[grid.GetLength(0)];
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                stringarr[i] = grid[i].ToString();
            }
            return stringarr;
        }

        private static void debugPrint(StringBuilder[] grid)
        {
            Console.WriteLine();
            string[] printarr = toStringArray(grid);
            for (int Y = 0; Y < printarr.GetLength(0); Y++)
            {
                for (int X = 0; X < printarr[0].Length; X++)
                {
                    Console.Write(printarr[Y][X]);
                }
                Console.WriteLine();
            }
        }

    }
}
