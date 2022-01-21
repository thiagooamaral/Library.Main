using System.Threading.Tasks;
using System.Collections.Generic;
using LibraryService.WebAPI.Models;

namespace LibraryService.WebAPI.Services.Contracts
{
    public interface ILibrariesService
    {
        Task<Library> Add(Library library);
        Task<IEnumerable<Library>> AddRange(IEnumerable<Library> libraries);
        Task<Library> Update(Library library);
        Task<bool> Delete(Library library);
        Task<IEnumerable<Library>> Get(int[] ids);
    }
}