namespace HomeWork_039_PlayersDataBase
{
    internal class PlayersDataBase
    {
        static void Main(string[] args)
        {
            const string CommandAddPlayer = "0";
            const string CommandRemovePlayer = "1";
            const string CommandBanPlayer = "2";
            const string CommandUnbanPlayer = "3";
            const string CommandExit = "4";

            bool isExitRequested;

            Console.WriteLine("Выберите ");

        }

       
    }

    public class DataBase
    {
        private Dictionary<ulong, Player> _players = new Dictionary<ulong, Player>();
        private HashSet<string> _occupiedNicknames = new HashSet<string>();
        private ulong _nextAvaliableID = 0;
        public void AddPlayer()
        {
            string playerName = GetPlayerNickname();
            int playerLevel = GetPlayerLevel();
            ulong playerID = GetNextID();

            _players.Add(playerID, new Player(playerID, playerName, playerLevel));
            _occupiedNicknames.Add(playerName);
        }

        public void RemovePlayer()
        {
            if (TryFindPlayerByID(out ulong playerID))
            {
                _occupiedNicknames.Remove(_players[playerID].Name);
                _players.Remove(playerID);
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
                _players[playerID].Ban();
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
                _players[playerID].Unban();
            }
            else
            {
                Console.WriteLine("Игрок с указанным ID не найден");
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
            while (IsValidLevel(inputLevel, out level));

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
        private readonly ulong _id;
        private readonly string _nickName;
        private int _level;
        private bool _isBanned = false;

        public Player(ulong id, string nickName, int level)
        {
            _id = id;
            _nickName = nickName;
            _level = level;
        }

        public ulong ID => _id;
        public string Name => _nickName;
        public int Level => _level;
        public bool IsBanned => _isBanned;

        public void Ban()
        {
            _isBanned = true;
        }

        public void Unban()
        {
            _isBanned = false;
        }
    }
}