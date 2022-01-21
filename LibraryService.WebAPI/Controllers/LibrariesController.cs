using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LibraryService.WebAPI.Models;
using LibraryService.WebAPI.SeedData;
using LibraryService.WebAPI.Services.Contracts;

namespace LibraryService.WebAPI.Controllers
{
    [ApiController]
    [Route("v1/libraries")]
    public class LibrariesController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public async Task<ActionResult> Create([FromBody] LibraryForm library, [FromServices] ILibrariesService service)
        {
            try
            {
                var result = await service.Add(library);
                return Ok(result);
            }
            catch
            {
                return BadRequest(new { message = "Erro ao criar uma biblioteca" });
            }
        }

        [HttpPost]
        [Route("create-range")]
        public async Task<ActionResult> CreateRange([FromBody] IEnumerable<LibraryForm> libraries, [FromServices] ILibrariesService service)
        {
            try
            {
                var result = await service.AddRange(libraries.Select(item => (Library)item));
                return Ok(result);
            }
            catch
            {
                return BadRequest(new { message = "Erro ao criar uma ou mais bibliotecas" });
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult> Update(int id, [FromBody] LibraryForm library, [FromServices] ILibrariesService service)
        {
            try
            {
                if (library.Id != id)
                    return NotFound(new { message = "Biblioteca não encontrada" });

                var result = await service.Update(library);
                return Ok(result);
            }
            catch
            {
                return BadRequest(new { message = "Erro ao atualizar uma biblioteca" });
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> Delete(int id, [FromBody] LibraryForm library, [FromServices] ILibrariesService service)
        {
            try
            {
                if (library.Id != id)
                    return NotFound(new { message = "Biblioteca não encontrada" });

                var result = await service.Delete(library);
                return Ok(new { message = "Biblioteca removida com sucesso" });
            }
            catch
            {
                return BadRequest(new { message = "Erro ao excluir uma biblioteca" });
            }
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult> Get([FromQuery] int[] ids, [FromServices] ILibrariesService service)
        {
            try
            {
                var result = await service.Get(ids);

                if (result.Any())
                    return Ok(result);
                else
                    return NotFound();
            }
            catch
            {
                return BadRequest(new { message = "Erro ao pesquisar pela(s) biblioteca(s)" });
            }
        }
    }
}
