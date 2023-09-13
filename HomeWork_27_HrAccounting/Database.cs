namespace HomeWork_27_HrDatabase
{
    internal class Database
    {
        static void Main(string[] args)
        {
            const string CommandAddProfile = "1";
            const string CommandShowAllProfiles = "2";
            const string CommandRemoveProfile = "3";
            const string CommandFindProfile = "4";
            const string CommandExit = "5";

            string[] personNameDatabase = new string[0];
            string[] personRoleDatabase = new string[0];

            bool isExit = false;

            while (isExit == false)
            {
                Console.WriteLine("\nКоманды управления каталогом:" +
                $"\n[{CommandAddProfile}] - добавить досье" +
                $"\n[{CommandShowAllProfiles}] - вывести все досье" +
                $"\n[{CommandRemoveProfile}] - удалить досье" +
                $"\n[{CommandFindProfile}] - поиск по фамилии" +
                $"\n[{CommandExit}] - выход\n");

                string inputCommand = GetInput("Выберите команду");

                switch (inputCommand)
                {
                    case CommandAddProfile:
                        AddProfile(ref personNameDatabase, ref personRoleDatabase);
                        break;

                    case CommandShowAllProfiles:
                        ShowAllProfiles(personNameDatabase, personRoleDatabase);
                        break;

                    case CommandRemoveProfile:
                        RemoveProfile(ref personNameDatabase, ref personRoleDatabase);
                        break;

                    case CommandFindProfile:
                        FindProfile(personNameDatabase, personRoleDatabase);
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

        private static void AddProfile(ref string[] personNameDatabase, ref string[] personRoleDatabase)
        {
            InputPersonData(out string personName, out string personRole);
            AddProfileToDataBase(ref personNameDatabase, ref personRoleDatabase, personName, personRole);
            Console.WriteLine("Досье добавлено в каталог.");
        }
        private static void InputPersonData(out string personName, out string personRole)
        {
            personName = GetInput("Введите ФИО");
            personRole = GetInput("Введите должность");
        }

        private static void AddProfileToDataBase(ref string[] personNameDatabase, ref string[] personRoleDatabase, string personName, string personRole)
        {
            personNameDatabase = AppendRecordToDatabase(personNameDatabase, personName);
            personRoleDatabase = AppendRecordToDatabase(personRoleDatabase, personRole);
        }

        private static string[] AppendRecordToDatabase(string[] database, string record)
        {
            string[] tempDatabase = new string[database.Length + 1];

            for (int i = 0; i < database.Length; i++)
            {
                tempDatabase[i] = database[i];
            }

            tempDatabase[^1] = record;
            return tempDatabase;
        }

        private static void ShowAllProfiles(string[] personNameDatabase, string[] personRoleDatabase)
        {
            if (personNameDatabase.Length == 0)
            {
                Console.WriteLine("Каталог пуст!");
            }

            int profileNumber = 1;

            for (int i = 0; i < personNameDatabase.Length; i++, profileNumber++)
            {
                Console.WriteLine($"{profileNumber}. {personNameDatabase[i]} - {personRoleDatabase[i]}");
            }
        }

        private static void RemoveProfile(ref string[] personNameDatabase, ref string[] personRoleDatabase)
        {
            if (TryGetProfileIndex(out int profileIndex, personNameDatabase.Length))
            {
                DeleteProfileFromDatabase(ref personNameDatabase, ref personRoleDatabase, profileIndex);
                Console.WriteLine("Досье удвлено!");
            }
            else
            {
                Console.WriteLine("Досье с указанным номером отсутствует!");
            }
        }

        private static bool TryGetProfileIndex(out int profileIndex, int dataBaseLenght)
        {
            if (int.TryParse(GetInput("Введите номер удаляемого досье"), out int profileNumber))
            {
                profileIndex = profileNumber - 1;
                if (profileIndex >= 0 && profileIndex < dataBaseLenght)
                {
                    return true;
                }
            }

            profileIndex = int.MinValue;
            return false;
        }

        private static void DeleteProfileFromDatabase(ref string[] personNameDatabase, ref string[] personRoleDatabase, int indexForDelete)
        {
            personNameDatabase = DeleteRecordFromDatabase(personNameDatabase, indexForDelete);
            personRoleDatabase = DeleteRecordFromDatabase(personRoleDatabase, indexForDelete);
        }

        private static string[] DeleteRecordFromDatabase(string[] database, int indexForDelete)
        {
            string[] tempDatabase = new string[database.Length - 1];

            for (int oldIndex = 0, newIndex = 0; oldIndex < database.Length; oldIndex++)
            {
                if (oldIndex == indexForDelete)
                    continue;

                tempDatabase[newIndex] = database[oldIndex];
                newIndex++;
            }
            
            return tempDatabase;
        } 

        private static void FindProfile(string[] personNameDatabase, string[] personRoleDatabase)
        {
            string inputLastName = GetInput("Введите фамилию");
            int foundProfilesCounter = 0;

            for (int i = 0; i < personNameDatabase.Length; i++)
            {
                string personLastName = personNameDatabase[i].Split()[0];
                if (inputLastName.ToLower() == personLastName.ToLower())
                {
                    Console.WriteLine($"{personNameDatabase[i]} - {personRoleDatabase[i]}");
                    foundProfilesCounter++;
                }
            }

            if (foundProfilesCounter == 0)
            {
                Console.WriteLine("В каталоге нет лиц с указанной фамилией!");
            }
        }
    }
}