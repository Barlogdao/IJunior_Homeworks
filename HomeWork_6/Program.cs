using System;

namespace HomeWork_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int receptionDuration = 10;
            const int minutesInHour = 60;

            Console.Write("Введите количество старушек: ");
            int  granniesAmount = int.Parse(Console.ReadLine());

            int totalTime = granniesAmount * receptionDuration;
            int hoursToReception = totalTime / minutesInHour;
            int minutesToReception = totalTime % minutesInHour;
            Console.WriteLine($"Вы должны отстоять в очереди {hoursToReception} часа и {minutesToReception} минут.");
        }
    }
}
