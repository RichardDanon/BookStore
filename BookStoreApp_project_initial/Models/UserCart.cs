namespace BookStoreApp.Models
{
    public class UserCart
    {
        public string UserName { get; set; }

        public List<string> BooksIds { get; set; }
    }
}
