using Microsoft.AspNetCore.Mvc;
using ProjBiblio.Application.InputModels;
using ProjBiblio.Application.Interfaces;
using ProjBiblio.Application.ViewModels;

namespace ProjBiblio.WebApi.Controllers
{
    [ApiController]
    [Route("Livros")]

    public class LivrosController  : ControllerBase
    {
        private ILivroService _livroService;

        public LivrosController(ILivroService livroService)
        {
            this._livroService = livroService;
        }

        [HttpGet]
        public LivroListViewModel Get()
        {
            return _livroService.Get();
        }

        [HttpGet("{id}", Name="GetLivrosDetails")]
        public ActionResult<LivroViewModel> Get(int id) 
        { 
            var result = _livroService.Get(id);

            if (result == null)
                return NotFound();

            return _livroService.Get(id);
        }

        [HttpPost]
        public ActionResult Post([FromBody] LivroInputModel livro)
        {
            var result = _livroService.Post(livro);

            return new CreatedAtRouteResult("GetLivrosDetails", 
                new { id = result.Id}, result);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] LivroInputModel livro)
        {
            if (id != livro.Id)
            {
                return BadRequest();
            }

            var result = _livroService.Put(id, livro);

            return new CreatedAtRouteResult("GetLivrosDetails", 
                new { id = result.Id }, result);
        }

        [HttpDelete("{id}")]
        public ActionResult<LivroViewModel> Delete(int id)
        {
            var result = _livroService.Delete(id);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }
    }
}