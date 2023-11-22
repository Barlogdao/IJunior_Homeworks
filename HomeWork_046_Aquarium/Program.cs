namespace HomeWork_047_Aquarium
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fishAmount = 4;
            Aquarium aquarium = new Aquarium(fishAmount);

            aquarium.Cycle();
        }
    }

    public class Aquarium
    {
        private List<Fish> _fishes;
        private int _capacity;

        public Aquarium(int fishesAmount)
        {
            _capacity = 10; 
            _fishes = new List<Fish>(_capacity);

            for (int i = 0; i < fishesAmount; i++)
            {
                _fishes.Add(FishFabric.CreateFish());
            }          
        }

        public bool HasSpace => _fishes.Count < _capacity;

        public void Cycle()
        {
            const string CommandAddFish = "1";
            const string CommandRemoveFish = "2";
            const string CommandWait = "3";
            const string CommandExit = "0";

            string commandMessage = $"\nВведите команду:" +
                $"\n[{CommandAddFish}] - Добавить рыбку в аквариум." +
                $"\n[{CommandRemoveFish}] - Убрать рыбку из аквариума." +
                $"\n[{CommandWait}] - Подождать." +
                $"\n[{CommandExit}] - Выйти" +
                $"\n";
            bool isRun = true;

            while (isRun)
            {
                DisplayInfo();

                Console.WriteLine(commandMessage);

                Console.Write("Ваш выбор: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case CommandAddFish:
                        AddFish();
                        break;

                    case CommandRemoveFish:
                        RemoveFish();
                        break;

                    case CommandWait:
                        Tick();
                        break;

                    case CommandExit:
                        isRun = false;
                        break;

                    default:
                        Console.WriteLine("Введена невреная команда!");
                        break;
                }

                Console.WriteLine("Нажмите любую клавишу чтобы продолжить");
                Console.ReadKey();

                

                Console.Clear();
            }
        }

        public void AddFish()
        {
            if (HasSpace)
            {
                Fish fish = FishFabric.CreateFish();
                _fishes.Add(fish);

                Console.WriteLine($"Вы поместили в аквариум {fish.Name}");
            }
            else
            {
                Console.WriteLine("В аквариуме нет места для новой рыбы");
            }
        }

        public void RemoveFish()
        {
            if (_fishes.Count == 0)
            {
                Console.WriteLine("В аквариуме нет рыбок.");

                return;
            }

            Fish fish = ChooseFish();
            _fishes.Remove(fish);

            Console.WriteLine($"Вы вынули {fish.Name}");
        }

        public void Tick()
        {
            foreach (Fish fish in _fishes)
            {
                fish.Tick();
            }
        }

        public void DisplayInfo()
        {
            int indexOffset = 1;

            Console.WriteLine($"Рыбок в аквариуме {_fishes.Count}");

            for (int i = 0; i < _fishes.Count; i++)
            {
                Console.WriteLine($"[{i + indexOffset}] - {_fishes[i]}");
            }
        }

        private Fish ChooseFish()
        {
            Fish fish = null;
            int inputNumber;

            while (fish == null)
            {
                Console.Write("Укажите номер рыбки в аквариуме, которую хотите вынуть ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out inputNumber) == false)
                {
                    Console.WriteLine("Небходимо ввести число");
                }
                else
                {
                    TryFindFish(inputNumber, ref fish);
                }
            }

            return fish;
        }

        private bool TryFindFish(int number, ref Fish fish)
        {
            int fishIndex = number - 1;

            if (fishIndex < 0 || fishIndex >= _fishes.Count)
            {
                Console.WriteLine("В аквариуме нет рыбки с указанным номером");
                return false;
            }

            fish = _fishes[fishIndex];
            return true;
        }
    }


    public static class FishFabric
    {
        private static readonly int s_minAge = 1;
        private static readonly int s_maxAge = 3;
        private static readonly int s_minOldnessAge = 8;
        private static readonly int s_maxOldnessAge = 10;

        private static readonly string[] s_fishNames = new string[] { "Дори", "Партос", "Кукуй", "Миска", "Плывун", "Лизун", "Мидас" };

        public static Fish CreateFish()
        {
            return new Fish(RandomUtils.GetRandomNumber(s_minAge, s_maxAge),
                            RandomUtils.GetRandomNumber(s_minOldnessAge, s_maxOldnessAge),
                            s_fishNames[RandomUtils.GetRandomNumber(s_fishNames.Length)]);
        }
    }

    public class Fish
    {
        private static int s_DeathChance = 20;

        private readonly int _oldnessAge;

        private int _age;
        private bool _isDead = false;

        public Fish(int age, int oldnessAge, string name)
        {
            Name = name;
            _age = age;
            _oldnessAge = oldnessAge;
        }

        public string Name { get; }

        public override string ToString()
        {
            return $"рыбка {Name}. Возраст {_age} лет. Статус: {GetStatus()}";
        }

        public void Tick()
        {
            if (_isDead)
            {
                return;
            }

            _age++;

            if (_age > _oldnessAge)
            {
                DeathCheck();
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"рыбка {Name}. Возраст {_age} лет. Статус: {GetStatus()}");
        }

        private string GetStatus() => _isDead ? "Мертвая" : "Живая";

        private void DeathCheck()
        {
            if (RandomUtils.GetRandomPercentValue() <= s_DeathChance)
            {
                Die();
            }
        }

        private void Die()
        {
            _isDead = true;
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

        public static int GetRandomPercentValue()
        {
            int maxPercent = 100;

            return s_random.Next(maxPercent + 1);
        }
    }
}