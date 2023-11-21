namespace HomeWork_046_War
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int squadSize = 10;
            Squad firstSquad = SquadFabric.CreateSquad(squadSize);
            Squad secondSquad = SquadFabric.CreateSquad(squadSize);
            Battlefield battlefield = new Battlefield(firstSquad, secondSquad);

            battlefield.StartBattle();

            Console.ReadKey();
        }
    }

    public class Battlefield
    {
        private readonly Squad _firstSquad;
        private readonly Squad _secondSquad;

        public Battlefield(Squad firstSquad, Squad secondSquad)
        {
            _firstSquad = firstSquad;
            _secondSquad = secondSquad;
        }

        public void StartBattle()
        {
            Console.WriteLine($"Сражается взвод \"{_firstSquad.Name}\" и взвод \"{_secondSquad.Name}\"");
            Console.WriteLine("Война началась!");

            WaitForInput();

            while (_firstSquad.IsAlive && _secondSquad.IsAlive)
            {
                _firstSquad.Attack(_secondSquad);
                _secondSquad.Attack(_firstSquad);
            }

            ShowBattleResult();
        }

        private void ShowBattleResult()
        {
            if (_firstSquad.IsAlive)
                Console.WriteLine($"Победил взвод {_firstSquad.Name}");
            else if (_secondSquad.IsAlive)
                Console.WriteLine($"Победил взвод {_secondSquad.Name}");
            else
                Console.WriteLine("Оба взвода уничтожены");
        }

        private void WaitForInput()
        {
            Console.WriteLine("\nНажмите любую клавишу чтобы продолжить\n");
            Console.ReadKey();
        }
    }

    public class Squad
    {
        private readonly List<Soldier> _soldiers;

        public Squad(string name, int squadSize)
        {
            Name = name;
            _soldiers = new List<Soldier>(squadSize);

            for (int i = 0; i < squadSize; i++)
            {
                _soldiers.Add(SoldierFabric.CreateSoldier());
            }
        }

        public string Name { get; }
        public int Size => _soldiers.Count;
        public bool IsAlive => Size > 0;

        public void Attack(Squad enemy)
        {
            if (IsAlive)
            {
                Soldier damageDealer = _soldiers[RandomUtils.GetRandomNumber(_soldiers.Count)];

                Console.WriteLine($"{damageDealer.Name} из взвода {Name} атакует взвод {enemy.Name}");

                enemy.TakeDamage(damageDealer.Type, damageDealer.Damage);
            }
            else
            {
                Console.WriteLine($"Во взводе {Name} больше не осталось солдат!");
            }
        }

        public void TakeDamage(SoldierType sourceType, int damage)
        {
            Soldier target = _soldiers[RandomUtils.GetRandomNumber(_soldiers.Count)];

            Console.WriteLine($"{target.Name} из взвода {Name} атакован");

            target.TakeDamage(sourceType, damage);

            if (!target.IsAlive)
            {
                Console.WriteLine($"{target.Name} из взвода {Name} умирает");
                _soldiers.Remove(target);
            }
        }
    }

    public abstract class Soldier
    {
        private readonly SoldierType _weaknessType;
        private int _health;

        public Soldier(int damage, int health, SoldierType type, SoldierType weaknessType, string name)
        {
            Damage = damage;
            _health = health;
            Type = type;
            _weaknessType = weaknessType;
            Name = name;
        }

        public string Name { get; }
        public int Damage { get; }
        public SoldierType Type { get; }
        public bool IsAlive => _health > 0;

        public void TakeDamage(SoldierType sourceType, int damage)
        {
            int resultDamage = sourceType == _weaknessType ? damage * 2 : damage;

            Console.WriteLine($"{Name} получает {resultDamage} урона");

            _health -= resultDamage;
        }
    }

    public class Shooter : Soldier
    {
        public Shooter() : base(6, 10, SoldierType.Shooter, SoldierType.Artillery, "Стрелок") { }
    }

    public class Assault : Soldier
    {
        public Assault() : base(4, 12, SoldierType.Assault, SoldierType.Shooter, "Штурмовик") { }
    }

    public class Artillery : Soldier
    {
        public Artillery() : base(8, 8, SoldierType.Artillery, SoldierType.Assault, "Артиллерия") { }
    }

    public enum SoldierType
    {
        Shooter,
        Assault,
        Artillery
    }

    public static class SquadFabric
    {
        private static readonly string[] s_squadNames = new string[] { "Беларусь", "Катай", "Мыши", "РА-СИ-Я", "Удар", "Висок", "Песок", "Жуки" };

        public static Squad CreateSquad(int squadSize)
        {
            return new Squad(GetSquadName(), squadSize);
        }

        private static string GetSquadName()
        {
            return s_squadNames[RandomUtils.GetRandomNumber(s_squadNames.Length)];
        }
    }

    public static class SoldierFabric
    {
        private static readonly int s_soldierTypesAmount = 3;

        public static Soldier CreateSoldier()
        {
            return RandomUtils.GetRandomNumber(s_soldierTypesAmount) switch
            {
                0 => new Shooter(),
                1 => new Assault(),
                2 => new Artillery(),
                _ => throw new Exception("Ошибка при создании солдата. Проверьте количество типов солдат"),
            };
        }
    }

    public static class RandomUtils
    {
        private static readonly Random s_random = new Random();

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
