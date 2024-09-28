using WebApplication280924_practice.Models;

namespace WebApplication280924_practice
{
    public class BookService
    {
        private readonly List<Book> _books = new List<Book>();

        public IEnumerable<Book> GetBooks()
        {
            return _books;
        }

        public void AddBook(Book book)
        {
            book.Id = _books.Count + 1;
            _books.Add(book);
        }
    }
}
