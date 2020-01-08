using FluentValidation;
using System;

namespace QuestionStore.Core.Service
{
    public class InsertParticipanteCommand : Command
    {
        public int Id { get; set; }
        public int Idade { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }

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
               .WithMessage("O nome do participante deve ser informado.");

            RuleFor(c => c.Idade)
               .NotEmpty()
               .WithMessage("A Idade do participante deve ser informada.");

            RuleFor(c => c.Cpf)
               .NotEmpty()
               .WithMessage("Cpf do participante não deve ser vazio.");
        }
    }
}
