using System;

namespace HomeWork_2
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Как вас зовут?");
            string name = Console.ReadLine();

            Console.WriteLine("Сколько вам лет?");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Кто вы по знаку зодиака?");
            string zodiac = Console.ReadLine();

            Console.WriteLine("Где вы работаете?");
            string jobPlace = Console.ReadLine();

            Console.WriteLine($"Вас зовут {name}, вам {age} год, вы {zodiac} и работаете {jobPlace}");
        }
    }
}
