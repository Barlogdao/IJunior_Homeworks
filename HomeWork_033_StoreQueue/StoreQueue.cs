namespace HomeWork_033_StoreQueue
{
    internal class StoreQueue
    {
        static void Main(string[] args)
        {
            Queue<int> clientsQueue = CreateQueue();
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

        private static Queue<int> CreateQueue()
        {
            Random random = new Random();
            int minValue = 1;
            int maxValue = 501;
            int queueSize = 10;

            Queue<int> tempQueue = new Queue<int>();

            for (int i = 0; i < queueSize; i++)
            {
                tempQueue.Enqueue(random.Next(minValue, maxValue));
            }

            return tempQueue;
        }
    }
}