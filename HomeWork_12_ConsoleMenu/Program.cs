namespace HomeWork_12_ConsoleMenu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandKilometersToMiles = "1";
            const string CommandDayMode = "2";
            const string CommandDefaultMode = "3";
            const string CommandPalindromCheck = "4";
            const string CommandCapsLockCheck = "5";
            const string CommandExit = "0";

            while (true)
            {
                Console.WriteLine("\nВыберите команду:" +
                    $"\n [{CommandKilometersToMiles}] - перевести километры в мили" +
                    $"\n [{CommandDayMode}] - установить дневной режим консоли" +
                    $"\n [{CommandDefaultMode}] - установить стандартный режим консоли" +
                    $"\n [{CommandPalindromCheck}] - проверит слово на палиндром" +
                    $"\n [{CommandCapsLockCheck}] - проверить состояние CapsLock" +
                    $"\n [{CommandExit}] - выход");

                Console.Write("Введите команду: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case CommandKilometersToMiles:
                        float kilometersToMilesRatio = 0.621f;

                        Console.Write("Ввыедите количество километров: ");
                        float kilometersAmount = float.Parse(Console.ReadLine());

                        Console.WriteLine($"{kilometersAmount} километров это {kilometersAmount * kilometersToMilesRatio} миль");
                        break;

                    case CommandDayMode:
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Clear();
                        break;

                    case CommandDefaultMode:
                        Console.ResetColor();
                        Console.Clear();
                        break;

                    case CommandPalindromCheck:
                        Console.Write("Введите слово: ");
                        string word = Console.ReadLine().ToLower();

                        string reversedWord = "";

                        for (int i = word.Length-1; i >= 0; i--)
                        {
                           reversedWord += word[i];
                        }

                        if (word == reversedWord)
                            Console.WriteLine("Это палиндром");
                        else
                            Console.WriteLine("Это не палиндром");

                        break;


                    case CommandCapsLockCheck:

                        if (Console.CapsLock)
                            Console.WriteLine("CapsLock включен");
                        else
                            Console.WriteLine("CapsLock выключен");

                        break;

                    case CommandExit:
                        return;

                    default:
                        Console.WriteLine("Невреная команда!");
                        break;
                }
            }
        }
    }
}