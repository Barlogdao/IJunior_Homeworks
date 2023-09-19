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
            private int _positionX;
            private int _positionY;
            private char _symbol;

            public Player(int positionX, int positionY, char symbol)
            {
                _positionX = positionX;
                _positionY = positionY;
                _symbol = symbol;
            }

            public int PositionX => _positionX;
            public int PositionY => _positionY;
            public char Symbol => _symbol;
        }
    }
}