using BookStore.Infrastructure;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace BookStore.Pages
{
    public class CartModel : PageModel
    {
        private IBookStoreRespository bookStoreRespository;
		public CartModel(IBookStoreRespository storeRespository, Cart cartService)
		{
			bookStoreRespository = storeRespository;
			Cart = cartService;
		}
		public Cart Cart { get; set; }
		public string ReturnUrl { get; set; }
		public void OnGet(string returnUrl)
        {
			ReturnUrl = returnUrl ?? "/";
			// no longer needed can be handled by the service thru Dependency injection
			//Cart = HttpContext.Session.GetJSON<Cart>("cart") ?? new Cart();
        }
        public IActionResult OnPost(long bookID, string returnUrl)
		{
			Book book = bookStoreRespository.Books.FirstOrDefault(b => b.BookId == bookID);
			//Cart = HttpContext.Session.GetJSON<Cart>("cart") ?? new Cart();
			Cart.AddItem(book, 1);
			//HttpContext.Session.SetJSON("cart", Cart);
			return RedirectToPage(new { returnUrl = returnUrl });
		}
		public IActionResult OnPostRemove(long bookId, string returnUrl)
		{
			Cart.RemoveItems(Cart.CartItems.First(ri => ri.Book.BookId == bookId).Book);
			return RedirectToPage(new {returnUrl = returnUrl});
		}
	}
}
