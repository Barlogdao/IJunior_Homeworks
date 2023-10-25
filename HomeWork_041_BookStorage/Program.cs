namespace HomeWork_041_BookStorage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandAddBook = "1";
            const string CommandRemoveBook = "2";
            const string CommandShowAllBooks = "3";
            const string CommandFindByName = "4";
            const string CommandFindByAuthor = "5";
            const string CommandFindByReleaseYear = "6";
            const string CommandExit = "0";

            BookStorage bookStorage = new BookStorage();

            string commandMessage = $"\nВыберите команду для работы с хранилищем книг:" +
                $"\n [{CommandAddBook}] - добавить книгу в хранилище" +
                $"\n [{CommandRemoveBook}] - убрать книгу из хранилища" +
                $"\n [{CommandShowAllBooks}] - показать все книги" +
                $"\n [{CommandFindByName}] - найти книги по названию" +
                $"\n [{CommandFindByAuthor}] - найти книги по автору" +
                $"\n [{CommandFindByReleaseYear}] - найти книги по году выпуска" +
                $"\n [{CommandExit}] - выход";
            bool isWorking = true;

            Console.WriteLine(commandMessage);

            while (isWorking == true)
            {
                Console.Write("\nВведите команду: ");
                string input = Console.ReadLine();

                Console.WriteLine();

                switch (input)
                {
                    case CommandAddBook:
                        bookStorage.AddBook();
                        break;

                    case CommandRemoveBook:
                        bookStorage.RemoveBook();
                        break;

                    case CommandShowAllBooks:
                        bookStorage.ShowAllBooks();
                        break;

                    case CommandFindByName:
                        bookStorage.FindBooksByName();
                        break;

                    case CommandFindByAuthor:
                        bookStorage.FindBooksByAuthor();
                        break;

                    case CommandFindByReleaseYear:
                        bookStorage.FindBooksByReleaseYear();
                        break;

                    case CommandExit:
                        isWorking = false;
                        break;

                    default:
                        Console.WriteLine("Введена неизвестная команда!");
                        Console.WriteLine(commandMessage);
                        break;
                }
            }
        }
    }

    public class BookStorage
    {
        private readonly List<Book> _books;

        public BookStorage()
        {
            _books = new List<Book>()
            {
                new Book("Автостопом по галактике", "Дуглас Адамс", 1979),
                new Book("1984", "Джордж Оруэлл", 1949),
                new Book("Скотный двор", "Джордж Оруэлл", 1945),
                new Book("Мы", "Евгений Замятин", 1920),
                new Book("Сердца трех", "Джек Лондон", 1920),
                new Book("Алхимик", "Пауло Коэльо", 1988),
                new Book("Алхимик", "Говард Лавкрфакт", 1908),
            };
        }

        public void AddBook()
        {
            Console.WriteLine("Выбрано добавление книги в хранилище");

            string bookName = GetInput("Укажите название книги");
            string authorName = GetInput("Укажите имя автора"); ;
            int releaseYear = GetReleaseYear("Укажите год выпуска книги");

            Book book = new Book(bookName, authorName, releaseYear);

            if (HasBook(book))
            {
                Console.WriteLine("Такая книга уже есть в хранилище");
            }
            else
            {
                AppendBook(book);
            }
        }

        public void RemoveBook()
        {
            Console.WriteLine("Выбрано удаление книги из хранилища");

            int bookNumber = GetBookNumber();
            int bookIndex = bookNumber - 1;

            if (bookIndex < 0 || bookIndex >= _books.Count)
            {
                Console.WriteLine("В хранилище отсутствует книга с указанным номером");
            }
            else
            {
                Book bookForRemove = _books[bookIndex];

                Console.WriteLine($"Книга \"{bookForRemove.Name}\" удалена из хранилища.");

                _books.Remove(bookForRemove);
            }
        }

        public void ShowAllBooks()
        {
            foreach (Book book in _books)
            {
                DisplayBook(book);
            }
        }

        public void FindBooksByName()
        {
            Console.WriteLine("Выбран поиск книг по названию");

            string bookName = GetInput("Укажите название книг");

            foreach (Book book in _books)
            {
                if (book.Name.ToLower() == bookName.ToLower())
                    DisplayBook(book);
            }
        }

        public void FindBooksByAuthor()
        {
            Console.WriteLine("Выбран поиск книг по автору");

            string authorName = GetInput("Укажите автора");

            foreach (Book book in _books)
            {
                if (book.Author.ToLower() == authorName.ToLower())
                    DisplayBook(book);
            }
        }

        public void FindBooksByReleaseYear()
        {
            Console.WriteLine("Выбран поиск книг по году выпуска");

            int releaseYear = GetReleaseYear("Укажите год выпуска книг");

            foreach (Book book in _books)
            {
                if (book.ReleaseYear == releaseYear)
                    DisplayBook(book);
            }
        }

        private string GetInput(string message)
        {
            Console.Write(message + ": ");
            string inputString = Console.ReadLine();

            return inputString;
        }

        private int GetReleaseYear(string message)
        {
            int releaseYear;
            string inputYear;

            do
            {
                inputYear = GetInput(message);
            }
            while (IsValidReleaseYear(inputYear, out releaseYear) == false);

            return releaseYear;
        }

        private bool IsValidReleaseYear(string inputYear, out int releaseYear)
        {
            int minYear = 998;
            int maxYear = 2023;

            if (int.TryParse(inputYear, out releaseYear) == false)
            {
                Console.WriteLine("Некорректный ввод! Значение должно быть числом.");

                return false;
            }

            if (releaseYear < minYear || releaseYear > maxYear)
            {
                Console.WriteLine($"Некорректный год выпуска книги! Год выпуска может быть в периоде между {minYear} и {maxYear} годом.");

                return false;
            }

            return true;
        }

        private bool HasBook(Book book)
        {
            return _books.Contains(book);
        }

        private void AppendBook(Book book)
        {
            _books.Add(book);
        }

        private int GetBookNumber()
        {
            int bookNumber;
            string userInput;

            userInput = GetInput("Укажите номер книги в хранилище");

            while (int.TryParse(userInput, out bookNumber) == false)
            {
                Console.WriteLine("Номер книги должен быть числом!");

                userInput = GetInput("Укажите номер книги в хранилище");
            }

            return bookNumber;
        }

        private void DisplayBook(Book book)
        {
            int countOffset = 1;
            Console.WriteLine((_books.IndexOf(book) + countOffset) + ". " + book);
        }
    }

    public readonly struct Book
    {
        public Book(string name, string author, int releaseYear)
        {
            Name = name;
            Author = author;
            ReleaseYear = releaseYear;
        }

        public string Name { get; init; }
        public string Author { get; init; }
        public int ReleaseYear { get; init; }

        public override string ToString()
        {
            return $"{Name} ({ReleaseYear}). {Author}";
        }
    }
}