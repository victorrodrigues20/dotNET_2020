using System.Collections.Generic;
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
    public class CarrinhoController : ControllerBase
    {
        private ICarrinhoService _carrinhoService;

        public CarrinhoController(ICarrinhoService carrinhoService)
        {
            this._carrinhoService = carrinhoService;
        }

        [HttpGet("{id}", Name="GetCarrinhosDetails")]
        public CarrinhoListViewModel Get(string id) 
        { 
            return _carrinhoService.GetPorSession(id);
        }

        [HttpPost]
        public ActionResult Post([FromBody] CarrinhoInputModel carrinho)
        {
             _carrinhoService.Post(carrinho);

            return new CreatedAtRouteResult("GetCarrinhosDetails", 
                new { id = carrinho.SessionUserID });
        }

        [HttpDelete("{id}")]
        public ActionResult<CarrinhoViewModel> Delete(int id)
        {
            var result = _carrinhoService.Delete(id);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }
    }
}