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
            if (percentValue < 0 || percentValue > 100)
            {
                Console.WriteLine("Указано недопустимое значение!");
                return;
            }

            int currentValue = Convert.ToInt32(MathF.Ceiling(maxValue * percentValue/100));

            ConsoleColor originColor = Console.BackgroundColor;

            Console.SetCursorPosition(0, position);
            Console.Write("[");

            Console.BackgroundColor = color;

            for (int i = 0; i < currentValue; i++)
            {
                Console.Write(filledSymbol);
            }

            Console.BackgroundColor = originColor;

            for (int i = currentValue; i < maxValue; i++)
            {
                Console.Write(emptySymbol);
            }

            Console.Write("]\n");
        }
    }
}