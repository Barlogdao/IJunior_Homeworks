using System;

namespace HomeWork_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string exitCommand = "exit";
            Console.WriteLine($"Для окончания выполнения программы введите \"{exitCommand}\"");
            string input = Console.ReadLine();

            while (input != exitCommand)
            {
                Console.WriteLine("Программы выполняется...");
                Console.WriteLine($"Для окончания выполнения программы введите \"{exitCommand}\"");
                input = Console.ReadLine();
            }
        }
    }
}
