namespace HomeWork_047_Aquarium
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class Aquarium
    {

    }


    public class FishFabric
    {
        private int _maxFishAge;
        private int _minFishAge;
        private string[] _fishNames = new string[] { "Дори", "Партос", "Кукуй", "Миска", "Плывун", "Лизун", "Мидас" };
        public Fish CreateFish()
        {
            return new Fish(4,
                RandomUtils.GetRandomNumber(_minFishAge, _maxFishAge), 
                _fishNames[RandomUtils.GetRandomNumber(_fishNames.Length)]);
        }
    }

    public class Fish
    {
        private static int s_DeathChance = 20;

        private readonly int _maxAge;
        private readonly string _name;

        private int _age;
        private bool _isDead = false;

        public Fish(int age, int maxAge, string name)
        {
            _name = name;
            _age = age;
            _maxAge = maxAge;

            if (_age > maxAge)
            {
                _age = maxAge;
            }
        }

        public void Tick()
        {
            if (_isDead)
            {
                return;
            }

            _age++;

            if (_age > _maxAge)
            {
                DeathCheck();
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"рыбка {_name}. Возраст {_age} лет. Статус: {GetStatus()}");
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


        public override string ToString()
        {
            return $"рыбка {_name}. Возраст {_age} лет. Статус: {GetStatus()}";
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
            return (int)(s_random.NextDouble() * 100);
        }
    }
}
//Есть аквариум, в котором плавают рыбы. В этом аквариуме может быть максимум определенное кол-во рыб.
//Рыб можно добавить в аквариум или рыб можно достать из аквариума. (программу делать в цикле для того, чтобы рыбы могли “жить”) 

//Все рыбы отображаются списком, у рыб также есть возраст.
//За 1 итерацию рыбы стареют на определенное кол-во жизней и могут умереть.
//Рыб также вывести в консоль, чтобы можно было мониторить показатели.