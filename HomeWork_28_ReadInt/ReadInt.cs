namespace HomeWork_29_ReadInt
{
    internal class ReadInt
    {
        static void Main(string[] args)
        {
            int number = GetNumber();

            Console.WriteLine($"Ура, вы ввели число {number}!");
            Console.ReadKey();
        }
        static private int GetNumber()
        {
            int inputNumber;

            do
            {
                Console.Write("Введите число:");
            }
            while (int.TryParse(Console.ReadLine(), out inputNumber) == false);

            return inputNumber;
        }
    }
}