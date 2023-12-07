using BookStoreApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Text.Json;
using NToastNotify;

namespace BookStoreApp.Controllers
{
    [Authorize]
    public class CartController : Controller
    {

        private UserManager<User> userManager;
        private BookstoreContext context;
        private SignInManager<User> signInManager;
        private readonly IToastNotification _toastNotification;


        public CartController(BookstoreContext ctx,UserManager<User> userMngr,
            SignInManager<User> signInMngr, IToastNotification toastNotification)
        {
            userManager = userMngr;
            signInManager = signInMngr;
            context = ctx;
            _toastNotification = toastNotification;
        }

        public IActionResult CartView()
        {
            
            var userCart = GetUserCartFromCookie();

            List<Book> books = context.Books.Include(b => b.authorObject).Include(b => b.Genre).ToList();
            List<Book> userCartBooks = null;

            if(userCart != null)
            {
                userCartBooks = new List<Book>();
                foreach (string bookId in userCart.BooksIds) {
                
                    foreach (Book b in  books)
                    {
                        if(int.Parse(bookId) == b.BookId)
                        {
                            userCartBooks.Add(b);
                        }

                    }
 
                }

                
            }
            
            return View(userCartBooks);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int id)
        {

            var username = User.Identity.Name;

            var userCart = GetUserCartFromCookie();

            if (userCart != null)
            {
                if (!userCart.BooksIds.Contains(id.ToString()))
                {
                    // Add the new productId to the list
                    userCart.BooksIds.Add(id.ToString());

                    // Update the user's cart in the cookie
                    SaveUserCartToCookie(userCart);
                }

            } else
            {
                userCart = new UserCart
                {
                    UserName = username,
                    BooksIds = new List<string> { id.ToString() }
                };

                SaveUserCartToCookie(userCart);
            }

            Book book = context.Books.Where(b => b.BookId == id).FirstOrDefault();
            string title = book.Title;

            string message = $"Added '{title}' to your Cart";

            _toastNotification.AddSuccessToastMessage(message);
            return RedirectToAction("Index", "Book");
            //return NoContent();

		}

        private UserCart GetUserCartFromCookie()
        {
            var cookieValue = Request.Cookies[$"UserCartCookie_{User.Identity.Name}"];
            return cookieValue != null ? JsonSerializer.Deserialize<UserCart>(cookieValue) : null;
        }

        private void SaveUserCartToCookie(UserCart userCart)
        {
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(30),
                HttpOnly = true,
                Secure = true
            };

            var cookieValue = JsonSerializer.Serialize(userCart);
            Response.Cookies.Append($"UserCartCookie_{userCart.UserName}", cookieValue, cookieOptions);
        }

        public IActionResult RemoveBookFromCart(int id)
        {
            var userCart = GetUserCartFromCookie();

            if (userCart != null && userCart.BooksIds.Contains(id.ToString()))
            {
                
                // Add the new productId to the list
                userCart.BooksIds.Remove(id.ToString());

                // Update the user's cart in the cookie
                SaveUserCartToCookie(userCart);


                Book book = context.Books.Where(b => b.BookId == id).FirstOrDefault();
                string title = book.Title;

                string message = $"Removed '{title}' from your Cart";

                _toastNotification.AddSuccessToastMessage(message);
                return RedirectToAction("CartView", "Cart");

            }
            else { 
                return Json(new { error = "Error somthing happend" });
            }
            
        }


    }
}
