namespace HomeWork_23_RepeatingSubArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int maxRandomValue = 5;
            int arraySize = 30;
            int[] numbers = new int[arraySize];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(maxRandomValue);
                Console.Write(numbers[i] + " ");
            }

            int mostRepeatingNumber = 0;
            int repeatCount = 1;
            int currentRepeatCount = 1;

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] == numbers[i - 1])
                {
                    currentRepeatCount++;

                    if (currentRepeatCount > repeatCount)
                    {
                        repeatCount = currentRepeatCount;
                        mostRepeatingNumber = numbers[i];
                    }
                }
                else
                {
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
