using System.Threading.Tasks;
using System.Collections.Generic;
using LibraryService.WebAPI.Models;

namespace LibraryService.WebAPI.Services.Contracts
{
    public interface IBooksService
    {
        Task<Book> Add(Book book);
        Task<Book> Update(Book book);
        Task<bool> Delete(Book book);
        Task<IEnumerable<Book>> Get(int libraryId, int[] ids);
    }
}