using FluentValidation;

namespace QuestionStore.Core.Service
{
    public class InsertParticipanteCommand : Command
    {
        public int Id { get; set; }
        public int Idade { get; set; }
        public string Nome { get; set; }

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
            RuleFor(c => c.Nome)
               .NotEmpty()
               .WithMessage("O nome do participante inválido");

            RuleFor(c => c.Idade)
               .NotEmpty()
               .WithMessage("Idade do participante inválido");
        }
    }
}
