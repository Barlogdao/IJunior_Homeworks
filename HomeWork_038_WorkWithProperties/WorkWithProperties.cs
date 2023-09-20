namespace HomeWork_038_WorkWithProperties
{
    internal class WorkWithProperties
    {
        static void Main(string[] args)
        {
            Drawer drawer = new Drawer();
            Player player = new Player(1, 2, '&');

            drawer.DrawPlayer(player);
        }
    }

    public class Drawer
    {
        public void DrawPlayer(Player player)
        {
            Console.SetCursorPosition(player.PositionX, player.PositionY);
            Console.Write(player.Symbol);
        }
    }

    public class Player
    {
        public Player(int positionX, int positionY, char symbol)
        {
            PositionX = positionX;
            PositionY = positionY;
            Symbol = symbol;
        }

        public int PositionX { get; private set; }
        public int PositionY { get; private set; }
        public char Symbol { get; private set; }
    }
}

