using System.Net.Http.Headers;

namespace HomeWork_049_CarService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
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

        public void ShowInfo()
        {
            Console.WriteLine($"# {Name} - стоит {Price} монет.");
        }

        public Detail Clone()
        {
            return new Detail(Name, Price);
        }
    }

    public class Storage
    {
        private readonly Dictionary<Detail, int> _details;

        public Storage()
        {
            _details = new Dictionary<Detail, int>();

            foreach (Detail detail in DetailAssortiment.GetDetails())
            {
                _details.Add(detail.Clone(), GetRandomDetailsAmount());
            }

        }

        private int GetRandomDetailsAmount()
        {
            int minDetailsAmount = 5;
            int maxDetailsAmount = 10;
            return RandomUtils.GetRandomNumber(minDetailsAmount, maxDetailsAmount + 1);
        }
    }

    public static class DetailAssortiment
    {
        private readonly static Detail[] s_details;

        static DetailAssortiment()
        {
            s_details = new Detail[]
            {
                new Detail("Колесо", 100),
                new Detail("Лобовое стекло", 200),
                new Detail ("Двигатель", 500),
                new Detail("Фары", 300),
                new Detail ("Тормоза", 400)
            };
        }

        public static IEnumerable<Detail> GetDetails()
        {
            return s_details;
        }
    }

    public class CarService
    {
        private int _money;
        private int _workPrice;
        private readonly Storage _storage;
    }

    public class Car
    {

        public void ShowBreakage()
        {

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