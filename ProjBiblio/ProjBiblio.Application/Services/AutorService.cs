using ProjBiblio.Application.Interfaces;
using ProjBiblio.Application.ViewModels;
using ProjBiblio.Domain.Interfaces;

namespace ProjBiblio.Application.Services
{
    public class AutorService : IAutorService
    {
        public IUnitOfWork _uow;

        public AutorService(IUnitOfWork uow)
        {
            this._uow = uow;
        }

        public AutorListViewModel Get()
        {
            return new AutorListViewModel()
            {
                Autores = this._uow.AutorRepository.Get()
            };
        }
    }
}