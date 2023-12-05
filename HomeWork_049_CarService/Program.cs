namespace HomeWork_049_CarService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int carQueueSize = 5;

            CarService carService = new CarService(carQueueSize);

            carService.Work();
        }
    }

    public class CarService
    {
        private readonly Storage _storage;
        private readonly Queue<Car> _cars;
        private readonly int _workPrice;
        private int _fineSize;

        private int _money;

        public CarService(int carQueueSize)
        {
            _money = 100;
            _workPrice = 100;
            _fineSize = 50;
            _storage = new Storage();
            _cars = new Queue<Car>();

            for (int i = 0; i < carQueueSize; i++)
            {
                _cars.Enqueue(new Car());
            }
        }

        private bool IsBankrupt => _money < 0;

        public void Work()
        {
            Console.WriteLine("Автосервис начал рабочий день\n");

            while (_cars.Count > 0 && IsBankrupt == false)
            {
                _storage.ShowInfo();
                Console.WriteLine($"На счету автосервиса {_money} рублей");
                Console.WriteLine($"Клиентов в очереди: {_cars.Count}.");
                Console.WriteLine("\nВ автосервис заехал новый клиент");

                WaitForInput();

                ServeCar(_cars.Dequeue());

                WaitForInput();

                Console.Clear();
            }

            if (IsBankrupt == true)
                Console.WriteLine("Автосервис обанкротился, так как больше не может платить по счетам.");
            else
                Console.WriteLine("Рабочий день закончился");

            Console.WriteLine("Автосервис закрывается");
        }

        private void ServeCar(Car car)
        {
            const string CommandReject = "0";

            bool isCarServed = false;

            Console.WriteLine($"\nВ машине клиента сломана деталь: {car.BrokenDetail.Name}.");
            Console.WriteLine($"За починку автосервис заработает {car.BrokenDetail.Price} + {_workPrice} рублей.");

            while (isCarServed == false)
            {
                Console.WriteLine($"\nВведите название детали со склада для замены" +
                    $"\nили [{CommandReject}] для откажите в обслуживании (штраф за отказ {_fineSize} рублей).");

                string input = Console.ReadLine();

                if (input == CommandReject)
                {
                    _money -= _fineSize;

                    Console.WriteLine("Вы отказали клиенту в обслуживании");
                    Console.WriteLine($"Со счета автосервиса списано {_fineSize} рублей");

                    isCarServed = true;
                }
                else
                {
                    if (_storage.TryGetDetail(input, out Detail detail))
                    {
                        if (car.TryRepair(detail))
                        {
                            _money += detail.Price + _workPrice;

                            Console.WriteLine($"{detail.Name} успешно заменено");
                            Console.WriteLine($"Автосервис заработал {detail.Price + _workPrice} рублей");
                        }
                        else
                        {
                            _money -= detail.Price;

                            Console.WriteLine($"Вы заменили неверную деталь ({detail.Name} вместо {car.BrokenDetail.Name})");
                            Console.WriteLine($"Автосервис компенсирует клиенту стоимость неверно замененной детали: {detail.Price}");
                        }

                        isCarServed = true;
                    }
                }
            }
        }

        private void WaitForInput()
        {
            Console.WriteLine("\nНажмите любую клавишу, чтобы продолжить");
            Console.ReadKey();
        }
    }

    public class Storage
    {
        private readonly Dictionary<Detail, int> _details;

        public Storage()
        {
            _details = new Dictionary<Detail, int>();

            foreach (Detail detail in DetailsGenerator.AllDetails)
            {
                _details.Add(detail.Clone(), GetRandomDetailAmount());
            }
        }

        public bool TryGetDetail(string detailName, out Detail detail)
        {
            detail = null;

            foreach (Detail detailType in _details.Keys)
            {
                if (detailType.Name.ToLower() == detailName.ToLower())
                {
                    if (_details[detailType] > 0)
                    {
                        detail = detailType.Clone();
                        _details[detailType]--;

                        Console.WriteLine($"Со склада взята деталь: {detail.Name}");

                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Указанная деталь отсутвует на складе");

                        return false;
                    }
                }
            }

            Console.WriteLine("Указанной детали не существует");

            return false;
        }

        public void ShowInfo()
        {
            Console.WriteLine("На складе имеется:");

            foreach (var detail in _details)
            {
                Console.WriteLine($"[{detail.Key.Name}] Стоимость детали: {detail.Key.Price} рублей. В наличии {detail.Value} единиц");
            }

            Console.WriteLine();
        }

        private int GetRandomDetailAmount()
        {
            int minDetailsAmount = 1;
            int maxDetailsAmount = 2;

            return RandomUtils.GetRandomNumber(minDetailsAmount, maxDetailsAmount + 1);
        }
    }

    public class Car
    {
        public Car()
        {
            BrokenDetail = DetailsGenerator.CreateRandomDetail();
        }

        public Detail BrokenDetail { get; private set; }

        public bool TryRepair(Detail detail)
        {
            if (BrokenDetail.Name == detail.Name)
            {
                BrokenDetail = detail;

                return true;
            }
            else
            {
                return false;
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
        private readonly static Detail[] s_details;

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

        public static IEnumerable<Detail> AllDetails => s_details;

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