using System.Collections.Generic;
using System.Linq;

namespace BookStore.Models
{
	public class Cart
	{
		public List<CartItems> CartItems { get; set; } = new List<CartItems>();
		public virtual void AddItem(Book book, int quantity)
		{
			CartItems items = CartItems.Where(b => b.Book.BookId == book.BookId).FirstOrDefault();
			if(items == null)
			{
				CartItems.Add(new CartItems { Book = book, Quantity = quantity});
			}
			else
			{
				items.Quantity += quantity;
			}
		}
		public virtual void RemoveItems(Book book)
		{
			CartItems.RemoveAll(i => i.Book.BookId == book.BookId);
		}

		public virtual decimal TotalCost()
		{
			return CartItems.Sum(c=>c.Book.Price * c.Quantity);
		}

		public virtual void Clear() => CartItems.Clear();
	}
	public class CartItems
	{
		public int CartItemsID { get; set; }
		public Book Book { get; set; }
		public int Quantity { get; set; }
	}
}
