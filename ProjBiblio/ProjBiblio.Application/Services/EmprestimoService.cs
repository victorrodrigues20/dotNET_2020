using System;
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
    public class EmprestimoService : IEmprestimoService
    {
        public IUnitOfWork _uow;
        public IMapper _mapper;

        public EmprestimoService(IUnitOfWork uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }

        public EmprestimoListViewModel GetPorUsuario(int usuarioId)
        {
            var emprestimo = this._uow.EmprestimoRepository.GetEmprestimoPorUsuario(usuarioId);

            return new EmprestimoListViewModel()
            {
                Emprestimos =  _mapper.Map<IEnumerable<EmprestimoViewModel>>(emprestimo)
            };
        }

        public EmprestimoViewModel GetEmprestimoDetalhes(int emprestimoId)
        {
            var emprestimo = this._uow.EmprestimoRepository.GetEmprestimoInclude(emprestimoId);            

            var emprestimoViewModel = _mapper.Map<EmprestimoViewModel>(emprestimo);

            foreach(var livros in emprestimo.LivEmprestimo)
            {
                emprestimoViewModel.Livros.Add(
                    _mapper.Map<LivroViewModel>(livros.Livro)                
                );
            }

            return emprestimoViewModel;
        }

        public EmprestimoViewModel CriarEmprestimo(EmprestimoInputModel emprestimoInputModel)
        {
            var carrinho = this._uow.CarrinhoRepository.GetCarrinhoPorSessionId(emprestimoInputModel.SessionUserID).ToList();

            var emprestimo = new Emprestimo()
            {
                DataInicio = DateTime.Now.ToString(),
                DataFim = DateTime.Now.AddDays(7).ToString(),
                DataDevolucao = null,
                UsuarioID = GetUsuario()
            };

            foreach (var c in carrinho)
                emprestimo.LivEmprestimo.Add(new LivroEmprestimo() { LivroID = c.LivroID });
            
            _uow.EmprestimoRepository.Add(emprestimo);
            _uow.Commit();

            foreach (var c in carrinho) 
            {
                c.EmprestimoID = emprestimo.EmprestimoID;
                _uow.CarrinhoRepository.Update(c);
                _uow.Commit();
            }

            return _mapper.Map<EmprestimoViewModel>(emprestimo);
        }

        public EmprestimoViewModel DevolverLivros(int emprestimoId)
        {
            var emprestimo = _uow.EmprestimoRepository.GetById(e => e.EmprestimoID == emprestimoId);

            emprestimo.DataDevolucao = DateTime.Now.ToString();
            
            _uow.EmprestimoRepository.Update(emprestimo);
            _uow.Commit();

            return _mapper.Map<EmprestimoViewModel>(emprestimo);
        }

        private int GetUsuario()
        {
            var usuario = _uow.UsuarioRepository.Get().FirstOrDefault();

            if (usuario == null)
            {
                usuario = new Usuario() { Nome = "Usuario Teste" };
                _uow.UsuarioRepository.Add(usuario);
                _uow.Commit();
            }

            return usuario.UsuarioID;
        }
    }
}