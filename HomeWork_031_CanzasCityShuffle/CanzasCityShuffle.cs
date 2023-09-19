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

            Console.WriteLine("\nПеремешанный массив:");
            ShowArray(Shuffle(numbers));

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

        private static int[] Shuffle(int[] numbers)
        {
            Random random = new Random();
            int[] tempArray = new int[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
                tempArray[i] = numbers[i];

            for (int i = 0; i < tempArray.Length; i++)
            {
                int randomIndex = random.Next(tempArray.Length);
                (tempArray[i], tempArray[randomIndex]) = (tempArray[randomIndex], tempArray[i]);
            }

            return tempArray;
        }
    }
}