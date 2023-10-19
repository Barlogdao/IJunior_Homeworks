using System.Xml.Linq;

namespace HomeWork_041_BookStorage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class BookStorage
    {
        private List<Book> _books = new();

        public bool HasBook(Book book)
        {
            return _books.Contains(book);
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            _books.Remove(book);
        }

        public void ShowAllBooks()
        {
            foreach (Book book in _books)
            {
                Console.WriteLine(book);
            }
        }

        public void ShowBooksByName(string name)
        {
            foreach (Book book in _books)
            {
                if (book.Name == name)
                Console.WriteLine(book);
            }
        }

        public void ShowBooksByAuthor(string author)
        {
            foreach (Book book in _books)
            {
                if (book.Author == author)
                    Console.WriteLine(book);
            }
        }

        public void ShowBooksByYear(int releaseYear)
        {
            foreach (Book book in _books)
            {
                if (book.ReleaseYear == releaseYear)
                    Console.WriteLine(book);
            }
        }
    }

    public record Book(string Name, string Author, int ReleaseYear)
    {
        public override string ToString()
        {
            return $"Книга {Name}. Автор {Author}. Год выпуска {ReleaseYear}.";
        }
    }
}

//Создать хранилище книг. 
//Каждая книга имеет название, автора и год выпуска (можно добавить еще параметры).
//В хранилище можно добавить книгу, убрать книгу, показать все книги и показать книги по указанному параметру (по названию, по автору, по году выпуска).