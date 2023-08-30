using System;

namespace HomeWork_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int imagesInRow = 3;
            int totalImages = 52;
            int filledRowsAmount = totalImages / imagesInRow;
            int leftImages = totalImages % imagesInRow;

            Console.WriteLine($"Заполнено рядов: {filledRowsAmount}");
            Console.WriteLine($"Осталось картинок: {leftImages}");
        }
    }
}
