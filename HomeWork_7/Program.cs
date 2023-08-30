using System;

namespace HomeWork_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите сообщение.");
            string message = Console.ReadLine();

            Console.WriteLine("Сколько раз его написать?");
            int messageQuantity = int.Parse(Console.ReadLine());

            for (int i = 0; i < messageQuantity; i++)
            {
                Console.WriteLine(message);
            }
        }
    }
}
