using ProjBiblio.Application.Interfaces;
using ProjBiblio.Application.ViewModels;
using ProjBiblio.Domain.Interfaces;

namespace ProjBiblio.Application.Services
{
    public class LivroService : ILivroService
    {
        public ILivroRepository _livroRepository;

        public LivroService(ILivroRepository livroRepository)
        {
            this._livroRepository = livroRepository;
        }

        public LivroListViewModel Get()
        {
            return new LivroListViewModel()
            {
                Livros = this._livroRepository.Get()
            };
        }
    }
}