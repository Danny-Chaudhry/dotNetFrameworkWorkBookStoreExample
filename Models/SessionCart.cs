using BookStore.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.Json.Serialization;

namespace BookStore.Models
{
	public class SessionCart : Cart
	{
		[JsonIgnore]
		public ISession Session { get; private set; }
		public static Cart GetCart(IServiceProvider serviceProvider)
		{
			ISession session = serviceProvider.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
			SessionCart cartSession = session ?.GetJSON<SessionCart>("cart") ?? new SessionCart();
			cartSession.Session = session;
			return cartSession;
		}
		public override void AddItem(Book book, int quantity)
		{
			base.AddItem(book, quantity);
			Session.SetJSON("cart", this);
		}
		public override void RemoveItems(Book book)
		{
			base.RemoveItems(book);
			Session.SetJSON("cart", this);
		}
		public override void Clear()
		{
			base.Clear();
			Session.Remove("cart");
		}
	}
}
