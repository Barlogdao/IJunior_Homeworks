using System;

namespace HomeWork_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int CrystalPrice = 5;

            Console.WriteLine("Сколько у вас золота?");
            int currentGold = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Предлагаем вам кристаллы по {CrystalPrice} золота за штуку! Сколько возьмете?");
            int purchasedCrystals = Convert.ToInt32(Console.ReadLine());

            currentGold -= purchasedCrystals * CrystalPrice;
            Console.WriteLine($"В вашем распоряжении {purchasedCrystals} кристаллов.\nУ вас осталось {currentGold} золота");
        }
    }
}
