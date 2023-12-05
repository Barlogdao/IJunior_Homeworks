﻿namespace HW_054_ExpiredStew
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int stewAmount = 50;
            int currentYear = 2023;

            List<Stew> stews = new List<Stew>();

            for (int i = 0; i < stewAmount; i++)
            {
                stews.Add(StewFactory.CreateStew());
            }

            ShowFreshStews(stews, currentYear);
        }

        private static void ShowFreshStews(List<Stew> stews, int currentYear)
        {
            var freshStews = stews.Where(stew => stew.ProductionYear + stew.ShelfLife > currentYear);

            foreach (var stew in freshStews)
                Console.WriteLine(stew);
        }
    }

    public class Stew
    {
        public Stew(string name, int productionDate, int shelfLife)
        {
            Name = name;
            ProductionYear = productionDate;
            ShelfLife = shelfLife;
        }

        public string Name { get; init; }
        public int ProductionYear { get; init; }
        public int ShelfLife { get; init; }

        public override string ToString()
        {
            return $"{Name}\tГод производства: {ProductionYear}\tСрок годности: {ShelfLife} лет";
        }
    }

    public static class StewFactory
    {
        private static readonly string[] s_names;

        static StewFactory()
        {
            s_names = new string[] { "Хряк", "Алтай", "Дружок", "Лесник" };
        }

        public static Stew CreateStew() 
        {
            int minProducionYear = 1941;
            int maxProductionYear = 2022;

            int minShelfLife = 10;
            int maxShelfLife = 40;

            string name = s_names[RandomUtils.GetRandomNumber(s_names.Length)];
            int productionYear = RandomUtils.GetRandomNumber(minProducionYear, maxProductionYear);
            int shelfLife = RandomUtils.GetRandomNumber(minShelfLife, maxShelfLife);

            return new Stew(name, productionYear, shelfLife);
        }
    }

    public static class RandomUtils
    {
        private static readonly Random s_random = new Random();

        public static int GetRandomNumber(int maxValue) => s_random.Next(maxValue);

        public static int GetRandomNumber(int minValue, int maxValue) => s_random.Next(minValue, maxValue);
    }
}