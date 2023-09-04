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
            const int MenuExit = 0;
            const int MenuDollar = 1;
            const int MenuEuro = 2;
            const int MenuRuble = 3;



            const string ConverToRubleCommand = "рубль";
            const string ConertToEuroCommand = "евро";
            const string ConvertToDollarCommand = "доллар";

            const float DollarToEuroCoefficient = 0.9f;
            const float DollarToRubleCoefficient = 100f;
            const float EuroToRubleCoefficient = 102f;
            const float EuroToDollarCoefficient = 1.1f;
            const float RubleToDollarCoefficient = 0.01f;
            const float RubleToEuroCoefficient = 0.012f;

            //const string StartOperationChoiseMessage = $"Выберите операцию:\n{MenuDollar} - конвертировать доллары\n{MenuEuro} - конвертировать евро\n{MenuRuble} - конвертировать рубли\n{MenuExit} - выйти";

            const string WrongCommand = "Некорректная команда!";

            float dollarWallet = 100;
            float euroWallet = 200;
            float rubleWallet = 50000;


            decimal fromCurrency = 0;
            decimal toCurrency = 0;
            int convertAmount;

            while (true)
            {
                Console.WriteLine($"Ваш баланс:{dollarWallet} долларов, {euroWallet} евро, {rubleWallet} рублей.");
                Console.WriteLine($"Выберите операцию:\n{MenuDollar} - конвертировать доллары\n{MenuEuro} - конвертировать евро\n{MenuRuble} - конвертировать рубли\n{MenuExit} - выйти");
                int input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case MenuDollar:
                        Console.WriteLine("Выбраны доллары");
                        Console.Write("Сколько долларов вы хотите обменять? ");
                        float exchangeAmount = float.Parse(Console.ReadLine());

                        while (exchangeAmount > dollarWallet)
                        {
                            Console.WriteLine("Не достаточно средств для совершения операции!");
                            Console.Write("Сколько долларов вы хотите обменять? ");
                            exchangeAmount = float.Parse(Console.ReadLine());
                        }

                        Console.WriteLine($"Выбрано {exchangeAmount} долларов");
                        Console.WriteLine($"Курс обмена\n{DollarToEuroCoefficient} евро за доллар;\n{DollarToRubleCoefficient} рублей за доллар");
                        Console.WriteLine($"В какую валюту хотите конвертировать доллары?\n{ConverToRubleCommand} - в рубли\n{ConertToEuroCommand} - в евро");

                        string inputCommand = Console.ReadLine();

                        switch (inputCommand)
                        {
                            case ConverToRubleCommand:
                                dollarWallet -= exchangeAmount;
                                rubleWallet += exchangeAmount * DollarToRubleCoefficient;
                                Console.WriteLine($"Конвертация прошла успешно!");
                                Console.WriteLine($"Ваш баланс:{dollarWallet} долларов, {euroWallet} евро, {rubleWallet} рублей.");

                                break;
                            case ConertToEuroCommand:
                                break;
                            default:
                                Console.WriteLine(WrongCommand);
                                break;
                        }


                        break;
                    case MenuEuro:

                        break;
                    case MenuRuble:

                        break;
                    case MenuExit: return;
                    default:
                        Console.WriteLine(WrongCommand);
                        break;
                }
            }




        }
    }
}
