namespace HW_053_SeverPlayersTop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int playersAmount = 20;
            int recordsAmount = 3;

            List<Player> players = new List<Player>();

            for (int i = 0; i < playersAmount; i++)
            {
                players.Add(PlayerFactory.CreatePlayer());
            }

            Console.WriteLine("Топ игроков по уровню:");
            ShowTopLevelPlayers(players, recordsAmount);

            Console.WriteLine("Топ игроков по силе:");
            ShowTopStrengthPlayers(players, recordsAmount);
        }

        static void ShowTopLevelPlayers(List<Player> players, int recordsAmount)
        {
            var topPlayers = players.OrderByDescending(player => player.Level).Take(recordsAmount);

            Show(topPlayers);
        }

        static void ShowTopStrengthPlayers(List<Player> players, int recordsAmount)
        {
            var topPlayers = players.OrderByDescending(player => player.Strength).Take(recordsAmount);

            Show(topPlayers);
        }

        static void Show(IEnumerable<Player> players)
        {
            foreach (var player in players)
            {
                Console.WriteLine(player);
            }
        }
    }

    public class Player
    {
        public Player(string name, int level, int strength)
        {
            Name = name;
            Level = level;
            Strength = strength;
        }

        public string Name { get; init; }
        public int Level { get; init; }
        public int Strength { get; init; }

        public override string ToString()
        {
            return $"Игрок: {Name}.\tУровень:{Level}.\tСила: {Strength}.";
        }
    }

    public static class PlayerFactory
    {
        private static string[] s_names;

        static PlayerFactory()
        {
            s_names = new string[] { "Джон", "Билл", "Стив", "Дональд", "Барак", "Джордж", "Винстон", "Хью" };
        }

        public static Player CreatePlayer()
        {
            int minLevel = 1;
            int maxLevel = 100;

            int minStrength = 1;
            int maxStrength = 13;

            string name = s_names[RandomUtils.GetRandomNumber(s_names.Length)];
            int level = RandomUtils.GetRandomNumber(minLevel, maxLevel + 1);
            int strength = RandomUtils.GetRandomNumber(minStrength, maxStrength + 1);

            return new Player(name, level, strength);
        }
    }

    public static class RandomUtils
    {
        private static readonly Random s_random = new Random();

        public static int GetRandomNumber(int maxValue) => s_random.Next(maxValue);

        public static int GetRandomNumber(int minValue, int maxValue) => s_random.Next(minValue, maxValue);
    }
}