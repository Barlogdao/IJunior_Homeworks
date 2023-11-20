namespace HomeWork_043_TrainConfigurator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandCreateDirection = "1";
            const string CommandSellTickets = "2";
            const string CommandCreateTrain = "3";
            const string CommandSendTrain = "4";
            const string CommandExit = "0";

            RailWayStation railwayStation = new RailWayStation();
            string commandMessage = $"\nВведите команду" +
                $"\n[{CommandCreateDirection}] - создать направление" +
                $"\n[{CommandSellTickets}] - продать билеты" +
                $"\n[{CommandCreateTrain}] - сформировать поезд" +
                $"\n[{CommandSendTrain}] - отправить поезд" +
                $"\n[{CommandExit}] - выйти";
            bool isRun = true;

            while (isRun)
            {
                railwayStation.DisplayInfo();
                Console.WriteLine(commandMessage);

                string input = Console.ReadLine();

                switch (input)
                {
                    case CommandCreateDirection:
                        railwayStation.CreateDirection();
                        break;

                    case CommandSellTickets:
                        railwayStation.SellTickets();
                        break;

                    case CommandCreateTrain:
                        railwayStation.CreateTrain();
                        break;

                    case CommandSendTrain:
                        railwayStation.SendTrain();
                        break;

                    case CommandExit:
                        isRun = false;
                        break;

                    default:
                        Console.WriteLine("Введена неизвестная команда!");
                        break;
                }

                Console.WriteLine("\nДля продолжения нажмите любую клавишу");

                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    public class RailWayStation
    {
        private int _money = 0;
        private int _passenegers;
        private State _state = State.Avaliable;
        private Direction _createdDirection = null;
        private Train _createdTrain = null;
        private Route _createdRoute = null;

        private string _startPoint = "Москва";
        private string[] _destinationPoints = new string[] { "Екатеринбург", "Сочи", "Казань" };

        private Random _random = new Random();

        public void CreateDirection()
        {
            if(_state != State.Avaliable)
            {
                Console.WriteLine("Направление уже сформировано!");
                DisplayNextStep();
                return;
            }

            _createdDirection = new Direction(_startPoint, GetDestinationPoint());
            _state = State.DirectionCreated;

            Console.WriteLine($"Создано направление {_createdDirection}");
        }

        public void SellTickets()
        {
            if (_state != State.DirectionCreated)
            {
                Console.WriteLine("Невозможно продать билеты!");

                DisplayNextStep();
                return;
            }

            int maxPassenegersAmount = 300;

            _passenegers = _random.Next(maxPassenegersAmount + 1);
            int earnedMoney = _passenegers * _createdDirection.TicketPrice;
            _money += earnedMoney;
            _state = State.TicketsSold;

            Console.WriteLine($"Продано билетов: {_passenegers}");
            Console.WriteLine($"Получено: {earnedMoney} рублей");
            Console.WriteLine($"В кассе: {_money} рублей");
        }

        public void CreateTrain()
        {
            if (_state != State.TicketsSold)
            {
                Console.WriteLine("Невозможно сформировать поезд!");

                DisplayNextStep();
                return;
            }

            _createdTrain = new Train(_passenegers, _random.Next());
            _state = State.TrainCreated;

            Console.WriteLine($"Сформирован {_createdTrain} на {_createdTrain.TotalSeats} мест");
        }

        public void SendTrain()
        {
            if (_state != State.TrainCreated)
            {
                Console.WriteLine("Невозможно отправить поезд!");

                DisplayNextStep();
                return;
            }

            _createdRoute = new Route(_createdDirection, _createdTrain);
            _state = State.Avaliable;

            Console.WriteLine($"На рейс {_createdDirection} вышел {_createdTrain}");
        }

        public void DisplayInfo()
        {
            if (_createdRoute != null)
            {
                _createdRoute.ShowInfo();
            }
            else
            {
                Console.WriteLine("На сегодня рейсов нет");
            }
        }

        private string GetDestinationPoint()
        {
            return _destinationPoints[_random.Next(0, _destinationPoints.Length)];
        }

        private void DisplayNextStep()
        {
            switch (_state)
            {
                case State.Avaliable:
                    Console.WriteLine("Необходимо создать направление");
                    break;

                case State.DirectionCreated:
                    Console.WriteLine("Необходимо продать билеты");
                    break;

                case State.TicketsSold:
                    Console.WriteLine("Необходимо сформировать поезд");
                    break;
                case State.TrainCreated:
                    Console.WriteLine("Необходимо отправить поезд");
                    break;
            };
        }

        private enum State
        {
            Avaliable,
            DirectionCreated,
            TicketsSold,
            TrainCreated
        }
    }

    public class Direction
    {
        public Direction(string startPoint, string destinationPoint)
        {
            TicketPrice = GetTicketCost();
            StartPoint = startPoint;
            DestinationPoint = destinationPoint;
        }

        public int TicketPrice { get; private set; }
        public string StartPoint { get; private set; }
        public string DestinationPoint { get; private set; }

        public override string ToString()
        {
            return $"{StartPoint} - {DestinationPoint}";
        }

        private int GetTicketCost()
        {
            int minTicketPrice = 200;
            int maxTicketPrice = 2000;
            Random random = new Random();

            return random.Next(minTicketPrice, maxTicketPrice);
        }
    }

    public class Train
    {
        private readonly List<Carriage> _carriages = new List<Carriage>();
        private int _passenegersAmount;
        private int _number;

        public Train(int passenegersAmount, int number)
        {
            _passenegersAmount = passenegersAmount;
            _number = number;
            Build();
            AccomodatePasseners();
        }

        public int TotalSeats { get; private set; }

        public override string ToString()
        {
            return $"поезд # {_number}";
        }

        public void AccomodatePasseners()
        {
            int leftPassenegers = _passenegersAmount;

            foreach (Carriage carriage in _carriages)
            {
                carriage.AccomodatePassenegers(ref leftPassenegers);
            }
        }

        private void Build()
        {
            Carriage carriage;

            while (_passenegersAmount > TotalSeats)
            {
                carriage = new Carriage();
                _carriages.Add(carriage);
                TotalSeats += carriage.TotalSeats;
            }
        }

        public void ShowInfo()
        {
            int counter = 1;

            Console.WriteLine(this);
            Console.WriteLine($"Всего мест {TotalSeats}");

            foreach (var carriage in _carriages)
            {
                Console.WriteLine($"Вагон #{counter++}. {carriage}");
            }
        }
    }

    public class Carriage
    {
        public Carriage()
        {
            TotalSeats = GetTotalSeats();
            AvaliableSeats = TotalSeats;
        }

        public int TotalSeats { get; init; }
        public int AvaliableSeats { get; private set; }

        public void AccomodatePassenegers(ref int leftPassenegers)
        {
            int occupiedSeats = Math.Min(TotalSeats, leftPassenegers);
            AvaliableSeats -= occupiedSeats;
            leftPassenegers -= occupiedSeats;
        }

        private int GetTotalSeats()
        {
            const int MinSeatsValue = 20;
            const int MaxSeatsValue = 45;

            Random random = new Random();

            return random.Next(MinSeatsValue, MaxSeatsValue);
        }

        public override string ToString()
        {
            return $"Свободных мест: {AvaliableSeats} из {TotalSeats}";
        }
    }

    public class Route
    {
        private readonly Direction _direction;
        private readonly Train _train;

        public Route(Direction direction, Train train)
        {
            _direction = direction;
            _train = train;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Действующий рейс: {_direction}.");
            Console.Write($"На рейс вышел ");
            _train.ShowInfo();
        }
    }
}