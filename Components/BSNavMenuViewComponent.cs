using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BookStore.Components
{
	public class BSNavMenuViewComponent : ViewComponent
	{
		private IBookStoreRespository respository;
		public BSNavMenuViewComponent(IBookStoreRespository storeRespository)
		{
			this.respository = storeRespository;
		}
		public IViewComponentResult Invoke()
		{
			return View(respository.Books
							.Select(x => x.Category)
							.Distinct()
							.OrderBy(x => x)
						);
		}
	}
}
