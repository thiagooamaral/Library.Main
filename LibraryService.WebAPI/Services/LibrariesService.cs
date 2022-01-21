using System;
using System.Linq;
using System.Threading.Tasks;
using LibraryService.WebAPI.Data;
using System.Collections.Generic;
using LibraryService.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using LibraryService.WebAPI.Services.Contracts;

namespace LibraryService.WebAPI.Services
{
    public class LibrariesService : ILibrariesService
    {
        private readonly TestProjectContext _context;

        public LibrariesService(TestProjectContext context) =>
            _context = context;

        public async Task<IEnumerable<Library>> Get(int[] ids)
        {
            var projects = _context.Libraries.AsQueryable();

            if (ids != null && ids.Any())
                projects = projects.Where(x => ids.Contains(x.Id));

            return await projects.ToListAsync();
        }

        public async Task<Library> Add(Library library)
        {
            await _context.Libraries.AddAsync(library);
            await _context.SaveChangesAsync();

            return library;
        }

        public async Task<IEnumerable<Library>> AddRange(IEnumerable<Library> libraries)
        {
            await _context.Libraries.AddRangeAsync(libraries);
            await _context.SaveChangesAsync();

            return libraries;
        }

        public async Task<Library> Update(Library library)
        {
            var projectForChanges = await _context.Libraries.SingleAsync(x => x.Id == library.Id);
            projectForChanges.Name = library.Name;
            projectForChanges.Location = library.Location;

            _context.Libraries.Update(projectForChanges);
            await _context.SaveChangesAsync();

            return library;
        }

        public async Task<bool> Delete(Library library)
        {
            _context.Libraries.Remove(library);
            await _context.SaveChangesAsync();

            return true;
        }
    }

}
