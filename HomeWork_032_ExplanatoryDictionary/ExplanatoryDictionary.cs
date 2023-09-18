namespace HomeWork_032_ExplanatoryDictionary
{
    internal class ExplanatoryDictionary
    {
        static void Main(string[] args)
        {
            const string CommandExit = "0";

            Dictionary<string, string> dictionary = CreateDictionary();
            bool exitRequested = false;

            while (exitRequested == false)
            {
                Console.Write($"\nВведите слово или [{CommandExit}] для выхода: ");
                string inputWord = Console.ReadLine();

                if (inputWord == CommandExit)
                {
                    exitRequested = true;
                }
                else
                {
                    HandleInputWord(inputWord, ref dictionary);
                }
            }
        }

        private static Dictionary<string,string> CreateDictionary()
        {
            return new Dictionary<string, string>()
            {
                ["словарь"] = "Книга, содержащая перечень слов, расположенных в определённом порядке",
                ["очередь"] = "Люди, располагающиеся друг за другом, в ожидании чего-либо",
                ["стек"] = "Тонкая палочка с ременной петлёй на конце, применяемая как хлыст при верховой езде",
                ["лист"] = "Орган воздушного питания и газообмена у растений, имеющий обычно вид тонкой зелёной пластинки"
            };
        }

        private static void HandleInputWord(string inputWord,ref Dictionary<string,string> dictionary)
        {
            string lowCaseWord = inputWord.ToLower();

            if (dictionary.ContainsKey(lowCaseWord))
            {
                Console.WriteLine($"{lowCaseWord} - {dictionary[lowCaseWord]}");
            }
            else
            {
                Console.WriteLine("Такого слова нет в словаре.");

                Console.Write("Введите определение слова:");
                string description = Console.ReadLine();

                dictionary[lowCaseWord] = description;
            }
        }
    }
}