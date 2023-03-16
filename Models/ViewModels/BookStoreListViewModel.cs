using System.Collections.Generic;

namespace BookStore.Models.ViewModels
{
	public class BookStoreListViewModel
	{
		public IEnumerable<Book> Books{get; set; }
		public PageInformation PageInformation { get; set; }
		public string CurrentCategory { get; set; }
	}
}
