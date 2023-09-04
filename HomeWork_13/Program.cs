namespace HomeWork_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите ваше имя: ");
            string name = Console.ReadLine();
            
            Console.Write("Введите любой символ: ");
            char decorator = Convert.ToChar(Console.Read());

            int boarderLenght = name.Length + 2;

            for (int i = 0; i < boarderLenght; i++)
                Console.Write(decorator);

            Console.WriteLine();
            Console.WriteLine(decorator + name + decorator);

            for (int i = 0; i < boarderLenght; i++)
                Console.Write(decorator);
        }
    }
}