using AutoMapper;
using ProjBiblio.Application.Interfaces;
using ProjBiblio.Application.ViewModels;
using ProjBiblio.Domain.Interfaces;

namespace ProjBiblio.Application.Services
{
    public class AutorService : IAutorService
    {
        public IUnitOfWork _uow;
        public IMapper _mapper;

        public AutorService(IUnitOfWork uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }

        public AutorListViewModel Get()
        {
            return new AutorListViewModel()
            {
                Autores = this._uow.AutorRepository.Get()
            };
        }

        public AutorViewModel Get(int id)
        {
            var autor = this._uow.AutorRepository.GetById(a => a.AutorID == id);
            return _mapper.Map<AutorViewModel>(autor);
        }
    }
}