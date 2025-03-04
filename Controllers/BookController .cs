using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication280924_practice.Models;
using WebApplication280924_practice.ViewModels;

namespace WebApplication280924_practice.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService _bookService;

        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            var books = _bookService.GetBooks();
            return View(books);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(BookViewModel model)
        {
            if (ModelState.IsValid)
            {
                var book = new Book
                {
                    Title = model.Title,
                    Author = model.Author,
                    Genre = model.Genre,
                    Year = model.Year
                };
                _bookService.AddBook(book);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
