namespace HW_055_WeaponsReport
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SoldierFactory soldierFactory = new SoldierFactory();

            int soldiersAmount = 10;

            List<Soldier> soldiers = new List<Soldier>();

            for (int i = 0; i < soldiersAmount; i++)
            {
                soldiers.Add(soldierFactory.CreateSoldier());
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

    public class SoldierFactory
    {
        private readonly string[] _names;
        private readonly string[] _weapons;
        private readonly string[] _ranks;

        public SoldierFactory()
        {
            _names = new string[] { "Василий", "Дмитрий", "Семен", "Иван", "Сергей", "Захар" };
            _weapons = new string[] { "Пистолет", "Автомат", "Пулемет", "Базука", "Винтовка" };
            _ranks = new string[] { "Лейтенат", "Капитан", "Майор", "Полковник" };
        }

        public Soldier CreateSoldier()
        {
            int minServiceTime = 6;
            int maxServiceTime = 24;

            string name = _names[RandomUtils.GetRandomNumber(_names.Length)];
            string weapon = _weapons[RandomUtils.GetRandomNumber(_weapons.Length)];
            string rank = _ranks[RandomUtils.GetRandomNumber(_ranks.Length)];
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