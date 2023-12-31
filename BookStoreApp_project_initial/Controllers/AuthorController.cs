﻿using BookStoreApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.Controllers
{
    [Authorize]
    public class AuthorController : Controller
    {
        private BookstoreContext context { get; set; }

        public AuthorController(BookstoreContext ctx) => context = ctx;

        // Get Authors
        public IActionResult Index(int page = 1, int pageSize = 5, string searchTerm = "")
        {
            int skip = (page - 1) * pageSize;

            var authorsQuery = context.Authors.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                // Apply search filter
                authorsQuery = authorsQuery
                    .Where(a => EF.Functions.Like(a.FirstName, $"%{searchTerm}%") || EF.Functions.Like(a.LastName, $"%{searchTerm}%"));
            }

            authorsQuery = authorsQuery.OrderBy(m => m.AuthorId);

            var totalCount = authorsQuery.Count();
            var authors = authorsQuery.Skip(skip).Take(pageSize).ToList();

            var pagedList = new PagedList<Author>
            {
                Items = authors,
                PageNumber = page,
                PageSize = pageSize,
                TotalCount = totalCount
            };

            var viewModel = new AuthorViewModel
            {
                PageResult = pagedList,
            };

            return View(viewModel);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var author = context.Authors.Find(id);
            return View(author);
        }

        [HttpPost]
        public IActionResult Edit(Author author)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("EditConfirmation", author);
            }
            else
            {
                return View(author);
            }
        }

        [HttpGet]
        public IActionResult EditConfirmation(Author author)
        {
            return View(author);
        }

        [HttpPost]
        public IActionResult ConfirmEdit(Author author)
        {
            if (author.AuthorId == 0)
                context.Authors.Add(author);
            else
                context.Authors.Update(author);

            context.SaveChanges();
            return RedirectToAction("Index", "Author");
        }


		[HttpGet]
		public IActionResult Delete(int id)
		{
			var author = context.Authors.Find(id);
			if (author == null)
			{
				return NotFound();
			}

			// Fetch related books
			var books = context.Books
				.Where(b => b.AuthorId == id)
				.ToList();

			var viewModel = new AuthorDeleteViewModel
			{
				Author = author,
				RelatedBooks = books
			};

			return View("DeleteConfirmation", viewModel);
		}

		[HttpPost]
		public IActionResult ConfirmDelete(int id)
		{
			var author = context.Authors.Find(id);
			if (author == null)
			{
				return NotFound();
			}

			// Remove related books and author
			var books = context.Books.Where(b => b.AuthorId == id).ToList();
			context.Books.RemoveRange(books);
			context.Authors.Remove(author);

			context.SaveChanges();

			return RedirectToAction("Index", "Author");
		}

	}
}