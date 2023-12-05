namespace HW_050_SearchForTheCriminal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SearchingSoftware searchingSoftware = new SearchingSoftware();

            searchingSoftware.Run();
        }
    }

    public class SearchingSoftware
    {
        private readonly Database _database;

        public SearchingSoftware()
        {
            int criminalsAmount = 15000;

            _database = new Database(criminalsAmount);
        }

        public void Run()
        {
            const string CommandSearch = "1";
            const string CommandExit = "0";

            bool isRun = true;

            Console.WriteLine("Вы запустили реестр преступников");

            while (isRun)
            {
                Console.WriteLine($"\nВведите [{CommandSearch}], чтобы запустить поиск по реестру" +
                    $"\nВведите [{CommandExit}] для выхода из реестра");
                string input = Console.ReadLine();

                switch (input)
                {
                    case CommandSearch:
                        Search();
                        break;

                    case CommandExit:
                        isRun = false;
                        break;

                    default:
                        Console.WriteLine("Введена неверная команда!");
                        break;
                }
            }
        }

        private void Search()
        {
            int weight = UserUtils.GetIntegerInput("Введите вес разыскиваемого преступника");
            int height = UserUtils.GetIntegerInput("Введите рост разыскиваемого преступника");
            string nationality = UserUtils.GetStringInput("Введите национальность разыскиваемого преступника");

            IEnumerable<Criminal> foundCriminals = _database.GetCriminals(weight, height, nationality);

            if (foundCriminals.Count() == 0)
            {
                Console.WriteLine("По вашему запросу в реестре неарестованные лица не обнаружены");
            }
            else
            {
                int counter = 1;

                Console.WriteLine("По вашему запросу в реестре найдены следующие неарестованные лица:");

                foreach (Criminal criminal in foundCriminals)
                {
                    Console.WriteLine($"{counter++}. {criminal.Name}");
                }
            }
        }
    }

    public class Database
    {
        private readonly List<Criminal> _criminals;

        public Database(int criminalsAmount)
        {
            CriminalGenerator criminalGenerator = new CriminalGenerator();

            _criminals = new List<Criminal>();

            for (int i = 0; i < criminalsAmount; i++)
            {
                _criminals.Add(criminalGenerator.CreateCriminal());
            }
        }

        public IEnumerable<Criminal> GetCriminals(int weight, int height, string nationality)
        {
            return _criminals.Where(criminal => criminal.Weight == weight &&
                                         criminal.Height == height &&
                                         criminal.Nationality.ToLower() == nationality.ToLower() &&
                                         criminal.IsUnderArrest == false);
        }
    }

    public class Criminal
    {
        public Criminal(string name, string nationality, int weight, int height, bool isUnderArrest)
        {
            Name = name;
            Nationality = nationality;
            Weight = weight;
            Height = height;
            IsUnderArrest = isUnderArrest;
        }

        public string Name { get; init; }
        public string Nationality { get; init; }
        public int Weight { get; init; }
        public int Height { get; init; }
        public bool IsUnderArrest { get; init; }

        public override string ToString()
        {
            return $"{Name}. Вес: {Weight} кг. Рост: {Height} см. Национальность {Nationality}.";
        }
    }

    public class CriminalGenerator
    {
        private string[] _names;
        private string[] _nationalities;

        public CriminalGenerator()
        {
            _names = new string[] { "Иванов Иван Иванович", "Петров Петр Петрович", "Семенов Семен Семеныч", "Дмитриев Дмитрий Дмитриевич" };
            _nationalities = new string[] { "русский", "узбек", "казах" };
        }

        public Criminal CreateCriminal()
        {
            int minWeight = 50;
            int maxWeight = 90;
            int minHeight = 150;
            int maxHeight = 190;

            string name = _names[RandomUtils.GetRandomNumber(_names.Length)];
            string nationality = _nationalities[RandomUtils.GetRandomNumber(_nationalities.Length)];
            int weight = RandomUtils.GetRandomNumber(minWeight, maxWeight + 1);
            int height = RandomUtils.GetRandomNumber(minHeight, maxHeight + 1);
            bool isUnderArrest = RandomUtils.GetRandomBoolean();

            return new Criminal(name, nationality, weight, height, isUnderArrest);
        }

    }

    public static class RandomUtils
    {
        private static readonly Random s_random = new Random();

        public static int GetRandomNumber(int maxValue)
        {
            return s_random.Next(maxValue);
        }

        public static bool GetRandomBoolean()
        {
            return s_random.Next(2) == 1;
        }

        public static int GetRandomNumber(int minValue, int maxValue)
        {
            return s_random.Next(minValue, maxValue);
        }
    }

    public static class UserUtils
    {
        public static string GetStringInput(string message)
        {
            Console.WriteLine(message + ".");
            return Console.ReadLine();
        }

        public static int GetIntegerInput(string message)
        {
            int integerInput;

            Console.WriteLine(message + ".");
            string input = Console.ReadLine();

            while (int.TryParse(input, out integerInput) == false)
            {
                Console.WriteLine("Неверный ввод! Необходимо ввести целое число");

                Console.WriteLine(message + ".");
                input = Console.ReadLine();
            }

            return integerInput;
        }
    }
}