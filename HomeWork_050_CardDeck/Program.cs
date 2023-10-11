namespace HomeWork_040_CardDeck
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandTakeCard = "1";
            const string CommandStop = "2";

            Deck deck = new Deck();
            Player player = new Player(deck);
            bool _isStopRequested = false;
            string instructionMessage = $"Введите [{CommandTakeCard}] чтобы взять карту" + $"\nВведите [{CommandStop}] чтобы остановиться\n";

            Console.WriteLine(instructionMessage);

            while (_isStopRequested == false)
            {
                Console.Write("Ваш выбор: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case CommandTakeCard:
                        player.TakeCard();
                        break;

                    case CommandStop:
                        _isStopRequested = true;
                        break;

                    default:
                        Console.WriteLine("Введена неверная команда!");
                        Console.WriteLine(instructionMessage);
                        break;
                }
            }

            Console.WriteLine("\nУ вас на руках:");
            player.ShowCards();

            Console.ReadKey();
        }
    }

    public class Deck
    {
        private readonly Dictionary<CardRank, string> _cardRanks = new()
        {
            { CardRank.six,     "Шестерка"},
            { CardRank.seven,   "Семерка"},
            { CardRank.eight,   "Восьмерка"},
            { CardRank.nine,    "Девятка"},
            { CardRank.ten,     "Десятка"},
            { CardRank.jack,    "Валет"},
            { CardRank.queen,   "Дама"},
            { CardRank.king,    "Король"},
            { CardRank.ace,     "Туз"}
        };

        private readonly Dictionary<CardSuit, string> _cardSuits = new()
        {
            {CardSuit.hearts,   "Черви"},
            {CardSuit.clubs,    "Треф"},
            {CardSuit.diamonds, "Буби"},
            {CardSuit.spades,   "Пики"}
        };

        private Stack<Card> _cards = new();

        public Deck()
        {
            List<Card> cardList = new List<Card>(_cardRanks.Count * _cardSuits.Count);

            foreach (var rank in _cardRanks.Keys)
                foreach (var suit in _cardSuits.Keys)
                    cardList.Add(new Card(_cardRanks[rank], _cardSuits[suit]));

            Shuffle(cardList);

            foreach (var card in cardList)
            {
                _cards.Push(card);
            }
        }

        public Card? GetCard()
        {
            if (_cards.Count > 0)
            {
                return _cards.Pop();
            }

            return null;
        }

        private void Shuffle(List<Card> cards)
        {
            Random random = new Random();

            for (int i = 0; i < cards.Count; i++)
            {
                int randomIndex = random.Next(cards.Count);
                (cards[i], cards[randomIndex]) = (cards[randomIndex], cards[i]);
            }
        }
    }

    public record Card(string Rank, string Suit)
    {
        public override string ToString()
        {
            return Rank + " " + Suit;
        }
    }

    public class Player
    {
        private List<Card> _hand = new();
        private Deck _deck;

        public Player(Deck deck)
        {
            _deck = deck;
        }

        public void TakeCard()
        {
            Card? nextCard = _deck.GetCard();

            if (nextCard != null)
            {
                _hand.Add(nextCard);

                Console.WriteLine($"Вы взяли {nextCard}");
            }
            else
            {
                Console.WriteLine("Карты закончились!");
            }
        }

        public void ShowCards()
        {
            foreach (var card in _hand)
            {
                Console.WriteLine(card);
            }
        }
    }

    public enum CardRank
    {
        six,
        seven,
        eight,
        nine,
        ten,
        jack,
        queen,
        king,
        ace
    }

    public enum CardSuit
    {
        hearts,
        diamonds,
        clubs,
        spades
    }
}
