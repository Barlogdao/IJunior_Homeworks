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
            bool isExpressionCorrect = false;

            foreach (var symbol in text)
            {
                if (symbol == OpenBracket)
                {
                    currentNestingLevel++;
                    maxNestingLevel++;
                }
                else if (symbol == CloseBracket)
                {
                    currentNestingLevel--;

                    if (currentNestingLevel < 0)
                    {
                        isExpressionCorrect = false;
                        break;
                    }
                    else if (currentNestingLevel == 0)
                    {
                        maxNestingLevel--;
                    }
                }
                else
                {
                    break;
                }

                isExpressionCorrect = currentNestingLevel == 0;
            }

            if (isExpressionCorrect)
                Console.WriteLine($"Выражение корректно. Максимальная глубина вложенности: {maxNestingLevel}");
            else
                Console.WriteLine("Выражение не корректно");
        }
    }
    //    Дана строка из символов '(' и ')'. Определить, является ли она корректным скобочным выражением.Определить максимальную глубину вложенности скобок.
    //Пример “(()(()))” - строка корректная и максимум глубины равняется 3.
    //Пример не верных строк: "(()", "())", ")(", "(()))(()"
    //Для перебора строки по символам можно использовать цикл foreach, к примеру будет так foreach (var symbol in text) 
    //Или цикл for(int currentNestingLevel = 0; currentNestingLevel<text.Length; currentNestingLevel++) и дальше обращаться к каждому символу внутри цикла как text[currentNestingLevel]
    //Цикл нужен для перебора всех символов в строке.
}