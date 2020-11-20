using FluentValidation;

namespace ProjBiblio.Application.InputModels
{
    public class AutorInputModel
    {
        public int Id { get; set; }
        
        public string Nome { get; set; }
    }

    public class AutorInputModelValidator : AbstractValidator<AutorInputModel>
    {
        public AutorInputModelValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("O Nome é obrigatório.")
                            .Length(0, 100).WithMessage("O Nome não pode exceder 100 caracteres.");  
        }
    }
}