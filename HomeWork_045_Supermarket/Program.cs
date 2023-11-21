namespace HomeWork_045_Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int minConsumerQueueSize = 5;
            int maxConsumerQueueSize = 10;
            int consumerQueueSize = RandomProvider.Random.Next(minConsumerQueueSize, maxConsumerQueueSize + 1);

            Supermarket supermarket = new Supermarket(consumerQueueSize);
            supermarket.StartSell();

            Console.ReadKey();
        }
    }

    public class Supermarket
    {
        private int _money = 0;
        private readonly Queue<Consumer> _consumers = new();

        public Supermarket(int consumerQueueSize)
        {
            for (int i = 0; i < consumerQueueSize; i++)
            {
                _consumers.Enqueue(ConsumerGenerator.CreateConsumer());
            }
        }

        public void StartSell()
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

    public class Consumer
    {
        private int _money;
        private readonly List<Good> _cart;

        public Consumer(int money, List<Good> cart)
        {
            _money = money;
            _cart = cart;
        }

        public int GoodsAmount => _cart.Count;

        public bool TryBuyGoods(out int moneySpend)
        {
            moneySpend = 0;

            while (_money < GetCartSum())
            {
                if (_cart.Count == 0)
                {
                    Console.WriteLine("Клиент бомжара и ничего не может купить");
                    
                    return false;
                }

                RemoveRandomGood();
            }

            moneySpend = GetCartSum();
            _money -= moneySpend;

            return true;
        }

        private int GetCartSum()
        {
            int totalSum = 0;

            foreach (Good good in _cart)
            {
                totalSum += good.Price;
            }

            return totalSum;
        }

        private void RemoveRandomGood()
        {
            Good goodForRemove = _cart[RandomProvider.Random.Next(0, _cart.Count)];

            Console.WriteLine($"У клиента недостаточно денег. Клиент убрал из корзины {goodForRemove}");

            _cart.Remove(goodForRemove);
        }
    }

    public class Good
    {
        public readonly string Name;
        public readonly int Price;

        public Good(string name, int price)
        {
            Name = name;
            Price = price;
        }

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
        private static readonly int _minConsumerMoney = 500;
        private static readonly int _maxConsumerMoney = 5000;
        private static readonly int _minCartSize = 5;
        private static readonly int _maxCartSize = 13;

        public static Consumer CreateConsumer()
        {
            return new Consumer(RandomProvider.Random.Next(_minConsumerMoney, _maxConsumerMoney + 1),
                CartGenerator.CreateCart(RandomProvider.Random.Next(_minCartSize, _maxCartSize + 1)));
        }
    }

    public static class CartGenerator
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

        public static List<Good> CreateCart(int cartSize)
        {
            List<Good> cart = new List<Good>(cartSize);

            for (int i = 0; i < cartSize; i++)
            {
                cart.Add(GetGood());
            }

            return cart;
        }

        private static Good GetGood()
        {
            return _goods[RandomProvider.Random.Next(0, _goods.Length)].Clone();
        }
    }

    public static class RandomProvider
    {
        private static Random _random = new Random();

        public static Random Random => _random;
    }
}