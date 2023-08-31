using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int CommandDollar = 1;
            const int CommandEuro = 2;
            const int CommandRuble = 3;
            const int CommandExit = 4;



            decimal dollarWallet = 100;
            decimal euroWallet = 200;
            decimal rubleWallet = 50000;

            const float DollarToEuroCoefficient = 0.9f;
            const float DollarToRubleCoefficient = 100f;
            const float DollarToDollarCoefficient = 1f;
            const float EuroToRubleCoefficient = 102f;
            const float EuroToDollarCoefficient = 1.1f;
            const float EuroToEuroCoefficient = 1f;
            const float RubleToDollarCoefficient = 0.01f;
            const float RubleToEuroCoefficient = 0.012f;
            const float RubleToRubleCoefficient = 1f;


            Console.WriteLine($"Ваш баланс:\n{dollarWallet} долларов\n{euroWallet} евро\n{rubleWallet} рублей");
            Console.WriteLine($"Какую валюту хотите конвертировать?\nдоллары - 1\nевро - 2\nрубли - 3\nвыйти - 4");
            int input = int.Parse(Console.ReadLine());
            decimal fromCurrency = 0;
            decimal toCurrency = 0;
            int convertAmount;

            switch (input)
            {
                case CommandDollar:
                    fromCurrency = dollarWallet;
                    break;
                case CommandEuro:
                    fromCurrency = euroWallet;
                    break;
                case CommandRuble:
                    fromCurrency = rubleWallet;
                    break;
                case CommandExit: return;
            }


            Console.WriteLine($"Сколько хотите конвертировать");
            input = int.Parse(Console.ReadLine());

            while ( input < fromCurrency) 
            {
                Console.WriteLine($"У вас не хватает средств!");
                Console.WriteLine($"Ваш баланс:\n{dollarWallet} долларов\n{euroWallet} евро\n{rubleWallet} рублей");
                Console.WriteLine($"Сколько хотите конвертировать");
                input = int.Parse(Console.ReadLine());
            }

            convertAmount = input;


            Console.WriteLine($"В Какую валюту хотите конвертировать?\nдоллары - 1\nевро - 2\nрубли - 3");
            input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case CommandDollar:
                    toCurrency = dollarWallet;
                    break;
                case CommandEuro:
                    toCurrency = euroWallet;
                    break;
                case CommandRuble:
                    toCurrency = rubleWallet;
                    break;
            }
            Console.WriteLine($"Сколько хотите конвертировать");
            input = int.Parse(Console.ReadLine());
            


        }
    }
}
