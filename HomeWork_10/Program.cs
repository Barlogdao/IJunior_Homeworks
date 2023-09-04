using System;

namespace HomeWork_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int maxValue = 100;
            int randomValue = random.Next(maxValue +1);
            int moduloDividerOne = 3;
            int moduloDividerTwo = 5;
            int sum = 0;

            for (int i = 0; i <= randomValue; i++)
            {
                if (i % moduloDividerOne == 0 || i % moduloDividerTwo == 0)
                {
                    sum += i;
                }
            }

            Console.WriteLine(randomValue);
            Console.WriteLine(sum);
        }
    }
}
