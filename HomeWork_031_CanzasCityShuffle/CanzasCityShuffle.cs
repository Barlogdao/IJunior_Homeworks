namespace HomeWork_031_CanzasCityShuffle
{
    internal class CanzasCityShuffle
    {
        static void Main(string[] args)
        {
            int arraySize = 10;
            int maxRandomValue = 100;
            int[] numbers = GetNumberArray(arraySize, maxRandomValue);

            Console.WriteLine("Исходный массив:");
            ShowArray(numbers);

            Shuffle(numbers);

            Console.WriteLine("\nПеремешанный массив:");
            ShowArray(numbers);

            Console.ReadKey();
        }

        private static int[] GetNumberArray(int arraySize, int maxValue)
        {
            Random random = new Random();
            int[] numberArray = new int[arraySize];

            for (int i = 0; i < numberArray.Length; i++)
                numberArray[i] = random.Next(maxValue);

            return numberArray;
        }

        private static void ShowArray(int[] array)
        {
            foreach (int number in array)
                Console.Write(number + " ");
        }

        private static void Shuffle(int[] numbers)
        {
            Random random = new Random();

            for (int i = 0; i < numbers.Length; i++)
            {
                int randomIndex = random.Next(numbers.Length);
                (numbers[i], numbers[randomIndex]) = (numbers[randomIndex], numbers[i]);
            }
        }
    }
}