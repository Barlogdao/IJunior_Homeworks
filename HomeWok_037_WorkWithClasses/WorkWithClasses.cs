namespace HomeWork_037_WorkWithClasses
{
    internal class WorkWithClasses
    {
        static void Main(string[] args)
        {
            Player player = new Player("Виктор", "Хаотично-добрый", 5, 300);
            player.ShowInfo();
        }

        public class Player
        {
            private string _name;
            private string _alignment;
            private int _level;
            private int _health;

            public Player(string name, string alignment, int level, int health)
            {
                _name = name;
                _alignment = alignment;
                _level = level;
                _health = health;
            }

            public void ShowInfo()
            {
                Console.WriteLine($"Игрок: {_name}\nМировоззрение: {_alignment}\nУровень: {_level}\nЗдоровье: {_health}");
            }
        }
    }
}