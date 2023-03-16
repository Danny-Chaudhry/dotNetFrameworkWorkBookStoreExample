using BookStore.Models;
using BookStore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private IBookStoreRespository bookRep;

        //Creating a filter
        public int _Bperpage = 3;
        public HomeController(IBookStoreRespository storeRespository)
		{
            bookRep = storeRespository;
		}
        public IActionResult Index(string category, int book_p=1)
        {

            return View(new BookStoreListViewModel{
                Books = bookRep.Books
                            .Where(x => category == null || x.Category == category)
                            .OrderBy(b => b.BookId)
                            .Skip((book_p - 1) * _Bperpage)
                            .Take(_Bperpage), 
                PageInformation = new PageInformation{
                    Current_page = book_p,
                    items_PerPage = _Bperpage,
                    TotalItems = category == null ? bookRep.Books.Count() : bookRep.Books.Where(c=>c.Category == category).Count()
                } 
                            });
        }
    }
}
