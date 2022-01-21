using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryService.WebAPI.SeedData;
using LibraryService.WebAPI.Services.Contracts;

namespace LibraryService.WebAPI.Controllers
{
    [ApiController]
    [Route("v1/books")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _service;

        public BooksController(IBooksService service) =>
            _service = service;

        [HttpPost]
        [Route("")]
        public async Task<ActionResult> Create([FromBody] BookForm book)
        {
            try
            {
                var result = await _service.Add(book);
                return Ok(result);
            }
            catch
            {
                return BadRequest(new { message = "Erro ao criar um livro" });
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult> Update(int id, [FromBody] BookForm book)
        {
            try
            {
                if (book.Id != id)
                    return NotFound(new { message = "Livro não encontrado" });

                var result = await _service.Update(book);
                return Ok(result);
            }
            catch
            {
                return BadRequest(new { message = "Erro ao atualizar um livro" });
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> Delete(int id, [FromBody] BookForm book)
        {
            try
            {
                if (book.Id != id)
                    return NotFound(new { message = "Livro não encontrado" });

                var result = await _service.Delete(book);
                return Ok(new { message = "Livro removido com sucesso" });
            }
            catch
            {
                return BadRequest(new { message = "Erro ao excluir um livro" });
            }
        }

        [HttpGet]
        [Route("{libraryId:int}")]
        public async Task<ActionResult> Get(int libraryId, [FromQuery] int[] ids)
        {
            try
            {
                var result = await _service.Get(libraryId, ids);

                if (result.Any())
                    return Ok(result);
                else
                    return NotFound();
            }
            catch
            {
                return BadRequest(new { message = "Erro ao pesquisar pelo(s) livro(s)" });
            }
        }
    }
}
