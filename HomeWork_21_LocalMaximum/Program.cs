namespace HomeWork_21_LocalMaximum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int maxRandomValue = 100;
            int arraySize = 30;
            int[] numbers = new int[arraySize];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(maxRandomValue);
            }

            if (numbers.Length == 1)
            {
                Console.WriteLine("Невозможно определить локальный максимум, так как массив состоит из одного элемента. Один элемент не имеет соседей.");
                return;
            }

            if (numbers[0] > numbers[1])
            {
                Console.Write(numbers[0] + " ");
            }

            for (int i = 1; i < numbers.Length - 1; i++)
            {
                if (numbers[i] > numbers[i + 1] && numbers[i] > numbers[i - 1])
                {
                    Console.Write(numbers[i] + " ");
                }
            }

            if (numbers[^1] > numbers[^2])
            {
                Console.Write(numbers[^1] + " ");
            }
        }
    }
}