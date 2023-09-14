using System.IO;

namespace HomeWork_30_BraveNewWorld
{
    internal class BraveNewWorld
    {
        static void Main(string[] args)
        {
            char empty = ' ';
            char wall = '#';
            char water = '~';
            char[] obstacles = { wall, water };
            char[,] map =
            {
                {wall,  wall,   wall,   wall,   wall,   wall,   wall,   wall,   wall,  wall,  wall,  wall,   wall},
                {wall,  empty,  empty,  empty,  empty,  empty,  empty,  empty,  empty, empty, empty, empty,  wall},
                {wall,  empty,  empty,  empty,  empty,  empty,  empty,  empty,  empty, empty, empty, empty,  wall},
                {wall,  empty,  empty,  empty,  empty,  empty,  empty,  empty,  empty, empty, empty, empty,  wall},
                {wall,  water,  water,  water,  empty,  water,  water,  water,  water, water, water, water,  wall},
                {wall,  empty,  empty,  empty,  empty,  empty,  empty,  empty,  empty, empty, empty, empty,  wall},
                {wall,  empty,  empty,  empty,  empty,  empty,  empty,  empty,  empty, empty, empty, empty,  wall},
                {wall,  empty,  empty,  empty,  empty,  empty,  empty,  empty,  empty, empty, empty, empty,  wall},
                {wall,  empty,  empty,  empty,  empty,  empty,  empty,  empty,  empty, empty, empty, empty,  wall},
                {wall,  wall,   wall,   wall,   wall,   wall,   wall,   wall,   wall,  wall,  wall,  wall,   wall}
            };

            char crate = '*';
            int crateX = 4;
            int crateY = 4;

            char hero = '&';
            int heroX = 1;
            int heroY = 1;

            ConsoleKey pressedKey;
            Console.CursorVisible = false;

            while (true)
            {
                DrawMap(map, wall, water, empty);
                DrawHero(hero, ref heroX, ref heroY);
                DrawCrate(crate, ref crateX, ref crateY);

                pressedKey = Console.ReadKey().Key;
                HandleInput(pressedKey, map, obstacles, ref heroX, ref heroY);

                Console.Clear();
            }
        }

        private static void DrawHero(char hero, ref int heroX, ref int heroY)
        {
            Console.SetCursorPosition(heroX, heroY);
            Console.Write(hero);
        }

        private static void DrawCrate(char crate, ref int crateX, ref int crateY)
        {
            Console.SetCursorPosition(crateX, crateY);
            Console.Write(crate);
        }

        private static void HandleInput(ConsoleKey pressedKey, char[,] map, char[] obstacles, ref int heroX, ref int heroY)
        {
            int[] direction = GetDirection(pressedKey);
            int nextHeroPositionX = heroX + direction[0];
            int nextHeroPositionY = heroY + direction[1];

            if (IsAvailablePosition(nextHeroPositionX, nextHeroPositionY, map, obstacles))
            {
                heroX = nextHeroPositionX;
                heroY = nextHeroPositionY;
            }
        }

        private static int[] GetDirection(ConsoleKey pressedKey)
        {
            int[] direction = { 0, 0 };

            if (pressedKey == ConsoleKey.LeftArrow)
                direction[0] = -1;
            else if (pressedKey == ConsoleKey.RightArrow)
                direction[0] = 1;
            else if (pressedKey == ConsoleKey.UpArrow)
                direction[1] = -1;
            else if (pressedKey == ConsoleKey.DownArrow)
                direction[1] = 1;

            return direction;
        }

        private static bool IsAvailablePosition(int x, int y, char[,] map, char[] obstacles)
        {
            foreach (char obstacle in obstacles)
            {
                if (map[y, x] == obstacle)
                    return false;
            }

            return true;
        }

        private static void DrawMap(char[,] map, char wall, char water, char empty)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    DrawElement(map[i, j], wall, water, empty);
                }

                Console.WriteLine();
            }
        }
        private static void DrawElement(char element, char wall, char water, char empty)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            if (element == wall)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(wall);
            }
            else if (element == water)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(water);
            }
            else
            {
                Console.Write(empty);
            }
            Console.ForegroundColor = defaultColor;
        }
        //private static char[,] ReadMap(string fileName)
        //{
        //    string[] file = File.ReadAllLines($"{fileName}.txt");
        //    char[,] map = new char[file.Length, file[0].Length];

        //    for (int i = 0; i < map.GetLength(0); i++)
        //        for (int j = 0; j < map.GetLength(1); j++)
        //            map[i, j] = file[i][j];

        //    return map;
        //}
    }
}