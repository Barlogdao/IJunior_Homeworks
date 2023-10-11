namespace HomeWork_039_PlayersDataBase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandAddPlayer = "1";
            const string CommandRemovePlayer = "2";
            const string CommandBanPlayer = "3";
            const string CommandUnbanPlayer = "4";
            const string CommandShowAllPlayers = "5";
            const string CommandExit = "0";

            DataBase dataBase = new DataBase(true);

            bool isExitRequested = false;
            string inputCommand;
            string commandMessage = $"\nВыберите команду для управления базой данных:" +
                 $"\n [{CommandAddPlayer}] - добавить игрока в базу" +
                 $"\n [{CommandRemovePlayer}] - удалить игрока" +
                 $"\n [{CommandBanPlayer}] - забанить игрока" +
                 $"\n [{CommandUnbanPlayer}] - разбанить игрока" +
                 $"\n [{CommandShowAllPlayers}] - показать всех игроков" +
                 $"\n [{CommandExit}] - выход" +
                 $"\n";

            while (isExitRequested == false)
            {
                Console.WriteLine(commandMessage);

                Console.Write("Введите команду: ");
                inputCommand = Console.ReadLine();

                switch (inputCommand)
                {
                    case CommandAddPlayer:
                        dataBase.AddPlayer();
                        break;

                    case CommandRemovePlayer:
                        dataBase.RemovePlayer();
                        break;

                    case CommandBanPlayer:
                        dataBase.BanPlayer();
                        break;

                    case CommandUnbanPlayer:
                        dataBase.UnbanPlayer();
                        break;

                    case CommandExit:
                        isExitRequested = true;
                        break;

                    case CommandShowAllPlayers:
                        dataBase.ShowAllPlayers();
                        break;

                    default:
                        Console.WriteLine("Введена неизвестная команда!");
                        break;
                }
            }
        }
    }

    public class DataBase
    {
        private Dictionary<ulong, Player> _players = new Dictionary<ulong, Player>();
        private HashSet<string> _occupiedNicknames = new HashSet<string>();
        private ulong _nextAvaliableID = 0;

        public DataBase(bool isFakePlayersNeeded = false)
        {
            if (isFakePlayersNeeded == true)
            {
                AppendPlayer(GetNextID(), "Destroyer", 5);
                AppendPlayer(GetNextID(), "Killer", 23);
                AppendPlayer(GetNextID(), "Rookie", 1);
                AppendPlayer(GetNextID(), "Provokator", 13);
            }
        }

        public void AddPlayer()
        {
            string playerName = GetPlayerNickname();
            int playerLevel = GetPlayerLevel();
            ulong playerID = GetNextID();

            AppendPlayer(playerID, playerName, playerLevel);

            Console.WriteLine($"Игрок добавлен. ID игрока: {playerID}");
        }

        public void RemovePlayer()
        {
            if (TryFindPlayerByID(out ulong playerID))
            {
                _occupiedNicknames.Remove(_players[playerID].Name);
                _players.Remove(playerID);

                Console.WriteLine($"Игрок c ID {playerID} удален.");
            }
            else
            {
                Console.WriteLine("Игрок с указанным ID не найден");
            }
        }

        public void BanPlayer()
        {
            if (TryFindPlayerByID(out ulong playerID))
            {
                if (_players[playerID].IsBanned)
                {
                    Console.WriteLine($"Игрок c ID {playerID} уже забанен.");

                    return;
                }

                _players[playerID].Ban();

                Console.WriteLine($"Игрок c ID {playerID} забанен.");
            }
            else
            {
                Console.WriteLine("Игрок с указанным ID не найден");
            }
        }

        public void UnbanPlayer()
        {
            if (TryFindPlayerByID(out ulong playerID))
            {
                if (_players[playerID].IsBanned)
                {
                    Console.WriteLine($"Игрок c ID {playerID} не забанен.");

                    return;
                }

                _players[playerID].Unban();

                Console.WriteLine($"Игрок c ID {playerID} разбанен.");
            }
            else
            {
                Console.WriteLine("Игрок с указанным ID не найден");
            }
        }

        public void ShowAllPlayers()
        {
            foreach (Player player in _players.Values)
            {
                Console.WriteLine($"Игрок {player.Name}. ID: {player.ID}. Уровень: {player.Level}");
            }
        }

        private string GetPlayerNickname()
        {
            string inputName;

            do
            {
                Console.Write("Введите никнейм игрока: ");
                inputName = Console.ReadLine();
            }
            while (IsValidNickName(inputName) == false);


            return inputName;
        }

        private bool IsValidNickName(string nickName)
        {
            if (string.IsNullOrEmpty(nickName) || int.TryParse(nickName, out int _))
            {
                Console.WriteLine("Введен некорректный никнейм!");
                return false;
            }

            if (_occupiedNicknames.Contains(nickName))
            {
                Console.WriteLine("Данный никнейм уже занят.");
                return false;
            }

            return true;
        }

        private int GetPlayerLevel()
        {
            int level;
            string inputLevel;

            do
            {
                Console.Write("Введите уровень игрока: ");
                inputLevel = Console.ReadLine();
            }
            while (IsValidLevel(inputLevel, out level) == false);

            return level;
        }

        private bool IsValidLevel(string inputlevel, out int level)
        {

            if (int.TryParse(inputlevel, out level) == false)
            {
                Console.WriteLine("Некорректный ввод! Значение должно быть числом.");
                return false;
            }

            if (level < 0)
            {
                Console.WriteLine("Значение уровня не может быть отрицательным!");
                return false;
            }

            return true;
        }

        private ulong GetNextID()
        {
            return _nextAvaliableID++;
        }

        private void AppendPlayer(ulong playerID, string playerName, int playerLevel)
        {
            _players.Add(playerID, new Player(playerID, playerName, playerLevel));
            _occupiedNicknames.Add(playerName);
        }

        private bool TryFindPlayerByID(out ulong id)
        {
            Console.Write("Введите ID игрока: ");
            string inputID = Console.ReadLine();

            if (ulong.TryParse(inputID, out id))
            {
                return _players.ContainsKey(id);
            }
            else
            {
                return false;
            }
        }
    }

    public class Player
    {
        public Player(ulong id, string nickName, int level)
        {
            ID = id;
            Name = nickName;
            Level = level;
            IsBanned = false;
        }

        public ulong ID { get; init; }
        public string Name { get; init; }
        public int Level { get; private set; }
        public bool IsBanned { get; private set; }

        public void Ban()
        {
            IsBanned = true;
        }

        public void Unban()
        {
            IsBanned = false;
        }
    }
}