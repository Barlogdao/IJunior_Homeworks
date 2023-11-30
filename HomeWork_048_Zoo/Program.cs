namespace HomeWork_048_Zoo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();

            zoo.Visit();

            Console.ReadKey();
        }
    }

    public class Zoo
    {
        private readonly List<Aviary> _aviaries;

        public Zoo()
        {
            int minAnimalsInAviary = 3;
            int maxAnimalsInAviary = 9;
            Animal[] animals = new Animal[] { new Donkey(), new Bear(), new Owl(), new Ostrich() };

            _aviaries = new List<Aviary>(animals.Length);

            foreach (Animal animal in animals)
            {
                _aviaries.Add(new Aviary(animal, RandomUtils.GetRandomNumber(minAnimalsInAviary, maxAnimalsInAviary + 1)));
            }
        }

        public void Visit()
        {
            const string CommandExit = "0";

            bool isRun = true;

            Console.WriteLine("Добро пожаловать в зоопарк!");

            while (isRun)
            {
                Console.WriteLine("\nВы стоите на центральной площади. Вдалеке видны вольеры с животными");

                Console.Write($"Введите номер вольера от [1] до [{_aviaries.Count}], чтобы подойдти поближе" +
                    $"\nили [{CommandExit}] для выхода из зоопарка ");
                string input = Console.ReadLine();

                if (input == CommandExit)
                {
                    isRun = false;

                    Console.WriteLine("Вы выходите из зоопарка");
                }
                else
                {
                    HandleInput(input);
                }
            }
        }

        private void HandleInput(string input)
        {
            if (int.TryParse(input, out int number))
            {
                int aviaryIndex = number - 1;

                if (aviaryIndex < 0 || aviaryIndex >= _aviaries.Count)
                {
                    Console.WriteLine("В зоопарке нет вольера с указанным номером");
                }
                else
                {
                    _aviaries[aviaryIndex].Visit();
                }
            }
            else
            {
                Console.WriteLine("Необходимо ввести число.");
            }
        }
    }

    public class Aviary
    {
        private readonly List<Animal> _animals;
        private readonly string _type;
        private readonly string _animalSound;
        private readonly int _maleAnimalsAmount;
        private readonly int _femaleAnimalsAmount;

        public Aviary(Animal animal, int animalsAmount)
        {
            _type = animal.Type;
            _animalSound = animal.Sound;
            _animals = new List<Animal>(animalsAmount);

            for (int i = 0; i < animalsAmount; i++)
            {
                _animals.Add(animal.Clone());
            }

            _maleAnimalsAmount = CountAnimalsByGender(Gender.Male);
            _femaleAnimalsAmount = CountAnimalsByGender(Gender.Female);
        }

        public void Visit()
        {
            Console.WriteLine($"\nВ вольере живут {_type}");
            Console.WriteLine($"Количество животных в вольере: {_animals.Count}");
            Console.WriteLine($"Из них самцов: {_maleAnimalsAmount}, самок: {_femaleAnimalsAmount}");
            Console.WriteLine($"Животные издают звук \"{_animalSound}\".");

            Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться на главную площадь");
            Console.ReadKey();
        }

        private int CountAnimalsByGender(Gender gender)
        {
            int counter = 0;

            foreach (Animal animal in _animals)
            {
                if (animal.Gender == gender)
                {
                    counter++;
                };
            }

            return counter;
        }
    }

    public abstract class Animal
    {
        private static Gender[] s_genders; 

        static Animal()
        {
            s_genders = new Gender[] { Gender.Male, Gender.Female };
        }            

        public Animal(string type, string sound)
        {
            Type = type;
            Sound = sound;
            Gender = GetRandomGender();
        }

        public string Type { get; private set; }
        public string Sound { get; private set; }
        public Gender Gender { get; private set; }

        public abstract Animal Clone();

        private Gender GetRandomGender()
        {
            return s_genders[RandomUtils.GetRandomNumber(s_genders.Length)];
        }
    }

    public class Donkey : Animal
    {
        public Donkey() : base("ослы", "Иа-иа") { }

        public override Animal Clone()
        {
            return new Donkey();
        }
    }

    public class Bear : Animal
    {
        public Bear() : base("медведи", "Аррр") { }

        public override Animal Clone()
        {
            return new Bear();
        }
    }

    public class Owl : Animal
    {
        public Owl() : base("совы", "Ууух") { }

        public override Animal Clone()
        {
            return new Owl();
        }
    }

    public class Ostrich : Animal
    {
        public Ostrich() : base("страусы", "Курлык") { }

        public override Animal Clone()
        {
            return new Ostrich();
        }
    }

    public enum Gender
    {
        Male,
        Female
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