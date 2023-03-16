using Microsoft.EntityFrameworkCore;

namespace BookStore.Models
{
    public class BS_DBContext : DbContext
    {
        public BS_DBContext(DbContextOptions<BS_DBContext> op) 
            : base(op)
        {

        }
        public DbSet<Book> Books { get; set; }
    }
}
