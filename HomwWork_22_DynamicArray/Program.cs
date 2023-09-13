namespace HomeWork_22_DynamicArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandSum = "sum";
            const string CommandExit = "exit";

            int[] numberArray = new int[0];

            Console.WriteLine($"Введите число или одну из следующих команд:" +
                $"\n[{CommandSum}] - вывести сумму всех введенных чисел" +
                $"\n[{CommandExit}] - выйти из программы\n");

            Console.Write("Введите число или команду: ");
            string input = Console.ReadLine();

            while (input != CommandExit)
            {
                switch (input)
                {
                    case CommandSum:
                        int sumOfNumbers = 0;

                        foreach (var number in numberArray)
                        {
                            sumOfNumbers += number;
                        }

                        Console.WriteLine($"Сумма введенных чисел: {sumOfNumbers}");
                        break;

                    default:
                        int inputNumber = Convert.ToInt32(input);
                        int[] tempArray = new int[numberArray.Length + 1];

                        for (int i = 0; i < numberArray.Length; i++)
                        {
                            tempArray[i] = numberArray[i];
                        }

                        tempArray[tempArray.Length - 1] = inputNumber;
                        numberArray = tempArray;
                        break;
                }

                Console.Write("Введите число или команду: ");
                input = Console.ReadLine();
            }
        }
    }
}