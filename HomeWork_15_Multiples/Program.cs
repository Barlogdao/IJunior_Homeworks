namespace HomeWork_15_Multiples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int minValue = 1;
            int maxValue = 27;
            int stepNumber = random.Next(minValue,maxValue +1);

            int minNaturalNumber = 100;
            int maxNaturalNumber = 999;
            int naturalNumbersCount = 0;

            for (int i = stepNumber; i <= maxNaturalNumber ; i+= stepNumber)
            {
                if (i >= minNaturalNumber)
                {
                    naturalNumbersCount ++;
                }
            }

            Console.WriteLine(stepNumber);
            Console.WriteLine(naturalNumbersCount);
        }
    }
}