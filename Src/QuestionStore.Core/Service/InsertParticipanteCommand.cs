using FluentValidation;

namespace QuestionStore.Core.Service
{
    public class InsertParticipanteCommand : Command
    {
        public string Nome { get; set; }
        public int Id { get; set; }
        public int Idade { get; set; }

        public override bool EhValido()
        {
            ValidationResult = new InsertParticipanteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    internal class InsertParticipanteValidation : AbstractValidator<InsertParticipanteCommand>
    {
        public InsertParticipanteValidation()
        {
            //RuleFor(c => c.Id)
            //   .NotEmpty()
            //   .WithMessage("Id do cliente inválido");

            RuleFor(c => c.Nome)
               .NotEmpty()
               .WithMessage("O nome do cliente inválido");

            RuleFor(c => c.Idade)
               .NotEmpty()
               .WithMessage("Idade do cliente inválido");
        }
    }
}
