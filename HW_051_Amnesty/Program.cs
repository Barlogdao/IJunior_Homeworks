using System.Collections.Immutable;

namespace HW_051_Amnesty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrisonerFactory prisonerFactory = new PrisonerFactory();
            int prisonersAmount = 10;
            string crimeType = prisonerFactory.CrimeTypes[0];

            List<Prisoner> prisoners = new();

            for (int i = 0; i < prisonersAmount; i++)
            {
                prisoners.Add(prisonerFactory.CreatePrisoner());
            }

            Console.WriteLine("Список преступников до амнистии:");

            ShowPrisoners(prisoners);

            prisoners = prisoners.Where(prisoner => prisoner.CrimeType != crimeType).ToList();

            Console.WriteLine("\nОглашена амнистия\n");
            Console.WriteLine("Список преступников после амнистии:");

            ShowPrisoners(prisoners);
        }

        static void ShowPrisoners(IEnumerable<Prisoner> prisoners)
        {
            foreach (Prisoner prisoner in prisoners)
                Console.WriteLine(prisoner);
        }
    }

    public class Prisoner
    {
        public Prisoner(string name, string crimeType)
        {
            Name = name;
            CrimeType = crimeType;
        }

        public string Name { get; init; }
        public string CrimeType { get; init; }

        public override string ToString()
        {
            return $"{Name}. Вид преступления: {CrimeType}";
        }
    }

    public  class PrisonerFactory
    {
        private readonly  string[] _names;
        private readonly  ImmutableArray<string> _crimeTypes;

        public PrisonerFactory()
        {
            _names = new string[] { "Кларк Кент", "Иван Иванов", "Александр Петров", "Семен Слепаков" };
            _crimeTypes = ImmutableArray.Create( "Антиправительственное", "Административное", "Гражданское", "Уголовное");
        }

        public  ImmutableArray<string> CrimeTypes => _crimeTypes;

        public  Prisoner CreatePrisoner()
        {
            return new Prisoner(_names[RandomUtils.GetRandomNumber(_names.Length)], _crimeTypes[RandomUtils.GetRandomNumber(_crimeTypes.Length)]);
        }
    }

    public static class RandomUtils
    {
        private static readonly Random s_random = new Random();

        public static int GetRandomNumber(int maxValue)
        {
            return s_random.Next(maxValue);
        }

        public static int GetRandomNumber(int minValue, int maxValue)
        {
            return s_random.Next(minValue, maxValue);
        }
    }
}