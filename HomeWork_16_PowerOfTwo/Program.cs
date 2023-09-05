namespace HomeWork_16_PowerOfTwo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int number = random.Next();

            int baseNumber = 2;
            int exponent = 1;
            int calculatedNumber = baseNumber;
            
            while (calculatedNumber <= number)
            {
                calculatedNumber *= baseNumber;
                exponent++;
            };
            
            Console.WriteLine($"число: {number}");
            Console.WriteLine($"ближайшая степень {baseNumber} после числа: {exponent}");
            Console.WriteLine($"результат возведения {baseNumber} в степень {exponent}: {calculatedNumber}");
        }
    }
}