namespace HomeWork_23_RepeatingSubArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int maxRandomValue = 10;
            int arraySize = 30;
            int[] numbers = new int[arraySize];
            int mostRepeatingNumber = 0;
            int repeatCount = 1;
            int currentRepeatCount = 1;

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(maxRandomValue);
                Console.Write(numbers[i] + " ");
            }

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] == numbers[i - 1])
                {
                    currentRepeatCount++;
                }
                else if (repeatCount < currentRepeatCount)
                {
                    mostRepeatingNumber = numbers[i - 1];
                    repeatCount = currentRepeatCount;
                    currentRepeatCount = 1;
                }
            }

            if (repeatCount > 1)
                Console.WriteLine($"\nЧисло {mostRepeatingNumber} повторяется {repeatCount} раз подряд");
            else
                Console.WriteLine("\nВ массиве нет повторяющихся подряд чисел");
        }
    }
}
