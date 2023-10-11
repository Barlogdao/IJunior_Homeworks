namespace HomeWork_040_CardDeck
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandTakeCard = "1";
            const string CommandStop = "2";

            Deck deck = new Deck();
            Player player = new Player();
            bool isStopRequested = false;
            string instructionMessage = $"Введите [{CommandTakeCard}] чтобы взять карту" + $"\nВведите [{CommandStop}] чтобы остановиться\n";

            Console.WriteLine(instructionMessage);

            while (isStopRequested == false)
            {
                Console.Write("Ваш выбор: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case CommandTakeCard:
                        player.TakeCard(deck.GiveCard());
                        break;

                    case CommandStop:
                        isStopRequested = true;
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
        private readonly string[] _cardRanks = new string[] { "Шестерка", "Семерка", "Восьмерка", "Девятка", "Десятка", "Валет", "Дама", "Король", "Туз" };
        private readonly string[] _cardSuits = new string[] { "Черви", "Треф", "Буби", "Пики" };
        private readonly Stack<Card> _cards = new();

        public Deck()
        {
            CreateDeck();
        }

        public Card? GiveCard()
        {
            if (_cards.Count > 0)
            {
                return _cards.Pop();
            }

            return null;
        }

        private void CreateDeck()
        {
            List<Card> cardList = new List<Card>(_cardRanks.Length * _cardSuits.Length);

            foreach (var rank in _cardRanks)
                foreach (var suit in _cardSuits)
                    cardList.Add(new Card(rank, suit));

            Shuffle(cardList);

            foreach (var card in cardList)
            {
                _cards.Push(card);
            }
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
        private readonly List<Card> _hand = new();

        public void TakeCard(Card? card)
        {
            if (card != null)
            {
                _hand.Add(card);

                Console.WriteLine($"Вы взяли {card}");
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
}