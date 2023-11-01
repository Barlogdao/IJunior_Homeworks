namespace HomeWork_042_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player(100);
            Seller seller = new Seller();
            Shop shop = new Shop(player, seller);

            shop.Run();
        }
    }

    public class Player
    {
        private readonly List<Item> _inventory;
        private int _money;

        public Player(int money)
        {
            _inventory = new();
            _money = money;
        }

        public void ShowInventory()
        {
            Console.WriteLine("В вашем инвентаре:");
            Console.WriteLine($"Золото ({_money})");

            foreach (Item item in _inventory)
                Console.WriteLine(item.Name);
        }

        public bool TryBuyItem(Item item)
        {
            if (CanBuyItem(item))
            {
                _money -= item.Price;
                AddItemToInventory(item);

                Console.WriteLine($"Вы купили предмет ({item.Name})");
                return true;
            }

            Console.WriteLine($"У вас недостаточно средств для покупки предмета ({item.Name}).");

            return false;
        }

        private bool CanBuyItem(Item item)
        {
            return _money >= item.Price;
        }

        private void AddItemToInventory(Item item)
        {
            _inventory.Add(item);
        }
    }

    public class Seller
    {
        private readonly List<Item> _items;

        public Seller()
        {
            _items = new List<Item>()
            {
                new Item("Меч", 25),
                new Item("Щит", 20),
                new Item("Лук", 22),
                new Item("Конь", 30),
            };
        }

        public void ShowItems()
        {
            if (_items.Count == 0)
            {
                Console.WriteLine("Торговцу нечего вам предложить(");
            }
            else
            {
                int countOffset = 1;

                Console.WriteLine("Торговец предлагает следующие товары:");

                for (int i = 0; i < _items.Count; i++)
                    Console.WriteLine($"{i + countOffset}. {_items[i]}");
            }
        }

        public bool TryGetItem(int itemIndex, out Item item)
        {
            item = null;

            if (itemIndex < 0 || itemIndex >= _items.Count)
            {
                Console.WriteLine("Предмета с указанным номером не существует!");
                return false;
            }

            item = _items[itemIndex];
            return true;
        }

        public void SellItem(Item item)
        {
            _items.Remove(item);
        }
    }

    public class Shop
    {
        private const string CommandShowItems = "1";
        private const string CommandBuyItem = "2";
        private const string CommandShowInventory = "3";
        private const string CommandExit = "0";

        private readonly Player _player;
        private readonly Seller _seller;

        private readonly string _commandMessage = $"\n [{CommandShowItems}] - посмотреть товары торговца" +
                $"\n [{CommandBuyItem}] - купить товар у торговца" +
                $"\n [{CommandShowInventory}] - посмотреть свой инвентарь" +
                $"\n [{CommandExit}] - выход";
        private bool _isWorking = true;

        public Shop(Player player, Seller seller)
        {
            _player = player;
            _seller = seller;
        }

        public void Run()
        {
            Console.WriteLine("Добро пожаловать в лавку торговца!");
            Console.WriteLine(_commandMessage);

            while (_isWorking)
            {
                Console.Write("\nВведите команду: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case CommandShowItems:
                        _seller.ShowItems();
                        break;

                    case CommandShowInventory:
                        _player.ShowInventory();
                        break;

                    case CommandBuyItem:
                        Trade(_player, _seller);
                        break;

                    case CommandExit:
                        _isWorking = false;
                        break;

                    default:
                        Console.WriteLine("Неверная команда!");
                        Console.WriteLine(_commandMessage);
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

            while(int.TryParse(input, out itemNumber) != true)
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