using BookStoreApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.Controllers
{
	[Authorize]
	public class BookController : Controller
	{

		private BookstoreContext context;
		public IWebHostEnvironment WebHostEnvironment { get; }
		public BookController(BookstoreContext ctx, IWebHostEnvironment WHENV)
		{
			context = ctx;
			WebHostEnvironment = WHENV;
		}
		public IActionResult Index(int page = 1, int pageSize = 5, int selectedGenreId = 0)
		{
			int skip = (page - 1) * pageSize;
			var genres = context.Genres.ToList();

			// Search the books based on the selected genre.
			var booksQuery = context.Books.Include(m => m.Genre).Include(m => m.authorObject).OrderBy(m => m.Title);
			if (selectedGenreId != 0)
			{
				booksQuery = (IOrderedQueryable<Book>)booksQuery.Where(b => b.GenreId == selectedGenreId);
			}
			var totalCount = booksQuery.Count();
			var books = booksQuery.Skip(skip).Take(pageSize).ToList();

			var pagedList = new PagedList<Book>
			{
				Items = books,
				PageNumber = page,
				PageSize = pageSize,
				TotalCount = totalCount
			};

			var viewModel = new BookViewModel
			{
				PageResult = pagedList,
				Genres = new SelectList(genres, "GenreId", "Name"),
				SelectedGenreId = selectedGenreId
			};

			return View(viewModel);
		}

		[HttpPost]
		public IActionResult Add(BookViewModel model)
		{
			TempData["message"] = $"{model.Book.Title} has been added in the cart";
			return RedirectToAction("Index", "Book");
		}

		public IActionResult BookDetails(int id)
		{
			ViewBag.Authors = context.Authors
					.OrderBy(p => p.AuthorId).ToList();
            ViewBag.Genres = context.Genres.OrderBy(p => p.GenreId).ToList();


            Book book = context.Books.Where(b => b.BookId == id)
			.FirstOrDefault() ?? new Book();
			return View(book);
		}

		[HttpGet]
        public IActionResult EditConfirmedGet(Book model)
        {
            ViewBag.Authors = context.Authors.OrderBy(p => p.AuthorId).ToList();
            ViewBag.Genres = context.Genres.OrderBy(p => p.GenreId).ToList();

            foreach (var author in ViewBag.Authors)
            {
                if (model.AuthorId == author.AuthorId)
                {
                    model.authorObject = author;
                }
            }

            foreach (var genre in ViewBag.Genres)
            {
                if (model.GenreId == genre.GenreId)
                {
                    model.Genre = genre;
                }
            }

            return View("EditConfirmed", model);
        }

        [HttpPost]
		public IActionResult EditConfirmedPost(Book model)
		{
            ViewBag.Authors = context.Authors.OrderBy(p => p.AuthorId).ToList();
            ViewBag.Genres = context.Genres.OrderBy(p => p.GenreId).ToList();

            var books = context.Books
                                        .OrderBy(b => b.BookId).ToList();

            // Assuming "context" is your database context
            var existingBook = context.Books.FirstOrDefault(b => b.BookId == model.BookId);

            if (existingBook != null)
            {
                // Update the properties of the existing BlogPost
                existingBook.ISBN = model.ISBN;
                existingBook.Title = model.Title;
                existingBook.Price = model.Price;
                existingBook.AuthorId = model.AuthorId;
                existingBook.GenreId = model.GenreId;

                foreach (var author in ViewBag.Authors)
                {
                    if (model.AuthorId == author.AuthorId)
                    {
                        existingBook.authorObject = author;
                    }
                }

                foreach (var genre in ViewBag.Genres)
                {
                    if (model.GenreId == genre.GenreId)
                    {
                        existingBook.Genre = genre;
                    }
                }

                context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
		}


		[HttpGet]
		public IActionResult Edit(int id)
		{
			ViewBag.Authors = context.Authors
					.OrderBy(p => p.AuthorId).ToList();
			ViewBag.Genres = context.Genres
					.OrderBy(p => p.GenreId).ToList();

			var books = context.Books
										.OrderBy(b => b.BookId).ToList();

			Book book = context.Books
						.Where(b => b.BookId == id)
						.OrderBy(b => b.BookId)
						.FirstOrDefault();

			// use ViewBag to pass data to view
			ViewBag.books = books;
			ViewBag.SelectedBook = id;

			// bind products to view
			return View(book);
		}

		[HttpGet]
		public IActionResult DeleteConfirmed(int id)
		{
			var book = context.Books.FirstOrDefault(b => b.BookId == id);
			if (book != null)
			{
				context.Books.Remove(book);
				context.SaveChanges();
			}

			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			ViewBag.Authors = context.Authors
					.OrderBy(p => p.AuthorId).ToList();
			ViewBag.Genres = context.Genres
					.OrderBy(p => p.GenreId).ToList();

			Book book = context.Books.Where(b => b.BookId == id)
				.FirstOrDefault() ?? new Book();

			return View("Delete", book);
		}

		[HttpGet]
		public IActionResult StaffPick(string title)
		{

			Book book = context.Books.Where(b => b.Title == title).Include(b => b.Genre).Include(b => b.authorObject).FirstOrDefault() ?? new Book();
			return View(book);
		}
    }
}