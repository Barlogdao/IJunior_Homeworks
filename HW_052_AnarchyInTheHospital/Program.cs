namespace HW_052_AnarchyInTheHospital
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int patientsAmount = 10;

            Hospital hospital = new Hospital(patientsAmount);

            hospital.Work();
        }
    }

    public class Hospital
    {
        private readonly List<Patient> _patients;

        public Hospital(int patientsAmount)
        {
            PatientFactory patientFactory = new PatientFactory();

            _patients = new List<Patient>();

            for (int i = 0; i < patientsAmount; i++)
            {
                _patients.Add(patientFactory.CreatePatient());
            }
        }

        public void Work()
        {
            const string CommandSortByName = "1";
            const string CommandSortByAge = "2";
            const string ComandFindByDisease = "3";
            const string ComandExit = "0";

            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine("\nВведите команду" +
                    $"\n[{CommandSortByName}] - отсортировать всех больных по имени" +
                    $"\n[{CommandSortByAge}] - отсортировать всех больных по возрасту" +
                    $"\n[{ComandFindByDisease}] - вывести больных с определенным заболеванием" +
                    $"\n[{ComandExit}] - выйти\n ");

                Console.Write("Ваш выбор:");
                string input = Console.ReadLine();

                switch (input)
                {
                    case CommandSortByName:
                        SortPatientsByName();
                        break;

                    case CommandSortByAge:
                        SortPatientsByAge();
                        break;

                    case ComandFindByDisease:
                        FindPatientsByDisease();
                        break;

                    case ComandExit:
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine("Введена невреная команда!");
                        break;
                }
            }
        }

        private void SortPatientsByName()
        {
            IEnumerable<Patient> patients = _patients.OrderBy(patient => patient.Name);

            Show(patients);
        }

        private void SortPatientsByAge()
        {
            IEnumerable<Patient> patients = _patients.OrderBy(patient => patient.Age);

            Show(patients);
        }

        private void FindPatientsByDisease()
        {
            Console.WriteLine("Введите название болезни");
            string input = Console.ReadLine();

            FilterPatientsByDisease(input);
        }

        private void FilterPatientsByDisease(string disease)
        {
            IEnumerable<Patient> patients = _patients.Where(patient => patient.Disease.ToLower() == disease.ToLower());

            if (patients.Count() > 0)
                Show(patients);
            else
                Console.WriteLine("В больнице нет больных с указанной болезнью");
        }

        private void Show(IEnumerable<Patient> patietns)
        {
            foreach (Patient patient in patietns)
            {
                Console.WriteLine(patient);
            }
        }
    }

    public class Patient
    {
        public Patient(string name, int age, string disease)
        {
            Name = name;
            Age = age;
            Disease = disease;
        }

        public string Name { get; init; }
        public int Age { get; init; }
        public string Disease { get; init; }

        public override string ToString()
        {
            return $"ФИО: {Name}. Возраст: {Age}. Болезнь: {Disease}";
        }
    }

    public class PatientFactory
    {
        private readonly string[] s_names;
        private readonly string[] s_diseases;

        public PatientFactory()
        {
            s_names = new string[] { "Кларк Кент", "Иван Иванов", "Александр Петров", "Семен Слепаков" };
            s_diseases = new string[] { "Волчанка", "Свинка", "Насморк", "Слепота", "Глухота", "Диабет" };
        }

        public Patient CreatePatient()
        {
            int minAge = 18;
            int maxAge = 55;

            string name = s_names[RandomUtils.GetRandomNumber(s_names.Length)];
            int age = RandomUtils.GetRandomNumber(minAge, maxAge);
            string disease = s_diseases[RandomUtils.GetRandomNumber(s_diseases.Length)];

            return new Patient(name, age, disease);
        }
    }

    public static class RandomUtils
    {
        private static readonly Random s_random = new Random();

        public static int GetRandomNumber(int maxValue) => s_random.Next(maxValue);

        public static int GetRandomNumber(int minValue, int maxValue) => s_random.Next(minValue, maxValue);
    }
}