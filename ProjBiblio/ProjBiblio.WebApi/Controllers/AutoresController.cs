using Microsoft.AspNetCore.Mvc;
using ProjBiblio.Application.InputModels;
using ProjBiblio.Application.Interfaces;
using ProjBiblio.Application.ViewModels;

namespace ProjBiblio.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]

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

            return _autorService.Get(id);
        }

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
    }
}