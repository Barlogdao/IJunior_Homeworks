namespace HomeWork_034_DynamicArrayV2
{
    internal class DynamicArrayV2
    {
        static void Main(string[] args)
        {
            const string CommandSum = "sum";
            const string CommandExit = "exit";

            List<int> numberList = new();
            bool exitRequested = false;

            Console.WriteLine($"Введите число или одну из следующих команд:" +
                $"\n[{CommandSum}] - вывести сумму всех введенных чисел" +
                $"\n[{CommandExit}] - выйти из программы\n");

            while (exitRequested == false)
            {
                Console.Write("Введите число или команду: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case CommandSum:
                        ShowSum(numberList);
                        break;

                    case CommandExit:
                        exitRequested = true;
                        break;

                    default:
                        TryAddNumber(input, numberList);
                        break;
                }
            }
        }

        private static void ShowSum(IEnumerable<int> numberList)
        {
            int sumOfNumbers = 0;

            foreach (var number in numberList)
            {
                sumOfNumbers += number;
            }

            Console.WriteLine($"Сумма введенных чисел: {sumOfNumbers}");
        }

        private static void TryAddNumber(string input, List<int> numberList)
        {
            if (int.TryParse(input, out int inputNumber))
            {
                numberList.Add(inputNumber);
                Console.WriteLine($"Число {inputNumber} добавлено.");
            }
            else
            {
                Console.WriteLine("Введено некорректное число!");
            }
        }
    }
}