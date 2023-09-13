namespace HomeWork_26_ShiftValue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int arraySize = 13;
            int maxRandomValue = 10;
            int[] numbers = new int[arraySize];

            Console.WriteLine("Исходный массив: ");

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(maxRandomValue);
                Console.Write(numbers[i] + " ");
            }

            Console.Write("\nВведите количество смещений элементов массива влево: ");
            int shiftCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < shiftCount; i++)
            {
                for (int j = 0; j<numbers.Length-1; j++)
                {
                    (numbers[j], numbers[j + 1]) = (numbers[j + 1], numbers[j]);
                }
            }

            Console.WriteLine("\nСдвинутый массив: ");

            foreach (int number in numbers)
            {
                Console.Write(number + " ");
            }
        }
    }
}