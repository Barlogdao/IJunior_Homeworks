using System;

namespace HomeWork_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int number = random.Next(0, 101);
            int sum = 0;

            for (int i = 0; i <= number; i++)
            {
                if (i % 3  == 0 || i % 5 == 0)
                {
                    sum += i;
                }
            }

            Console.WriteLine(number);
            Console.WriteLine(sum);
        }
    }
}
