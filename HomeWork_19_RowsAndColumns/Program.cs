namespace HomeWork_19_RowsAndColumns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int maxValue = 10;
            int minRowsAmount = 2;
            int[,] table = new int[random.Next(minRowsAmount, maxValue + 1), random.Next(minRowsAmount, maxValue + 1)];

            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    table[i, j] = random.Next(maxValue);
                }
            }

            int sumOfSecondRow = 0;

            for (int i = 0; i < table.GetLength(1); i++)
            {
                sumOfSecondRow += table[1, i];
            }

            int productOfFirstColumn = table[0, 0];

            for (int i = 1; i < table.GetLength(0); i++)
            {
                productOfFirstColumn *= table[i, 0];
            }

            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    Console.Write(table[i, j]);
                }

                Console.Write("\n");
            }

            Console.WriteLine($"Cумма второй строки: {sumOfSecondRow}");
            Console.WriteLine($"Произведение перовго столбца: {productOfFirstColumn}");
        }
    }
}
