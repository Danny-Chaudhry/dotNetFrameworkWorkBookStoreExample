using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Components
{
	public class BSCartSummViewComponent : ViewComponent
	{
		private Cart cart;
		public BSCartSummViewComponent(Cart cartService)
		{
			cart = cartService;
		}
		public IViewComponentResult Invoke()
		{
			return View(cart);
		}
	}
}
