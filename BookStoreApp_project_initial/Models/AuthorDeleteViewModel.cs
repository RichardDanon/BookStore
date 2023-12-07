namespace BookStoreApp.Models
{
	public class AuthorDeleteViewModel
	{
		public Author Author { get; set; }
		public List<Book> RelatedBooks { get; set; }
	}
}
