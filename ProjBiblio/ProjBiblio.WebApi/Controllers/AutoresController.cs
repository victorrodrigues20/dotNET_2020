using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjBiblio.Application.DTOs;
using ProjBiblio.Application.InputModels;
using ProjBiblio.Application.Interfaces;
using ProjBiblio.Application.ViewModels;

namespace ProjBiblio.WebApi.Controllers
{
    [Authorize(AuthenticationSchemes="Bearer")]
    [ApiController]
    [ApiVersion( "1" )]
    [Route("v{version:apiVersion}/Autores")]
    [Produces("application/json")]
    public class AutoresController  : ControllerBase
    {
        private IAutorService _autorService;

        public AutoresController(IAutorService autorService)
        {
            this._autorService = autorService;
        }

        [HttpGet]
        public AutorListViewModel Get()
        {
            return _autorService.Get();
        }

        [HttpGet("{id}", Name="GetDetails")]
        public ActionResult<AutorViewModel> Get(int id) 
        { 
            var result = _autorService.Get(id);

            if (result == null)
                return NotFound();

            return result;
        }

        /// <summary>
        /// Inclui um novo cliente
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        /// 
        /// {
        ///     "id" : 0,
        ///     "nome": "Novo Autor"
        /// }
        /// 
        /// </remarks>
        /// <param name="autor"> objeto AutorInputModel</param>
        /// <returns>objeto autor incluído</returns>
        /// <remarks>retorna um objeto autor incluído</remarks>
        [HttpPost]
        public ActionResult Post([FromBody] AutorInputModel autor)
        {
            var result = _autorService.Post(autor);

            return new CreatedAtRouteResult("GetDetails", 
                new { id = result.Id}, result);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] AutorInputModel autor)
        {
            if (id != autor.Id)
            {
                return BadRequest();
            }

            var result = _autorService.Put(id, autor);

            return new CreatedAtRouteResult("GetDetails", 
                new { id = result.Id }, result);
        }

        [HttpDelete("{id}")]
        public ActionResult<AutorViewModel> Delete(int id)
        {
            var result = _autorService.Delete(id);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        [HttpGet("listautoreslivro/{id}")]
        public IList<AutorSelectListDto> ListagemAutoresPorLivro(int id)
        {
            var result = _autorService.ListagemAutoresPorLivro(id);

            return result;
        }
    }
}