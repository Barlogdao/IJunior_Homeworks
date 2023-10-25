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

    public class Shop
    {
        private const string CommandShowItems = "1";
        private const string CommandBuyItem = "2";
        private const string CommandShowInventory = "3";
        private const string CommandExit = "0";

        private Player _player;
        private Seller _seller;

        private bool _isWorking = true;
        private string _commandMessage = $"\n [{CommandShowItems}] - посмотреть товары торговца" +
                $"\n [{CommandBuyItem}] - купить товар у торговца" +
                $"\n [{CommandShowInventory}] - посмотреть свой инвентарь" +
                $"\n [{CommandExit}] - выход";

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
                        Console.Write("Укажите номер товара: ");
                        input = Console.ReadLine();

                        if (int.TryParse(input, out int itemNumber))
                        {
                            int itemIndex = itemNumber - 1;
                            Buy(_player, _seller, itemIndex);
                        }
                        else
                        {
                            Console.WriteLine("Номер товара должен быть числом!");
                        }
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

        private void Buy(Player player, Seller seller, int itemIndex)
        {
            Item item;
            if (seller.TryGetItem(itemIndex, out item))
            {
                if (player.CanBuyItem(item))
                {
                    player.BuyItem(item);
                    seller.SellItem(item);
                }
                else
                {
                    Console.WriteLine($"У вас недостаточно средств для покупки предмета ({item.Name}).");
                }
            }
        }
    }

    public class Player
    {
        private int _money;
        private readonly List<Item> _inventory;

        public Player(int money)
        {
            _money = money;
            _inventory = new();
        }

        public void ShowInventory()
        {
            Console.WriteLine("В вашем инвентаре:");
            Console.WriteLine($"Золото ({_money})");

            foreach (Item item in _inventory)
                Console.WriteLine(item.Name);
        }

        public bool CanBuyItem(Item item)
        {
            return _money >= item.Price;
        }

        public void BuyItem(Item item)
        {
            _money -= item.Price;
            AddItemToInventory(item);

            Console.WriteLine($"Вы купили предмет ({item.Name})");
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

        public Item SellItem(Item item)
        {
            _items.Remove(item);
            return item;
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
//Существует продавец, он имеет у себя список товаров,
//и при нужде, может вам его показать, также продавец может продать вам товар.
//После продажи товар переходит к вам, и вы можете также посмотреть свои вещи. 

//Возможные классы – игрок, продавец, товар. 

//Вы можете сделать так, как вы видите это.