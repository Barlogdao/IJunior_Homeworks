namespace HomeWork_11
{
    internal class ConverterVersion2
    {
        static void Main(string[] args)
        {
            const string CommandExit = "0";
            const string CommandDollarToEuro = "1";
            const string CommandDollarToRuble = "2";
            const string CommandEuroToDollar = "3";
            const string CommandEuroToRuble = "4";
            const string CommandRubleToDollar = "5";
            const string CommandRubleToEuro = "6";

            const string WrongCommandMessage = "Некорректная команда!";
            const string AmountRequestMessage = "Какую сумму вы хотите обменять? ";
            const string IncorrectMoneyAmountMessage = "Введена некорркетная сумма!";
            const string ConvertationSuccessMessage = "Конвертация прошла успешно!";

            float dollarToEuroCoefficient = 0.9f;
            float dollarToRubleCoefficient = 100f;
            float euroToDollarCoefficient = 1.1f;
            float euroToRubleCoefficient = 102.3f;
            float rubleToDollarCoefficient = 0.01f;
            float rubleToEuroCoefficient = 0.012f;

            float dollarWallet = 100;
            float euroWallet = 200;
            float rubleWallet = 50000;

            Console.WriteLine("Добро пожаловать в чудо-обменник!");

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"Ваш баланс: {dollarWallet} долларов, {euroWallet} евро, {rubleWallet} рублей.");
                Console.WriteLine();
                Console.WriteLine("Выберите операцию обмена:" +
                    $"\n[{CommandDollarToEuro}] - доллары на евро" +
                    $"\n[{CommandDollarToRuble}] - доллары на рубли" +
                    $"\n[{CommandEuroToDollar}] - евро на доллары" +
                    $"\n[{CommandEuroToRuble}] - евро на рубли" +
                    $"\n[{CommandRubleToDollar}] - рубли на доллары" +
                    $"\n[{CommandRubleToEuro}] - рубли на евро" +
                    $"\n[{CommandExit}] - выход");

                Console.Write("Ваш выбор? ");
                string input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case CommandDollarToEuro:
                        Console.WriteLine("Обмен долларов на евро");


                        Console.Write(AmountRequestMessage);
                        float exchangeCurrencyAmount = Convert.ToSingle(Console.ReadLine());

                        while (exchangeCurrencyAmount > dollarWallet || exchangeCurrencyAmount < 0)
                        {
                            Console.WriteLine(IncorrectMoneyAmountMessage);

                            Console.Write(AmountRequestMessage);
                            exchangeCurrencyAmount = float.Parse(Console.ReadLine());
                        }

                        dollarWallet -= exchangeCurrencyAmount;
                        euroWallet += exchangeCurrencyAmount * dollarToEuroCoefficient;
                        Console.WriteLine(ConvertationSuccessMessage);
                        break;

                    case CommandDollarToRuble:
                        Console.WriteLine("Обмен долларов на рубли");

                        Console.Write(AmountRequestMessage);
                        exchangeCurrencyAmount = float.Parse(Console.ReadLine());

                        while (exchangeCurrencyAmount > dollarWallet || exchangeCurrencyAmount < 0)
                        {
                            Console.WriteLine(IncorrectMoneyAmountMessage);

                            Console.Write(AmountRequestMessage);
                            exchangeCurrencyAmount = float.Parse(Console.ReadLine());
                        }

                        dollarWallet -= exchangeCurrencyAmount;
                        rubleWallet += exchangeCurrencyAmount * dollarToRubleCoefficient;
                        Console.WriteLine(ConvertationSuccessMessage);
                        break;

                    case CommandEuroToDollar:
                        Console.WriteLine("Обмен евро на доллары");

                        Console.Write(AmountRequestMessage);
                        exchangeCurrencyAmount = float.Parse(Console.ReadLine());

                        while (exchangeCurrencyAmount > euroWallet || exchangeCurrencyAmount < 0)
                        {
                            Console.WriteLine(IncorrectMoneyAmountMessage);

                            Console.Write(AmountRequestMessage);
                            exchangeCurrencyAmount = float.Parse(Console.ReadLine());
                        }

                        euroWallet -= exchangeCurrencyAmount;
                        dollarWallet += exchangeCurrencyAmount * euroToDollarCoefficient;
                        Console.WriteLine(ConvertationSuccessMessage);
                        break;

                    case CommandEuroToRuble:
                        Console.WriteLine("Обмен евро на рубли");

                        Console.Write(AmountRequestMessage);
                        exchangeCurrencyAmount = float.Parse(Console.ReadLine());

                        while (exchangeCurrencyAmount > euroWallet || exchangeCurrencyAmount < 0)
                        {
                            Console.WriteLine(IncorrectMoneyAmountMessage);

                            Console.Write(AmountRequestMessage);
                            exchangeCurrencyAmount = float.Parse(Console.ReadLine());
                        }

                        euroWallet -= exchangeCurrencyAmount;
                        rubleWallet += exchangeCurrencyAmount * euroToRubleCoefficient;
                        Console.WriteLine(ConvertationSuccessMessage);
                        break;

                    case CommandRubleToDollar:
                        Console.WriteLine("Обмен рублей на доллары");

                        Console.Write(AmountRequestMessage);
                        exchangeCurrencyAmount = float.Parse(Console.ReadLine());

                        while (exchangeCurrencyAmount > rubleWallet || exchangeCurrencyAmount < 0)
                        {
                            Console.WriteLine(IncorrectMoneyAmountMessage);

                            Console.Write(AmountRequestMessage);
                            exchangeCurrencyAmount = float.Parse(Console.ReadLine());
                        }

                        rubleWallet -= exchangeCurrencyAmount;
                        dollarWallet += exchangeCurrencyAmount * rubleToDollarCoefficient;
                        Console.WriteLine(ConvertationSuccessMessage);
                        break;

                    case CommandRubleToEuro:
                        Console.WriteLine("Обмен рублей на евро");

                        Console.Write(AmountRequestMessage);
                        exchangeCurrencyAmount = float.Parse(Console.ReadLine());

                        while (exchangeCurrencyAmount > rubleWallet || exchangeCurrencyAmount < 0)
                        {
                            Console.WriteLine(IncorrectMoneyAmountMessage);

                            Console.Write(AmountRequestMessage);
                            exchangeCurrencyAmount = float.Parse(Console.ReadLine());
                        }

                        rubleWallet -= exchangeCurrencyAmount;
                        euroWallet += exchangeCurrencyAmount * rubleToEuroCoefficient;
                        Console.WriteLine(ConvertationSuccessMessage);
                        break;

                    case CommandExit:
                        return;

                    default:
                        Console.WriteLine(WrongCommandMessage);
                        break;
                }
            }
        }
    }
}
