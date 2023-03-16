using System.Linq;

namespace BookStore.Models
{
	public class BSRepository : IBookStoreRespository
	{
		private BS_DBContext _DBContext;
		public BSRepository(BS_DBContext ctx)
		{
			_DBContext = ctx;
		}
		public IQueryable<Book> Books => _DBContext.Books;
	}
}
