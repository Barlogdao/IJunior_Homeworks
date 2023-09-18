namespace HomeWork_30_BraveNewWorld
{
    internal class BraveNewWorld
    {
        static void Main(string[] args)
        {
            char wall;
            char water;
            char finish;
            char[,] map = ReadMap(out wall, out water, out finish);
            char[] obstacles = { wall, water };

            char hero = '&';
            int heroPositionX = 1;
            int heroPositionY = 1;

            char crate = '*';
            int cratePositionX = 10;
            int cratePositionY = 2;

            int messagePositionX = 1;
            int messagePositionY = map.GetLength(0) + 1;
            bool isFinish = false;

            Console.CursorVisible = false;

            while (isFinish == false)
            {
                Console.Clear();
                DrawMap(map, wall, water);
                DrawHero(hero, heroPositionX, heroPositionY);
                DrawCrate(crate, cratePositionX, cratePositionY);

                isFinish = CheckWinCondition(map, cratePositionX, cratePositionY, finish);
                SetMessage(messagePositionX, messagePositionY, isFinish, crate, finish);

                if (isFinish == false)
                {
                    ConsoleKey pressedKey = Console.ReadKey().Key;
                    HandleInput(pressedKey, map, obstacles, ref heroPositionX, ref heroPositionY, ref cratePositionX, ref cratePositionY);
                }
            }

            Console.ReadKey();
        }

        private static void HandleInput(ConsoleKey pressedKey, char[,] map, char[] obstacles, ref int heroPositionX, ref int heroPositionY, ref int cratePositionX, ref int cratePositionY)
        {
            int[] direction = GetDirection(pressedKey);

            int nextHeroPositionX = heroPositionX + direction[0];
            int nextHeroPositionY = heroPositionY + direction[1];

            if (IsObstacleAtPosition(nextHeroPositionX, nextHeroPositionY, map, obstacles))
            {
                return;
            }
            else if (IsCrateAtPosition(nextHeroPositionX, nextHeroPositionY, cratePositionX, cratePositionY))
            {
                if (TryMoveCrate(map, obstacles, direction, ref cratePositionX, ref cratePositionY) == false)
                {
                    return;
                }
            }

            MoveEntitity(direction, ref heroPositionX, ref heroPositionY);
        }

        private static int[] GetDirection(ConsoleKey pressedKey)
        {
            const ConsoleKey LeftKey = ConsoleKey.LeftArrow;
            const ConsoleKey RightKey = ConsoleKey.RightArrow;
            const ConsoleKey UpKey = ConsoleKey.UpArrow;
            const ConsoleKey DownKey = ConsoleKey.DownArrow;

            int[] direction = { 0, 0 };

            switch (pressedKey)
            {
                case LeftKey:
                    direction[0] = -1;
                    break;

                case RightKey:
                    direction[0] = 1;
                    break;

                case UpKey:
                    direction[1] = -1;
                    break;

                case DownKey:
                    direction[1] = 1;
                    break;

                default:
                    break;
            }

            return direction;
        }

        private static bool IsObstacleAtPosition(int positionX, int positionY, char[,] map, char[] obstacles)
        {
            foreach (char obstacle in obstacles)
            {
                if (map[positionY, positionX] == obstacle)
                    return true;
            }

            return false;
        }

        private static bool IsCrateAtPosition(int positionX, int postionY, int cratePositionX, int cratePositionY)
        {
            return (positionX == cratePositionX && postionY == cratePositionY);
        }

        private static bool TryMoveCrate(char[,] map, char[] obstacles, int[] direction, ref int cratePositionX, ref int cratePositionY)
        {
            int nextCratePositionX = cratePositionX + direction[0];
            int nextCratePositionY = cratePositionY + direction[1];

            if (IsObstacleAtPosition(nextCratePositionX, nextCratePositionY, map, obstacles))
            {
                return false;
            }

            MoveEntitity(direction, ref cratePositionX, ref cratePositionY);
            return true;
        }

        private static void MoveEntitity(int[] direction, ref int entityPositionX, ref int entityPositionY)
        {
            entityPositionX += direction[0];
            entityPositionY += direction[1];
        }

        private static bool CheckWinCondition(char[,] map, int cratePositionX, int cratePositionY, char finish)
        {
            return map[cratePositionY, cratePositionX] == finish ? true : false;
        }

        private static void SetMessage(int positionX, int positionY, bool isFinish, char crate, char finish)
        {
            Console.SetCursorPosition(positionX, positionY);

            if (isFinish == false)
            {
                Console.Write($"Дотолкай {crate} до {finish}!");
            }
            else
            {
                Console.Write("ПОБЕДА!");
            }
        }

        private static void DrawMap(char[,] map, char wall, char water)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    DrawElement(map[i, j], wall, water);
                }

                Console.WriteLine();
            }
        }

        private static void DrawElement(char element, char wall, char water)
        {
            if (element == wall)
            {
                DrawColoredSymbol(wall, ConsoleColor.Red);
            }
            else if (element == water)
            {
                DrawColoredSymbol(water, ConsoleColor.Blue);
            }
            else
            {
                Console.Write(element);
            }
        }

        private static void DrawColoredSymbol(char symbol, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(symbol);
            Console.ResetColor();
        }

        private static void DrawHero(char hero, int heroPositionX, int heroPositionY)
        {
            Console.SetCursorPosition(heroPositionX, heroPositionY);
            DrawColoredSymbol(hero, ConsoleColor.Green);
        }

        private static void DrawCrate(char crate, int cratePositionX, int cratePositionY)
        {
            Console.SetCursorPosition(cratePositionX, cratePositionY);
            DrawColoredSymbol(crate, ConsoleColor.Yellow);
        }

        private static char[,] ReadMap(out char wall, out char water, out char finish)
        {
            wall = '#';
            water = '~';
            finish = '@';
            char empty = ' ';

            char[,] map =
            {
                {wall,  wall,   wall,   wall,   wall,   wall,   wall,   wall,   wall,  wall,  wall,  wall,  wall,  wall,  wall,  wall,  wall,   wall},
                {wall,  empty,  empty,  wall,   empty,  empty,  empty,  empty,  empty, empty, empty, empty, empty, empty, empty, empty, empty,  wall},
                {wall,  empty,  empty,  empty,  empty,  empty,  empty,  empty,  empty, empty, empty, empty, empty, empty, empty, empty, empty,  wall},
                {wall,  empty,  empty,  wall,   empty,  empty,  empty,  empty,  empty, empty, empty, empty, empty, empty, empty, empty, empty,  wall},
                {wall,  water,  water,  water,  empty,  water,  water,  water,  water, water, water, water, water, water, water, water, water,  wall},
                {wall,  empty,  empty,  empty,  empty,  empty,  empty,  empty,  empty, empty, wall,  empty, empty, empty, empty, empty, empty,  wall},
                {wall,  empty,  empty,  empty,  empty,  empty,  empty,  empty,  empty, empty, empty, empty, empty, empty, empty, empty, empty,  wall},
                {wall,  empty,  empty,  empty,  empty,  empty,  empty,  empty,  empty, empty, wall,  empty, empty, empty, empty, empty, empty,  wall},
                {wall,  empty,  empty,  wall,   empty,  empty,  empty,  empty,  empty, empty, empty, empty, empty, empty, empty, empty, empty,  wall},
                {wall,  water,  water,  water,  water,  water,  water,  water,  water, water, water, water, water, water, water, empty, water,  wall},
                {wall,  wall,   empty,  empty,  empty,  empty,  empty,  empty,  empty, empty, empty, empty, empty, empty, empty, empty, empty,  wall},
                {wall,  finish, empty,  empty,  empty,  empty,  empty,  empty,  empty, empty, empty, empty, empty, empty, empty, empty, empty,  wall},
                {wall,  wall,   empty,  empty,  empty,  empty,  empty,  empty,  empty, empty, empty, empty, empty, empty, empty, empty, empty,  wall},
                {wall,  wall,   wall,   wall,   wall,   wall,   wall,   wall,   wall,  wall,  wall,  wall,  wall,  wall,  wall,  wall,  wall,   wall}
            };

            return map;
        }
    }
}