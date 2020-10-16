using ProjBiblio.Application.Interfaces;
using ProjBiblio.Application.ViewModels;
using ProjBiblio.Domain.Interfaces;

namespace ProjBiblio.Application.Services
{
    public class AutorService : IAutorService
    {
        public IAutorRepository _autorRepository;

        public AutorService(IAutorRepository autorRepository)
        {
            this._autorRepository = autorRepository;
        }

        public AutorListViewModel Get()
        {
            return new AutorListViewModel()
            {
                Autores = this._autorRepository.Get()
            };
        }
    }
}