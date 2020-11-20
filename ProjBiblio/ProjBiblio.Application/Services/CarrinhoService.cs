using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ProjBiblio.Application.InputModels;
using ProjBiblio.Application.Interfaces;
using ProjBiblio.Application.ViewModels;
using ProjBiblio.Domain.Entities;
using ProjBiblio.Domain.Interfaces;

namespace ProjBiblio.Application.Services
{
    public class CarrinhoService : ICarrinhoService
    {
        public IUnitOfWork _uow;
        public IMapper _mapper;

        public CarrinhoService(IUnitOfWork uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }

        public CarrinhoListViewModel GetPorSession(string sessionId)
        {
            var livros = this._uow.CarrinhoRepository.GetCarrinhoPorSessionId(sessionId);

            return new CarrinhoListViewModel()
            {
                Items =  _mapper.Map<IEnumerable<CarrinhoViewModel>>(livros)
            };

            // return new CarrinhoListViewModel()
            // {
            //     Items = (from l in livros.ToList()
            //                 select new CarrinhoViewModel
            //                 {
            //                     EmprestimoID = l.EmprestimoID,
            //                     LivroID = l.LivroID,
            //                     NomeLivro = l.Livro.Titulo,
            //                     Quantidade = l.Quantidade,
            //                     SessionUserID = l.SessionUserID
            //                 }).ToList()
            // };
        }

        public CarrinhoViewModel Delete(int id)
        {
            var carrinho = this._uow.CarrinhoRepository.GetById(a => a.CarrinhoID == id);

            if (carrinho == null)
            {
                return null;
            }

            _uow.CarrinhoRepository.Delete(carrinho);
            _uow.Commit();

            return _mapper.Map<CarrinhoViewModel>(carrinho);
        }

        public CarrinhoViewModel Post(CarrinhoInputModel carrinhoInputModel)
        {
            var carrinho = _mapper.Map<Carrinho>(carrinhoInputModel);

            _uow.CarrinhoRepository.Add(carrinho);
            _uow.Commit();

            return _mapper.Map<CarrinhoViewModel>(carrinho);
        }
    }
}