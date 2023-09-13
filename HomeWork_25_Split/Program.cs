namespace HomeWork_25_Split
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas";
            char separator = ' ';
            string[] splittedText = text.Split(separator);

            foreach (string word in splittedText)
            {
                Console.WriteLine(word);
            }
        }
    }
}