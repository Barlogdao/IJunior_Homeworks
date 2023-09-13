namespace HomeWork_20_MaxElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int maxRandom = 100;
            int[,] matrix = new int[10, 10];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(maxRandom);
                }
            }

            int maxValue = int.MinValue;
            int valueForReplace = 0;

            foreach (int value in matrix)
            {
                if (maxValue < value)
                    maxValue = value;
            }

            Console.WriteLine($"Наибольший элемент: {maxValue}");
            Console.WriteLine("\n" + "Начальная матрица матрица:");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }

                Console.Write("\n");
            }

            Console.WriteLine("\n" + "Итоговая матрица:");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (maxValue == matrix[i, j])
                        matrix[i, j] = valueForReplace;

                    Console.Write(matrix[i, j] + "\t");
                }

                Console.Write("\n");
            }
        }
    }
}
