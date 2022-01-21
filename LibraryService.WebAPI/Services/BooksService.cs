using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using LibraryService.WebAPI.Data;
using LibraryService.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using LibraryService.WebAPI.Services.Contracts;

namespace LibraryService.WebAPI.Services
{
    public class BooksService : IBooksService
    {
        private readonly TestProjectContext _context;

        public BooksService(TestProjectContext context) =>
            _context = context;

        public async Task<IEnumerable<Book>> Get(int libraryId, int[] ids)
        {
            var users = _context.Books.Where(x => x.LibraryId == libraryId).AsQueryable();

            if (ids != null && ids.Any())
                users = users.Where(x => ids.Contains(x.Id));

            return await users.ToListAsync();
        }

        public async Task<Book> Add(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();

            return book;
        }

        public async Task<Book> Update(Book book)
        {
            var userForChanges = await _context.Books.SingleAsync(x => x.Id == book.Id);
            userForChanges.Name = book.Name;

            _context.Books.Update(userForChanges);
            await _context.SaveChangesAsync();

            return book;
        }

        public async Task<bool> Delete(Book book)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return true;
        }
    }

}
