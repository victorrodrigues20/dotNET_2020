using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ProjBiblio.Application.DTOs;
using ProjBiblio.Application.InputModels;
using ProjBiblio.Application.Interfaces;
using ProjBiblio.Application.ViewModels;
using ProjBiblio.Domain.Entities;
using ProjBiblio.Domain.Interfaces;

namespace ProjBiblio.Application.Services
{
    public class LivroService : ILivroService
    {
        public IUnitOfWork _uow;
        public IMapper _mapper;

        public LivroService(IUnitOfWork uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }

        public LivroListViewModel Get()
        {
            var livros = this._uow.LivroRepository.Get();

            return new LivroListViewModel()
            {
                Livros =  _mapper.Map<IEnumerable<LivroViewModel>>(livros)
            };
        }

        public LivroViewModel Get(int id)
        {
            var livro = this._uow.LivroRepository.GetById(a => a.LivroID == id);
            return _mapper.Map<LivroViewModel>(livro);
        }

        public LivroViewModel Post(LivroInputModel livroInputModel)
        {
            var livro = _mapper.Map<Livro>(livroInputModel);

            _uow.LivroRepository.Add(livro);
            _uow.Commit();

            return _mapper.Map<LivroViewModel>(livro);
        }

        public LivroViewModel Put(int id, LivroInputModel livroInputModel)
        {
            _uow.LivroRepository.DeleteLivrosAutor(id);
            _uow.Commit();

            var livro = _mapper.Map<Livro>(livroInputModel);

            foreach (var l in livro.LivAutor) {
                l.Livro = livro;
            }

            // livro.LivAutor = new List<LivroAutor>();
            // livro.LivAutor.Add(new LivroAutor() { AutorID = 16 });
            
            _uow.LivroRepository.Update(livro);
            _uow.Commit();

            return _mapper.Map<LivroViewModel>(livro);
        }

        public LivroViewModel Delete(int id)
        {
            var livro = this._uow.LivroRepository.GetById(a => a.LivroID == id);

            if (livro == null)
            {
                return null;
            }

            _uow.LivroRepository.Delete(livro);
            _uow.Commit();

            return _mapper.Map<LivroViewModel>(livro);
        }
        
        // public LivroViewModel Get(int id)
        // {
        //     var livro = this._uow.LivroRepository.GetByIdInclude(a => a.LivroID == id);

        //     if (livro == null)
        //         livro = new Livro();

        //     var livroViewModel = _mapper.Map<LivroViewModel>(livro);

        //     livroViewModel.Autores = (from a in this._uow.AutorRepository.Get()
        //                               select new AutorSelectListDto
        //                               {
        //                                   AutorID = a.AutorID,
        //                                   Nome = a.Nome,
        //                                   Selecionado = livro.LivAutor.Any(la => la.AutorID == a.AutorID)
        //                               }).ToList();

        //     return livroViewModel;
        // }
    }
}