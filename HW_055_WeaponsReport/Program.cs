namespace HW_055_WeaponsReport
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int soldiersAmount = 10;

            List<Soldier> soldiers = new List<Soldier>();

            for (int i = 0; i < soldiersAmount; i++)
            {
                soldiers.Add(SoldierFactory.CreateSoldier());
            }

            ShowReport(soldiers);
        }

        private static void ShowReport(List<Soldier> soldiers)
        {
            var records = from Soldier soldier in soldiers select new { Name = soldier.Name, Rank = soldier.Rank };

            foreach (var record in records)
            {
                Console.WriteLine($"Имя: {record.Name}. Звание: {record.Rank}");
            }
        }
    }

    public class Soldier
    {
        public Soldier(string name, string weapon, string rank, int serviceTime)
        {
            Name = name;
            Weapon = weapon;
            Rank = rank;
            ServiceTime = serviceTime;
        }

        public string Name { get; init; }
        public string Weapon { get; init; }
        public string Rank { get; init; }
        public int ServiceTime { get; init; }
    }

    public static class SoldierFactory
    {
        private static readonly string[] s_names;
        private static readonly string[] s_weapons;
        private static readonly string[] s_ranks;

        static SoldierFactory()
        {
            s_names = new string[] { "Василий", "Дмитрий", "Семен", "Иван", "Сергей", "Захар" };
            s_weapons = new string[] { "Пистолет", "Автомат", "Пулемет", "Базука", "Винтовка" };
            s_ranks = new string[] { "Лейтенат", "Капитан", "Майор", "Полковник" };
        }

        public static Soldier CreateSoldier()
        {
            int minServiceTime = 6;
            int maxServiceTime = 24;

            string name = s_names[RandomUtils.GetRandomNumber(s_names.Length)];
            string weapon = s_weapons[RandomUtils.GetRandomNumber(s_weapons.Length)];
            string rank = s_ranks[RandomUtils.GetRandomNumber(s_ranks.Length)];
            int serviceTime = RandomUtils.GetRandomNumber(minServiceTime, maxServiceTime);

            return new Soldier(name, weapon, rank, serviceTime);
        }
    }

    public static class RandomUtils
    {
        private static readonly Random s_random = new Random();

        public static int GetRandomNumber(int maxValue) => s_random.Next(maxValue);

        public static int GetRandomNumber(int minValue, int maxValue) => s_random.Next(minValue, maxValue);
    }
}