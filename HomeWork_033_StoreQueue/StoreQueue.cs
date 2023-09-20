namespace HomeWork_033_StoreQueue
{
    internal class StoreQueue
    {
        static void Main(string[] args)
        {
            Queue<int> clientsQueue = new Queue<int>();
            CreateQueue(clientsQueue);
            StartStoreWork(clientsQueue);
        }

        private static void StartStoreWork(Queue<int> clientsQueue)
        {
            int storeAccount = 0;

            while (clientsQueue.Count > 0)
            {
                int clientMoney = clientsQueue.Dequeue();
                storeAccount += clientMoney;

                Console.WriteLine($"Клиент обслужен. Вам заплатили {clientMoney} долларов.");
                Console.WriteLine($"На счету магазина {storeAccount} долларов.");
                Console.WriteLine($"Осталось {clientsQueue.Count} клиентов");

                Console.WriteLine("Нажмите любую клавишу, чтобы продолжить.");
                Console.ReadKey();

                Console.Clear();
            }

            Console.WriteLine("На сегодня клиенты закончились!");
            Console.WriteLine($"На счету магазина {storeAccount} долларов");
        }

        private static void CreateQueue(Queue<int> queue)
        {
            Random random = new Random();
            int minValue = 1;
            int maxValue = 501;
            int queueSize = 10;

            for (int i = 0; i < queueSize; i++)
            {
                queue.Enqueue(random.Next(minValue, maxValue));
            }
        }
    }
}