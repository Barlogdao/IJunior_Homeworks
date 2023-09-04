using System;

namespace HomeWork_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startNumber = 5;
            int maxNumber = 96;
            int increment = 7;

            for (int i = startNumber; i <= maxNumber; i += increment)
            {
                Console.Write(i + " ");
            }
        }
    }
}
