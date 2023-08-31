using System;

namespace HomeWork_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int startNumber = 5;
            const int maxNumber = 100;
            const int increment = 7;
            int currentNumber = startNumber;

            do
            {
                Console.Write(currentNumber + " ");
                currentNumber += increment;
            }
            while (currentNumber < maxNumber);
        }
    }
}
