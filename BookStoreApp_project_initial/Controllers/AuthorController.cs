using BookStoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.Controllers
{
	public class AuthorController : Controller
	{
		private readonly BookstoreContext context;

		public AuthorController(BookstoreContext ctx)
		{
			context = ctx;
		}

		// GET: Author
		public IActionResult Index(int page = 1, int pageSize = 5)
		{
			int skip = (page - 1) * pageSize;
			var authorsQuery = context.Authors.OrderBy(a => a.LastName);
			var totalCount = authorsQuery.Count();
			var authors = authorsQuery.Skip(skip).Take(pageSize).ToList();

			var pagedList = new PagedList<Author>
			{
				Items = authors,
				PageNumber = page,
				PageSize = pageSize,
				TotalCount = totalCount
			};

			return View(pagedList);
		}

	}
}
