using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace BookStore.Models
{
    public class LoadDataFile
    {
        public static void LoadData(IApplicationBuilder app)
        {
            BS_DBContext _DBContext = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<BS_DBContext>();
            if (_DBContext.Database.GetPendingMigrations().Any())
            {
                _DBContext.Database.Migrate();
            }
            if (!_DBContext.Books.Any())
            {
                _DBContext.Books.AddRange(
                    new Book
                    {
                        Title = "How Computer Works",
                        Description = "Overview of how everything in your computer works",
                        Category = "General Computer Knowledge",
                        Price = 45
                    },
                    new Book
                    {
                        Title = "Upgrading and Repairing PCs",
                        Description = "In depth overview of computers and computer hardware",
                        Category = "General Computer Knowledge",
                        Price = 50
                    },
                    new Book
                    {
                        Title = "CompTIA A+ Certification All in One Exam",
                        Description = "Everything asked in the A+ Certification test",
                        Category = "A+ Certification",
                        Price = 70
                    },
                    new Book
                    {
                        Title = "Ghost in the Wires",
                        Description = "One of the best known hackers in history",
                        Category = "Hacking and computer security",
                        Price = 55
                    },
                    new Book
                    {
                        Title = "Hacking Exposed",
                        Description = "Great series of books that covers all types of computer security related topics",
                        Category = "Hacking and computer security",
                        Price = 40
                    },
                    new Book
                    {
                        Title = "Design Patterns: Elements of Reusable Object Oriented Software",
                        Description = "A great source of information on object oriented design theory",
                        Category = "Computer Programming",
                        Price = 110
                    },
                    new Book
                    {
                        Title = "Don't Make Me Think!",
                        Description = "A beautiful and well designed book that covers all the basics of HTML and CSS used for web design",
                        Category = "Web Design",
                        Price = 35
                    },
                    new Book
                    {
                        Title = "Getting Started in Electronics",
                        Description = "Beginner's electronics book containing hand drawn diagrams of each of the circuits",
                        Category = "Electronics",
                        Price = 85
                    });
                }
            _DBContext.SaveChanges();
        }
    }
}
