namespace HomeWork_17_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const char OpenBracket = '(';
            const char CloseBracket = ')';

            Console.WriteLine($"Введите строку из символов '{OpenBracket}' и '{CloseBracket}'.");
            string text = Console.ReadLine();

            int maxNestingLevel = 1;
            int currentNestingLevel = 0;
            bool isExpressionCorrect = true;
            char previousSymbol = OpenBracket;

            foreach (var symbol in text)
            {
                if (symbol == OpenBracket)
                {
                    currentNestingLevel++;
                    maxNestingLevel++;
                    previousSymbol = symbol;
                }
                else if (symbol == CloseBracket)
                {
                    currentNestingLevel--;

                    if (currentNestingLevel < 0)
                    {
                        isExpressionCorrect = false;
                        break;
                    }
                    else if (previousSymbol == OpenBracket)
                    {
                        maxNestingLevel--;
                    }

                    previousSymbol = symbol;
                }
                else
                {
                    isExpressionCorrect = false;
                    break;
                }
            }

            if (isExpressionCorrect)
                Console.WriteLine($"Выражение корректно. Максимальная глубина вложенности: {maxNestingLevel}");
            else
                Console.WriteLine("Выражение не корректно");
        }
    }
}