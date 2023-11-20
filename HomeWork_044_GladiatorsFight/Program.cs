namespace HomeWork_044_GladiatorsFight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FighterLobby fighterLobby = new FighterLobby();
            fighterLobby.PrepareFighters();

            Pit pit = new Pit(fighterLobby.FirstFighter, fighterLobby.SecondFighter);
            pit.StartFight();
        }
    }

    public class FighterLobby
    {
        private const string CommandWarrior = "1";
        private const string CommandVampire = "2";
        private const string CommandDuelist = "3";
        private const string CommandBloodWizard = "4";
        private const string CommandBandit = "5";

        private Dictionary<string, Fighter> _fighters = new()
        {
            { CommandWarrior, new Warrior() },
            { CommandVampire, new Vampire() },
            { CommandDuelist, new Duelist() },
            { CommandBloodWizard, new BloodWizard() },
            { CommandBandit, new Bandit() },
        };

        public Fighter FirstFighter { get; private set; }
        public Fighter SecondFighter { get; private set; }

        public void PrepareFighters()
        {
            Console.WriteLine("Добро пожаловать в Яму!");

            ShowFighters();
            SelectFighters();
        }

        private void ShowFighters()
        {
            Console.WriteLine("Выберите гладиаторов для сражения в Яме:");

            foreach (string fighterKey in _fighters.Keys)
            {
                Console.Write($"[{fighterKey}] - ");
                _fighters[fighterKey].ShowInfo();
            }
        }

        private void SelectFighters()
        {
            FirstFighter = GetFighter("\nВыберите первого гладиатора: ");
            SecondFighter = GetFighter("\nВыберите второго гладиатора: ");
        }

        private Fighter GetFighter(string message)
        {
            Fighter fighter = null;

            while (fighter == null)
            {
                Console.Write(message);
                string input = Console.ReadLine();

                fighter = input switch
                {
                    CommandWarrior => new Warrior(),
                    CommandVampire => new Vampire(),
                    CommandBloodWizard => new BloodWizard(),
                    CommandDuelist => new BloodWizard(),
                    CommandBandit => new Bandit(),
                    _ => null
                };

                if (fighter == null)
                {
                    Console.WriteLine("Введена неверная команда!");
                }
            }

            Console.WriteLine($"{fighter} выходит на арену");

            return fighter;
        }
    }

    public class Pit
    {
        private Fighter _firstFighter;
        private Fighter _secondFighter;

        public Pit(Fighter firstFighter, Fighter secondFighter)
        {
            _firstFighter = firstFighter;
            _secondFighter = secondFighter;
        }

        public void StartFight()
        {
            Console.WriteLine("\nБитва Началась!");

            WaitForInput();

            while (_firstFighter.IsAlive && _secondFighter.IsAlive)
            {
                Console.WriteLine($"{_firstFighter} атакует {_secondFighter}");
                _firstFighter.Attack(_secondFighter);

                WaitForInput();

                Console.WriteLine($"{_secondFighter} атакует {_firstFighter}");
                _secondFighter.Attack(_firstFighter);

                WaitForInput();
            }

            ShowFightResult();
        }

        private void WaitForInput()
        {
            Console.WriteLine("\nНажмите любую клавишу чтобы продолжить");
            Console.ReadKey();
        }

        private void ShowFightResult()
        {
            Console.WriteLine("Битва окончена!");

            if (_firstFighter.IsAlive)
            {
                Console.WriteLine($"Победил {_firstFighter}");
            }
            else if (_secondFighter.IsAlive)
            {
                Console.WriteLine($"Победил {_secondFighter}");
            }
            else
            {
                Console.WriteLine("Оба гладиатора погибли. Несите новых!");
            }
        }
    }

    public abstract class Fighter
    {
        protected readonly int MaxHealth;
        protected int CurrentHealth;
        protected readonly int Damage;
        protected readonly string Name;

        public Fighter(int health, int damage)
        {
            MaxHealth = health;
            CurrentHealth = MaxHealth;
            Damage = damage;
            Name = NameGenerator.GetName();
        }

        public bool IsAlive => CurrentHealth > 0;
        public abstract string Class { get; }

        protected abstract string AbilityInfo { get; }

        public void ShowInfo()
        {
            Console.WriteLine($"{Class}. Здоровье: {MaxHealth}. Урон: {Damage}. {AbilityInfo}");
        }

        public virtual void Attack(Fighter enemy)
        {
            enemy.TakeDamage(Damage);
        }

        public virtual void TakeDamage(int damage)
        {
            CurrentHealth -= Math.Max(0, damage); ;
            Console.WriteLine($"{this} получил {damage} урона");
        }

        public override string ToString()
        {
            return $"{Class} {Name}";
        }
    }

    public class Warrior : Fighter
    {
        private readonly int _armor;

        public Warrior() : base(100, 18)
        {
            _armor = 3;
        }

        public override string Class => "Воин";

        protected override string AbilityInfo => $"Броня: Уменьшает получаемый урон на {_armor}";

        public override void TakeDamage(int damage)
        {
            CurrentHealth -= Math.Max(0, damage - _armor); ;
            Console.WriteLine($"{this} получил {damage - _armor} урона");
        }
    }

    public class Vampire : Fighter
    {
        private readonly int _healAmount;
        private readonly int _healChance;
        private readonly int _maxHealChance = 100;

        public Vampire() : base(70, 15)
        {
            _healAmount = 10;
            _healChance = 30;
        }

        public override string Class => "Вампир";
        protected override string AbilityInfo => $"Лечение: Шанс {_healChance}% восстановить при атаке {_healAmount} здоровья ";

        public override void Attack(Fighter enemy)
        {
            TryHeal();
            enemy.TakeDamage(Damage);
        }

        private void TryHeal()
        {
            if (RandomProvider.Random.Next(_maxHealChance + 1) <= _healChance)
            {
                int restoredHealth = (CurrentHealth + _healAmount) > MaxHealth ? MaxHealth - CurrentHealth : _healAmount;
                CurrentHealth += restoredHealth;

                Console.WriteLine($"{this} восстановил {restoredHealth} здоровья.");
            }
        }
    }

    public class Duelist : Fighter
    {
        private readonly int _maxAttackCounter;
        private int _attackCounter = 0;
        private readonly int _damageMultiplier;

        public Duelist() : base(80, 14)
        {
            _maxAttackCounter = 3;
            _damageMultiplier = 2;
        }

        public override string Class => "Дуэлянт";
        protected override string AbilityInfo => $"Концентрация: Каждая {_maxAttackCounter} атака наносит {Damage * _damageMultiplier} урона";

        public override void Attack(Fighter enemy)
        {
            _attackCounter++;

            if (_attackCounter >= _maxAttackCounter)
            {
                _attackCounter = 0;

                Console.WriteLine($"{this} наносит критический урон!");

                enemy.TakeDamage(Damage * _damageMultiplier);
            }
            else
            {
                enemy.TakeDamage(Damage);
            }
        }
    }

    public class BloodWizard : Fighter
    {
        private readonly int _maxBloodPoints;
        private int _currentBloodPoints = 0;

        public BloodWizard() : base(120, 10)
        {
            _maxBloodPoints = 45;
        }

        public override string Class => "Маг крови";
        protected override string AbilityInfo => $"Щит Крови: получаемый урон гененрирует очки Крови." +
            $" Заряженный Щит Крови ({_maxBloodPoints} очков Крови) предотвращает урон от следующей атаки.";

        public override void TakeDamage(int damage)
        {
            if (_currentBloodPoints >= _maxBloodPoints)
            {
                Console.WriteLine($"{this} использовал Щит Крови. Урон предотвращен");

                _currentBloodPoints = 0;
            }
            else
            {
                CurrentHealth -= Math.Max(0, damage);

                Console.WriteLine($"{this} получил {damage} урона");

                _currentBloodPoints += damage;

                if (_currentBloodPoints >= _maxBloodPoints)
                {
                    Console.WriteLine($"{this} зарядил Щит Крови");
                }
            }
        }
    }

    public class Bandit : Fighter
    {
        private int _bonusDamage = 0;

        public Bandit() : base(90, 13) { }

        public override string Class => "Бандит";
        protected override string AbilityInfo => $"Возмездие: Получение урона увеличивает наносимый урон на 1";

        public override void Attack(Fighter enemy)
        {
            enemy.TakeDamage(Damage + _bonusDamage);
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            _bonusDamage++;
        }
    }

    public static class NameGenerator
    {
        private static string[] _names = new string[]
        {
            "Василий",
            "Максимус",
            "Страус",
            "Глок",
            "Эскимо"
        };

        public static string GetName()
        {
            return _names[RandomProvider.Random.Next(0, _names.Length)];
        }
    }

    public static class RandomProvider
    {
        private static Random _random = new Random();

        public static Random Random => _random;
    }
}