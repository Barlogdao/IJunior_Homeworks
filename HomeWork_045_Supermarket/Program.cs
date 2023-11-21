namespace HomeWork_045_Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int minConsumerQueueSize = 5;
            int maxConsumerQueueSize = 10;
            int consumerQueueSize = RandomUtils.GetRandomNumber(minConsumerQueueSize, maxConsumerQueueSize + 1);

            Supermarket supermarket = new Supermarket(consumerQueueSize);
            supermarket.ServeConsumers();

            Console.ReadKey();
        }
    }

    public class Supermarket
    {
        private readonly Queue<Consumer> _consumers = new();
        private int _money = 0;

        public Supermarket(int consumerQueueSize)
        {
            for (int i = 0; i < consumerQueueSize; i++)
            {
                _consumers.Enqueue(ConsumerGenerator.CreateConsumer());
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
        private readonly List<Good> _cart;
        private int _money;

        public Consumer(int money, int cartSize)
        {
            _money = money;
            _cart = new List<Good>(cartSize);

            for (int i = 0; i < cartSize; i++)
            {
                _cart.Add(GoodGenerator.CreateGood());
            }
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
            Good goodForRemove = _cart[RandomUtils.GetRandomNumber(_cart.Count)];

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
        private static readonly int s_minConsumerMoney = 500;
        private static readonly int s_maxConsumerMoney = 5000;
        private static readonly int s_minCartSize = 5;
        private static readonly int s_maxCartSize = 13;

        public static Consumer CreateConsumer()
        {
            return new Consumer(RandomUtils.GetRandomNumber(s_minConsumerMoney, s_maxConsumerMoney + 1),
                RandomUtils.GetRandomNumber(s_minCartSize, s_maxCartSize + 1));
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