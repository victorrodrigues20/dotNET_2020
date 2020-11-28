using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjBiblio.Application.InputModels;
using ProjBiblio.Application.Interfaces;
using ProjBiblio.Application.ViewModels;

namespace ProjBiblio.WebApi.Controllers
{
    [Authorize(AuthenticationSchemes="Bearer")]
    [ApiController]
    [ApiVersion( "1" )]
    [Route("v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    public class EmprestimosController : ControllerBase
    {
        private IEmprestimoService _emprestimoService;

        public EmprestimosController(IEmprestimoService emprestimoService)
        {
            this._emprestimoService = emprestimoService;
        }

        [HttpGet("{id}", Name="GetEmprestimo")]
        public ActionResult<EmprestimoListViewModel> Get(int id) 
        { 
            var result = _emprestimoService.GetPorUsuario(id);

            if (result == null)
                return NotFound();

            return result;
        }

        [HttpGet("Details/{id}", Name="GetEmprestimoDetails")]
        public ActionResult<EmprestimoViewModel> Details(int id) 
        { 
            var result = _emprestimoService.GetEmprestimoDetalhes(id);

            if (result == null)
                return NotFound();

            return result;
        }

        [HttpPost]
        public ActionResult Post([FromBody] EmprestimoInputModel emprestimo)
        {
            var result = _emprestimoService.CriarEmprestimo(emprestimo);

            return new CreatedAtRouteResult("GetEmprestimoDetails", 
                new { id = result.Id }, result);
        }

        [HttpPost("DevolverLivros/{id}")]
        public ActionResult DevolverLivros(int id, [FromBody] EmprestimoInputModel emprestimo)
        {
            if (id != emprestimo.Id)
                return BadRequest();           

            var result = _emprestimoService.DevolverLivros(emprestimo.Id);

            return new CreatedAtRouteResult("GetEmprestimoDetails", 
                new { id = result.Id }, result);
        }
    }
}