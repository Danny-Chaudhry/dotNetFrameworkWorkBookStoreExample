using System;

namespace BookStore.Models.ViewModels
{
	public class PageInformation
	{
		public int TotalItems { get; set; }
		public int items_PerPage { get; set; }
		public int Current_page { get; set; }
		public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / items_PerPage); 
	}
}
