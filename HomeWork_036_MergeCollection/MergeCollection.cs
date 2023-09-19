namespace HomeWork_036_MergeCollection
{
    internal class MergeCollection
    {
        static void Main(string[] args)
        {
            string[] firstArray = { "A", "B", "C", "B", "A" };
            string[] secondArray = { "C", "D", "E", "A", "B" };

            Console.WriteLine("Первый Массив:");
            ShowCollection(firstArray);
            Console.WriteLine("Второй Массив:");
            ShowCollection(secondArray);
            Console.WriteLine();

            Console.WriteLine("Объединение через коллекцию HashSet");
            MergeWithHashSet(firstArray, secondArray);

            Console.WriteLine("Объединение через коллекцию List");
            MergeWithList(firstArray, secondArray);

            Console.WriteLine("Объединение через коллекцию Queue");
            MergeWithQueue(firstArray, secondArray);

            Console.WriteLine("Объединение через коллекцию Dictionary");
            MergeWithDictionary(firstArray, secondArray);
        }

        private static void ShowCollection(IEnumerable<string> collection)
        {
            foreach (var element in collection)
            {
                Console.Write(element + " ");
            }

            Console.WriteLine();
        }

        private static void MergeWithHashSet(string[] firstArray, string[] secondArray)
        {
            HashSet<string> uniqueSet = new HashSet<string>();
            uniqueSet.UnionWith(firstArray);
            uniqueSet.UnionWith(secondArray);

            ShowCollection(uniqueSet);
        }


        private static void MergeWithList(string[] firstArray, string[] secondArray)
        {
            List<string> uniqueList = new List<string>();
            MergeToList(uniqueList, firstArray);
            MergeToList(uniqueList, secondArray);

            ShowCollection(uniqueList);
        }

        private static void MergeToList(List<string> uniqueList, string[] arrayForMerge)
        {
            foreach (string element in arrayForMerge)
            {
                if (uniqueList.Contains(element) == false)
                {
                    uniqueList.Add(element);
                }
            }
        }

        private static void MergeWithQueue(string[] firstArray, string[] secondArray)
        {
            Queue<string> uniqueQueue = new Queue<string>();
            MergeToQueue(uniqueQueue,firstArray);
            MergeToQueue(uniqueQueue,secondArray);

            ShowCollection(uniqueQueue);
        }

        private static void MergeToQueue(Queue<string> uniqueQueue, string[] arrayForMerge)
        {
            foreach (string element in arrayForMerge)
            {
                if (uniqueQueue.Contains(element) == false)
                {
                    uniqueQueue.Enqueue(element);
                }
            }
        }

        private static void MergeWithDictionary(string[] firstArray, string[] secondArray)
        {
            Dictionary<string, bool> uniqueDictionary = new Dictionary<string, bool>();
            MergeToDictionary(uniqueDictionary, firstArray);
            MergeToDictionary(uniqueDictionary,secondArray);

            ShowCollection(uniqueDictionary.Keys);
        }

        private static void MergeToDictionary(Dictionary<string, bool> uniqueDictionary, string[] arrayForMerge)
        {
            foreach (string element in arrayForMerge)
            {
                if (uniqueDictionary.ContainsKey(element)== false)
                {
                   uniqueDictionary.Add(element,true);
                }
            }
        }
    }
}