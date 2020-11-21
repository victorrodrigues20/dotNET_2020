using System.Collections.Generic;
using AutoMapper;
using ProjBiblio.Application.InputModels;
using ProjBiblio.Application.Interfaces;
using ProjBiblio.Application.ViewModels;
using ProjBiblio.Domain.Entities;
using ProjBiblio.Domain.Interfaces;

namespace ProjBiblio.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        public IUnitOfWork _uow;

        public IMapper _mapper;

        public UsuarioService(IUnitOfWork uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }

        public UsuarioListViewModel Get()
        {
            var usuarios = this._uow.UsuarioRepository.Get();

            return new UsuarioListViewModel()
            {
                Usuarios = _mapper.Map<IEnumerable<UsuarioViewModel>>(usuarios)
            };
        }

        public UsuarioViewModel Post(UsuarioInputModel usuarioInputModel)
        {
            var usuario = _mapper.Map<Usuario>(usuarioInputModel);

            _uow.UsuarioRepository.Add(usuario);
            _uow.Commit();

            return _mapper.Map<UsuarioViewModel>(usuario);
        }
    }
}