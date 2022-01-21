using LibraryService.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryService.WebAPI.Data
{
    public class TestProjectContext : DbContext
    {
        public TestProjectContext(DbContextOptions<TestProjectContext> options) 
            : base(options) { }

        public DbSet<Library> Libraries { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
