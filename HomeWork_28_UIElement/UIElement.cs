namespace HomeWork_28_UIElement
{
    internal class UIElement
    {
        static void Main(string[] args)
        {
            const ConsoleKey CommandUpdateUI = ConsoleKey.Enter;

            float currentHealtPercent = 100f;
            int maxHealth = 10;
            ConsoleColor healthColor = ConsoleColor.Green;
            int healthPosition = 0;

            float currentManaPercent = 100f;
            int maxMana = 10;
            ConsoleColor manaColor = ConsoleColor.Blue;
            int manaPosition = 1;

            char emptyBarSymbol = '_';
            char filledBarSybol = '#';
            ConsoleKey inputKey = CommandUpdateUI;

            while (inputKey == CommandUpdateUI)
            {
                DrawBar(currentHealtPercent, maxHealth, healthColor, healthPosition, emptyBarSymbol, filledBarSybol);
                DrawBar(currentManaPercent, maxMana, manaColor, manaPosition, emptyBarSymbol, filledBarSybol);

                Console.Write("Введите процент текущего здоровья: ");
                currentHealtPercent = Convert.ToSingle(Console.ReadLine());

                Console.Write("Введите процент текущей маны: ");
                currentManaPercent = Convert.ToSingle(Console.ReadLine());

                Console.Write($"Нажмите {CommandUpdateUI} для обновления интерфейса. \nДля выхода из программы нажмите любую другую клавишу. ");
                inputKey = Console.ReadKey().Key;
                Console.Clear();
            }
        }

        private static void DrawBar(float percentValue, int maxValue, ConsoleColor color, int position, char emptySymbol, char filledSymbol)
        {
            int maxPercent = 100;

            if (percentValue < 0 || percentValue > maxPercent)
            {
                Console.WriteLine("Указано недопустимое значение!");
                return;
            }

            int currentValue = Convert.ToInt32(MathF.Ceiling(maxValue * percentValue / maxPercent));

            ConsoleColor originColor = Console.BackgroundColor;

            Console.SetCursorPosition(0, position);
            Console.Write("[");

            Console.BackgroundColor = color;
            DrawSymbol(currentValue, filledSymbol);

            Console.BackgroundColor = originColor;
            DrawSymbol(maxValue - currentValue, emptySymbol);

            Console.Write("]\n");
        }

        private static void DrawSymbol(int symbolAmount, char symbol)
        {
            for (int i = 0; i < symbolAmount; i++)
            {
                Console.Write(symbol);
            }
        }
    }
}