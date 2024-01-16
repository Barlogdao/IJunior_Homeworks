namespace HomeWork_056_ArmyUnion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int squadSize = 10;

            List<Soldier> firstSquad = CreateSquad(squadSize);
            List<Soldier> secondSquad = CreateSquad(squadSize);

            ShowSquad(firstSquad);
            ShowSquad(secondSquad);

            TransferSolders(ref firstSquad, ref secondSquad);

            ShowSquad(firstSquad);
            ShowSquad(secondSquad);
        }

        private static void ShowSquad(List<Soldier> firstSquad)
        {
            foreach (var soldier in firstSquad)
            {
                Console.WriteLine(soldier.Name);
            };

            Console.WriteLine();
        }

        private static List<Soldier> CreateSquad(int squadSize)
        {
            List<Soldier> squad = new List<Soldier>();

            for (int i = 0; i < squadSize; i++)
            {
                squad.Add(SoldierFactory.CreateSoldier());
            }

            return squad;
        }

        private static void TransferSolders(ref List<Soldier> firstSquad, ref List<Soldier> secondSquad)
        {
            char symbol = 'Б';

            List<Soldier> tempSoldiers = firstSquad.Where(soldier => soldier.Name.StartsWith(symbol)).ToList();
            firstSquad = firstSquad.Except(tempSoldiers).ToList();
            secondSquad = secondSquad.Union(tempSoldiers).ToList();
        }
    }

    public class Soldier
    {
        public Soldier(string name)
        {
            Name = name;
        }

        public string Name { get; init; }
    }

    public static class SoldierFactory
    {
        private static readonly string[] s_names;

        static SoldierFactory()
        {
            s_names = new string[] { "Борисов", "Белочкин", "Семенов", "Иванов", "Сергеев", "Захаров" };
        }

        public static Soldier CreateSoldier()
        {
            string name = s_names[RandomUtils.GetRandomNumber(s_names.Length)];

            return new Soldier(name);
        }
    }

    public static class RandomUtils
    {
        private static readonly Random s_random = new Random();

        public static int GetRandomNumber(int maxValue) => s_random.Next(maxValue);

        public static int GetRandomNumber(int minValue, int maxValue) => s_random.Next(minValue, maxValue);
    }
}