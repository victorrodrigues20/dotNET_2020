using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProjBiblio.Application.DTOs;
using ProjBiblio.Application.InputModels;
using ProjBiblio.Application.Interfaces;
using ProjBiblio.Application.ViewModels;
using ProjBiblio.Domain.Entities;
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
            var autores = this._uow.AutorRepository.Get();

            return new AutorListViewModel()
            {
                Autores =  _mapper.Map<IEnumerable<AutorViewModel>>(autores)
            };
        }

        public AutorViewModel Get(int id)
        {
            var autor = this._uow.AutorRepository.GetById(a => a.AutorID == id);
            return _mapper.Map<AutorViewModel>(autor);
        }

        public AutorViewModel Post(AutorInputModel autorInputModel)
        {
            var autor = _mapper.Map<Autor>(autorInputModel);

            _uow.AutorRepository.Add(autor);
            _uow.Commit();

            return _mapper.Map<AutorViewModel>(autor);
        }

        public AutorViewModel Put(int id, AutorInputModel autorInputModel)
        {
            var autor = _mapper.Map<Autor>(autorInputModel);

            _uow.AutorRepository.Update(autor);
            _uow.Commit();

            return _mapper.Map<AutorViewModel>(autor);
        }

        public AutorViewModel Delete(int id)
        {
            var autor = this._uow.AutorRepository.GetById(a => a.AutorID == id);

            if (autor == null)
            {
                return null;
            }

            _uow.AutorRepository.Delete(autor);
            _uow.Commit();

            return _mapper.Map<AutorViewModel>(autor);
        }

        public IList<AutorSelectListDto> ListagemAutoresPorLivro(int idLivro)
        {
            var autores = this._uow.AutorRepository.Get().ToList();
            var autoresLivro = this._uow.AutorRepository.GetAutoresPorLivro(idLivro);

            return (from a in autores
                    select new AutorSelectListDto
                    {
                        AutorID = a.AutorID,
                        Nome = a.Nome,
                        Selecionado = autoresLivro.Any(la => la.AutorID == a.AutorID)
                    }).ToList();
        }
    }
}