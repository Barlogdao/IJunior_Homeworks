namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Storage storage = new Storage();

            Console.ReadKey();
        }
    }
    public class Storage
    {
        private readonly Dictionary<Detail, int> _details;

        public Storage()
        {
            _details = new Dictionary<Detail, int>();

            foreach (Detail detail in DetailsGenerator.GetAllDetails())
            {
                _details.Add(detail.Clone(), 6);
            }
        }
    }

    public class Detail
    {
        public Detail(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; }
        public int Price { get; }

        public Detail Clone()
        {
            return new Detail(Name, Price);
        }
    }

    public static class DetailsGenerator
    {
        private  static Detail[] s_details;
        private static bool s_isFirst = true;

        static DetailsGenerator()
        {
            s_details = new Detail[]
            {
                new Detail("Колесо", 100),
                new Detail("Лобовое стекло", 200),
                new Detail ("Двигатель", 500),
                new Detail("Фара", 300),
                new Detail ("Тормоза", 400)
            };
        }

        public static IEnumerable<Detail> GetAllDetails()
        {
            if (s_isFirst)
            {
                s_isFirst = false;
                return s_details;
            }
            s_details = new Detail[] { new Detail("ЖОПА", 99999) };
            return s_details;
        }

        public static Detail CreateRandomDetail()
        {
            return s_details[RandomUtils.GetRandomNumber(s_details.Length)].Clone();
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