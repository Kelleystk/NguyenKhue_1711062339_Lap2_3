using Lab2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Lab2.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public String HelloTeacher(string university)
        {
            return "Hello" + university;

        }

        public ActionResult ListBook()
        {
            var books = new List<String>();
            books.Add("HTML 5 & CSS 3 BOOK 1");
            books.Add("HTML 5 & CSS 3 BOOK 2");
            books.Add("PROFESSIONAL ASP.NET");
            ViewBag.Books = books;
            return View();
        }

        public ActionResult ListBookModel()
        {

            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 the comlete", "Author Name Book 1", "/Content/Images/book4cover.png"));
            books.Add(new Book(2, "HTML5 & CSS3 the design", "Author Name Book 2", "/Content/Images/book5cover.png"));
            books.Add(new Book(3, "Professional ASP.NET MVC5", "Author Name Book 3", "/Content/Images/book3cover.png"));
            return View(books);
        }

        public ActionResult EditBook(int id)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 the comlete", "Author Name Book 1", "/Content/Images/book4cover.png"));
            books.Add(new Book(2, "HTML5 & CSS3 the design", "Author Name Book 2", "/Content/Images/book5cover.png"));
            books.Add(new Book(3, "Professional ASP.NET MVC5", "Author Name Book 3", "/Content/Images/book3cover.png"));

            Book book = new Book();
            foreach (Book b in books)
            {
                if(b.Id == id)
                {
                    book = b;
                    break;
                }
            }
            if (book == null)
            {
                return HttpNotFound();
            }

           
            return View(book);
        }

       [HttpPost,ActionName("EditBook")]
       [ValidateAntiForgeryToken]
        public ActionResult EditBook(int id, string Title, String Author, String ImageCover)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 the comlete", "Author Name Book 1", "/Content/Images/book4cover.png"));
            books.Add(new Book(2, "HTML5 & CSS3 the design", "Author Name Book 2", "/Content/Images/book5cover.png"));
            books.Add(new Book(3, "Professional ASP.NET MVC5", "Author Name Book 3", "/Content/Images/book3cover.png"));

            if (id == null)
            {
                return HttpNotFound();
            }

            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    b.Title = Title;
                    b.Author = Author;
                    b.Image_cover = ImageCover;
                    break;
                }
            }
                    return View("ListBookModel",books);
        }

        public ActionResult CreateBook()
        {
            return View();
        }

        [HttpPost,ActionName("CreateBook")]
        [ValidateAntiForgeryToken]

        public ActionResult Contact([Bind(Include = "Id, Title, Author, ImageCover")]Book book)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 the comlete", "Author Name Book 1", "/Content/Images/book4cover.png"));
            books.Add(new Book(2, "HTML5 & CSS3 the design", "Author Name Book 2", "/Content/Images/book5cover.png"));
            books.Add(new Book(3, "Professional ASP.NET MVC5", "Author Name Book 3", "/Content/Images/book3cover.png"));

            try
            {
                if(ModelState.IsValid)
                {
                    books.Add(book);
                }
            }
            catch(RetryLimitExceededException )
            {
                ModelState.AddModelError("", "Error Save Data");

            }

            return View("ListBookModel", books);


        }

    }
}