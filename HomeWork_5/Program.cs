using System;

namespace HomeWork_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Сколько у вас золота?");
            int gold = Convert.ToInt32(Console.ReadLine());
            int crystalPrice = 5;
            Console.WriteLine($"Предлагаем вам кристаллы по {crystalPrice} золота за штуку! Сколько возьмете?");
            int purchasedCrystals = Convert.ToInt32(Console.ReadLine());
            int currentGold = gold - purchasedCrystals * crystalPrice;
            Console.WriteLine($"В вашем распоряжении {purchasedCrystals} кристаллов.\nУ вас осталось {currentGold} золота");
        }
    }
}
