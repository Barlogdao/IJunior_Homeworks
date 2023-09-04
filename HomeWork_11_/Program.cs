
namespace HomeWork_11
{
    internal class Program
    {
        static void Start()
        {
            const string ExitCommand = "выход";
            const string DollarCommand = "доллар";
            const string EuroCommand = "евро";
            const string RubleCommand = "рубль";

            const float DollarToEuroCoefficient = 0.9f;
            const float DollarToRubleCoefficient = 100f;
            const float EuroToRubleCoefficient = 102.3f;
            const float EuroToDollarCoefficient = 1.1f;
            const float RubleToDollarCoefficient = 0.01f;
            const float RubleToEuroCoefficient = 0.012f;

            const string WrongCommandMessage = "Некорректная команда!";
            const string AmountRequestMessage = "Какую сумму вы хотите обменять? ";
            const string IncorrectMoneyAmountMessage = "Введена некорркетная сумма!";
            const string ConvertationSuccessMessage = "Конвертация прошла успешно!";

            float dollarWallet = 100;
            float euroWallet = 200;
            float rubleWallet = 50000;

            Console.WriteLine("Добро пожаловать в чудо-обменник!");

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"Ваш баланс:{dollarWallet} долларов, {euroWallet} евро, {rubleWallet} рублей.");
                Console.WriteLine($"\nВыберите операцию:\n[{DollarCommand}] - конвертировать доллары\n[{EuroCommand}] - конвертировать евро\n[{RubleCommand}] - конвертировать рубли\n[{ExitCommand}] - выйти");
                string input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case DollarCommand:
                        Console.WriteLine("Выбраны доллары");
                        Console.Write(AmountRequestMessage);
                        float exchangeCurrencyAmount = float.Parse(Console.ReadLine());

                        while (exchangeCurrencyAmount > dollarWallet || exchangeCurrencyAmount < 0)
                        {
                            Console.WriteLine(IncorrectMoneyAmountMessage);
                            Console.Write(AmountRequestMessage);
                            exchangeCurrencyAmount = float.Parse(Console.ReadLine());
                        }

                        Console.WriteLine($"\nКурс обмена\n{DollarToEuroCoefficient} евро за доллар;\n{DollarToRubleCoefficient} рублей за доллар");
                        Console.WriteLine($"\nВ какую валюту хотите конвертировать?\n[{RubleCommand}] - в рубли\n[{EuroCommand}] - в евро");
                        input = Console.ReadLine();

                        switch (input)
                        {
                            case RubleCommand:
                                dollarWallet -= exchangeCurrencyAmount;
                                rubleWallet += exchangeCurrencyAmount * DollarToRubleCoefficient;
                                Console.WriteLine(ConvertationSuccessMessage);
                                break;

                            case EuroCommand:
                                dollarWallet -= exchangeCurrencyAmount;
                                euroWallet += exchangeCurrencyAmount * DollarToEuroCoefficient;
                                Console.WriteLine(ConvertationSuccessMessage);
                                break;

                            default:
                                Console.WriteLine(WrongCommandMessage);
                                break;
                        }
                        break;

                    case EuroCommand:
                        Console.WriteLine("Выбраны евро");
                        Console.Write(AmountRequestMessage);
                        exchangeCurrencyAmount = float.Parse(Console.ReadLine());

                        while (exchangeCurrencyAmount > euroWallet || exchangeCurrencyAmount < 0)
                        {
                            Console.WriteLine(IncorrectMoneyAmountMessage);
                            Console.Write(AmountRequestMessage);
                            exchangeCurrencyAmount = float.Parse(Console.ReadLine());
                        }

                        Console.WriteLine($"\nКурс обмена\n{EuroToDollarCoefficient} долларов за евро;\n{EuroToRubleCoefficient} рублей за евро");
                        Console.WriteLine($"\nВ какую валюту хотите конвертировать?\n[{RubleCommand}] - в рубли\n[{DollarCommand}] - в доллары");
                        input = Console.ReadLine();

                        switch (input)
                        {
                            case RubleCommand:
                                euroWallet -= exchangeCurrencyAmount;
                                rubleWallet += exchangeCurrencyAmount * EuroToRubleCoefficient;
                                Console.WriteLine(ConvertationSuccessMessage);
                                break;

                            case DollarCommand:
                                euroWallet -= exchangeCurrencyAmount;
                                dollarWallet += exchangeCurrencyAmount * EuroToDollarCoefficient;
                                Console.WriteLine(ConvertationSuccessMessage);
                                break;

                            default:
                                Console.WriteLine(WrongCommandMessage);
                                break;
                        }
                        break;

                    case RubleCommand:
                        Console.WriteLine("Выбраны рубли");
                        Console.Write(AmountRequestMessage);
                        exchangeCurrencyAmount = float.Parse(Console.ReadLine());

                        while (exchangeCurrencyAmount > rubleWallet || exchangeCurrencyAmount < 0)
                        {
                            Console.WriteLine(IncorrectMoneyAmountMessage);
                            Console.Write(AmountRequestMessage);
                            exchangeCurrencyAmount = float.Parse(Console.ReadLine());
                        }


                        Console.WriteLine($"\nКурс обмена\n{RubleToDollarCoefficient} долларов за рубль;\n{RubleToEuroCoefficient} евро за рубль");
                        Console.WriteLine($"\nВ какую валюту хотите конвертировать?\n[{EuroCommand}] - в евро\n[{DollarCommand}] - в доллары");
                        input = Console.ReadLine();

                        switch (input)
                        {
                            case RubleCommand:
                                rubleWallet -= exchangeCurrencyAmount;
                                euroWallet += exchangeCurrencyAmount * RubleToEuroCoefficient;
                                Console.WriteLine(ConvertationSuccessMessage);
                                break;

                            case DollarCommand:
                                rubleWallet -= exchangeCurrencyAmount;
                                dollarWallet += exchangeCurrencyAmount * RubleToDollarCoefficient;
                                Console.WriteLine(ConvertationSuccessMessage);
                                break;

                            default:
                                Console.WriteLine(WrongCommandMessage);
                                break;
                        }
                        break;

                    case ExitCommand: return;

                    default:
                        Console.WriteLine(WrongCommandMessage);
                        break;
                }
            }




        }
    }
}
