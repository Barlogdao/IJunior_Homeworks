using HomeWork_042_Shop;

namespace HomeWork_042_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player(100);
            Seller seller = new Seller(20);
            Shop shop = new Shop(player, seller);

            shop.Run();
        }
    }

    public abstract class Person
    {
        protected int Money;
        protected List<Item> Inventory;

        public Person(int money)
        {
            Money = money;
            Inventory = new List<Item>();
        }

        public abstract void ShowInventory();
    }


    public class Player : Person
    {
        public Player(int money) : base(money) { }

        public override void ShowInventory()
        {
            Console.WriteLine("В вашем инвентаре:");
            Console.WriteLine($"Золото ({Money})");

            foreach (Item item in Inventory)
                Console.WriteLine(item.Name);
        }

        public bool TryBuyItem(Item item)
        {
            if (CanBuyItem(item.Price))
            {
                BuyItem(item);

                Console.WriteLine($"Вы купили предмет ({item.Name})");
                return true;
            }

            Console.WriteLine($"У вас недостаточно средств для покупки предмета ({item.Name}).");

            return false;
        }

        private bool CanBuyItem(int price)
        {
            return Money >= price;
        }

        private void BuyItem(Item item)
        {
            Money -= item.Price;
            Inventory.Add(item);
        }
    }

    public class Seller : Person
    {
        public Seller(int money) : base(money)
        {
            Inventory = new List<Item>()
            {
                new Item("Меч", 25),
                new Item("Щит", 20),
                new Item("Лук", 22),
                new Item("Конь", 30),
            };
        }

        public override void ShowInventory()
        {
            if (Inventory.Count == 0)
            {
                Console.WriteLine("Торговцу нечего вам предложить(");
            }
            else
            {
                int countOffset = 1;

                Console.WriteLine("Торговец предлагает следующие товары:");

                for (int i = 0; i < Inventory.Count; i++)
                    Console.WriteLine($"{i + countOffset}. {Inventory[i]}");
            }
        }

        public bool TryGetItem(int itemIndex, out Item item)
        {
            item = null;

            if (itemIndex < 0 || itemIndex >= Inventory.Count)
            {
                Console.WriteLine("Предмета с указанным номером не существует!");
                return false;
            }

            item = Inventory[itemIndex];
            return true;
        }

        public void SellItem(Item item)
        {
            Money += item.Price;
            Inventory.Remove(item);
        }
    }

    public class Shop
    {
        private readonly Player _player;
        private readonly Seller _seller;

        public Shop(Player player, Seller seller)
        {
            _player = player;
            _seller = seller;
        }

        public void Run()
        {
            const string CommandShowItems = "1";
            const string CommandBuyItem = "2";
            const string CommandShowInventory = "3";
            const string CommandExit = "0";

            string commandMessage = $"\n [{CommandShowItems}] - посмотреть товары торговца" +
                    $"\n [{CommandBuyItem}] - купить товар у торговца" +
                    $"\n [{CommandShowInventory}] - посмотреть свой инвентарь" +
                    $"\n [{CommandExit}] - выход";
            bool isWorking = true;

            Console.WriteLine("Добро пожаловать в лавку торговца!");
            Console.WriteLine(commandMessage);

            while (isWorking)
            {
                Console.Write("\nВведите команду: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case CommandShowItems:
                        _seller.ShowInventory();
                        break;

                    case CommandShowInventory:
                        _player.ShowInventory();
                        break;

                    case CommandBuyItem:
                        Trade(_player, _seller);
                        break;

                    case CommandExit:
                        isWorking = false;
                        break;

                    default:
                        Console.WriteLine("Неверная команда!");
                        Console.WriteLine(commandMessage);
                        break;
                }
            }
        }

        private void Trade(Player player, Seller seller)
        {
            int itemIndex = GetItemIndex();

            if (seller.TryGetItem(itemIndex, out Item item))
            {

                if (player.TryBuyItem(item))
                {
                    seller.SellItem(item);
                }
            }
        }

        private int GetItemIndex()
        {
            int itemNumber;
            int indexOffset = 1;

            Console.Write("Укажите номер товара: ");
            string input = Console.ReadLine();

            while (int.TryParse(input, out itemNumber) != true)
            {
                Console.WriteLine("Номер товара должен быть числом!");

                Console.Write("Укажите номер товара: ");
                input = Console.ReadLine();
            }

            return itemNumber - indexOffset;
        }
    }

    public class Item
    {
        public Item(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; init; }
        public int Price { get; init; }

        public override string ToString()
        {
            return $"{Name} - {Price} золотых.";
        }
    }
}