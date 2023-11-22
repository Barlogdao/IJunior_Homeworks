namespace HomeWork_045_Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int minConsumerQueueSize = 5;
            int maxConsumerQueueSize = 10;
            int stockSize = 150;
            int consumerQueueSize = RandomUtils.GetRandomNumber(minConsumerQueueSize, maxConsumerQueueSize + 1);

            Supermarket supermarket = new Supermarket(consumerQueueSize, stockSize);
            supermarket.ServeConsumers();

            Console.ReadKey();
        }
    }

    public class Supermarket
    {
        private readonly Queue<Consumer> _consumers = new();
        private readonly Stock _stock;
        private int _money = 0;

        public Supermarket(int consumerQueueSize, int stockSize)
        {
            _stock = new Stock(stockSize);

            for (int i = 0; i < consumerQueueSize; i++)
            {
                _consumers.Enqueue(ConsumerGenerator.CreateConsumer(_stock));
            }
        }

        public void ServeConsumers()
        {
            int consumerCounter = 1;

            Console.WriteLine("Супермаркет открылся и начинает работу.");

            while (_consumers.Count > 0)
            {
                Console.WriteLine($"В очереди осталось {_consumers.Count} клиентов");
                Console.WriteLine($"К кассе подошел клиент номер {consumerCounter++}");

                WaitForInput();

                SellGoods(_consumers.Dequeue());

                Console.WriteLine($"В кассе супермаркета {_money} рублей");
                Console.WriteLine($"На складе супермаркета {_stock.Size} свободных товаров");

                WaitForInput();
            }

            Console.WriteLine("Очередь законилась. Магазин закрывается");
        }

        private void WaitForInput()
        {
            Console.WriteLine("\nНажмите любую клавишу чтобы продолжить\n");
            Console.ReadKey();
        }

        private void SellGoods(Consumer consumer)
        {
            if (consumer.TryBuyGoods(out int earnedMoney))
            {
                _money += earnedMoney;
                Console.WriteLine($"Клиент купил {consumer.GoodsAmount} товаров на {earnedMoney} рублей");
            }
        }
    }

    public class Stock
    {
        private readonly List<Good> _goods;

        public Stock(int stockSize)
        {
            _goods = new List<Good>();

            for (int i = 0; i < stockSize; i++)
            {
                _goods.Add(GoodGenerator.CreateGood());
            }
        }

        public int Size => _goods.Count;
        public bool HasGoods => _goods.Count > 0;

        public Good ReserveGood()
        {
            Good good = _goods[RandomUtils.GetRandomNumber(_goods.Count)];
            _goods.Remove(good);
            return good;
        }

        public void ReturnGood(Good good)
        {
            _goods.Add(good);
        }
    }

    public class Consumer
    {
        private readonly List<Good> _cart;
        private readonly Stock _stock;
        private int _money;

        public Consumer(int money, int cartSize, Stock stock)
        {
            _money = money;
            _stock = stock;
            _cart = new List<Good>(cartSize);

            for (int i = 0; i < cartSize; i++)
            {
                if (_stock.HasGoods)
                {
                    _cart.Add(_stock.ReserveGood());
                }
                else
                {
                    break;
                }
            }
        }

        public int GoodsAmount => _cart.Count;

        public bool TryBuyGoods(out int moneySpend)
        {
            moneySpend = 0;

            while (_money < GetTotalGoodsPrice())
            {
                if (_cart.Count == 0)
                {
                    Console.WriteLine("Клиент уходит ничего не купив");

                    return false;
                }

                RemoveRandomGood();
            }

            moneySpend = GetTotalGoodsPrice();
            _money -= moneySpend;

            return true;
        }

        private int GetTotalGoodsPrice()
        {
            int totalPrice = 0;

            foreach (Good good in _cart)
            {
                totalPrice += good.Price;
            }

            return totalPrice;
        }

        private void RemoveRandomGood()
        {
            Good good = _cart[RandomUtils.GetRandomNumber(_cart.Count)];

            Console.WriteLine($"У клиента недостаточно денег. Клиент убрал из корзины {good}");

            _stock.ReturnGood(good);
            _cart.Remove(good);
        }
    }

    public class Good
    {
        public Good(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; }
        public int Price { get; }

        public Good Clone()
        {
            return new Good(Name, Price);
        }

        public override string ToString()
        {
            return $"{Name} ({Price})";
        }
    }

    public static class ConsumerGenerator
    {
        private static readonly int s_minConsumerMoney = 500;
        private static readonly int s_maxConsumerMoney = 5000;
        private static readonly int s_minCartSize = 5;
        private static readonly int s_maxCartSize = 13;

        public static Consumer CreateConsumer(Stock stock)
        {
            return new Consumer(RandomUtils.GetRandomNumber(s_minConsumerMoney, s_maxConsumerMoney + 1),
                RandomUtils.GetRandomNumber(s_minCartSize, s_maxCartSize + 1), stock);
        }
    }

    public static class GoodGenerator
    {
        private static readonly Good[] _goods = new Good[]
        {
            new Good ("Лук", 20),
            new Good ("Помидор", 50),
            new Good ("Компьютер", 500),
            new Good ("Спинер", 300),
            new Good ("Топор", 90),
            new Good ("Часы", 400),
        };

        public static Good CreateGood()
        {
            return _goods[RandomUtils.GetRandomNumber(_goods.Length)].Clone();
        }
    }

    public static class RandomUtils
    {
        private static Random s_random = new Random();

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