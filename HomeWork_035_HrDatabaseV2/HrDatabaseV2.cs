namespace HomeWork_035_HrDatabaseV2
{
    internal class HrDatabaseV2
    {
        static void Main(string[] args)
        {
            const string CommandAddProfile = "1";
            const string CommandShowAllProfiles = "2";
            const string CommandRemoveProfile = "3";
            const string CommandExit = "4";

            Dictionary<string, string> personDataBase = new Dictionary<string, string>();

            bool isExit = false;

            while (isExit == false)
            {
                Console.WriteLine("\nКоманды управления каталогом:" +
                $"\n[{CommandAddProfile}] - добавить досье" +
                $"\n[{CommandShowAllProfiles}] - вывести все досье" +
                $"\n[{CommandRemoveProfile}] - удалить досье" +
                $"\n[{CommandExit}] - выход\n");

                string inputCommand = GetInput("Выберите команду");

                switch (inputCommand)
                {
                    case CommandAddProfile:
                        TryAddProfile(personDataBase);
                        break;

                    case CommandShowAllProfiles:
                        ShowAllProfiles(personDataBase);
                        break;

                    case CommandRemoveProfile:
                        TryRemoveProfile(personDataBase);
                        break;

                    case CommandExit:
                        isExit = true;
                        break;

                    default:
                        Console.WriteLine("Введена неверная команда!");
                        break;
                }
            }
        }

        private static string GetInput(string message)
        {
            Console.Write(message + ": ");
            return Console.ReadLine();
        }

        private static void TryAddProfile(Dictionary <string, string> personDatabase)
        {
            string personFullName = GetInput("Введите ФИО");

            if (personDatabase.ContainsKey(personFullName))
            {
                Console.WriteLine("Данный работник уже есть в каталоге!");
                return;
            }

            string personRole = GetInput("Введите должность");

            personDatabase[personFullName] = personRole;
            Console.WriteLine("Досье добавлено в каталог.");
        }
        private static void ShowAllProfiles(Dictionary<string, string> personDatabase)
        {
            if(personDatabase.Count == 0)
            {
                Console.WriteLine("Каталог пуст.");
                return;
            }

            foreach (string name in personDatabase.Keys)
            {
                Console.WriteLine($"{name} - {personDatabase[name]}");
            }
        }

        private static void TryRemoveProfile(Dictionary<string, string> personDatabase)
        {
            string personForDelete = GetInput("Введите ФИО работника для удаления из каталога");

            if (personDatabase.ContainsKey(personForDelete))
            {
                personDatabase.Remove(personForDelete);
                Console.WriteLine("Досье работника удвлено!");
            }
            else
            {
                Console.WriteLine("Работник с введенным ФИО отсутствует в каталоге!");
            }
        }
    }
}