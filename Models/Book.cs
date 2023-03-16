using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [Column(TypeName= "decimal(8,2)")]
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}
