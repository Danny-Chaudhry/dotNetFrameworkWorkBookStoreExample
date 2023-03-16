using System.Collections.Generic;
using System.Linq;

namespace BookStore.Models
{
    public interface IBookStoreRespository
    {
        IQueryable<Book> Books { get; }
        //IEnumerable<Book> Books { get; }
    }
}
