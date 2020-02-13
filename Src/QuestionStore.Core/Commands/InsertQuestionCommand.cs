using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuestionStore.Core.Commands
{
    public class InsertQuestionCommand : Command
    {
        public string Descricao { get; set; }

        public override bool EhValido()
        {
            var ValidationResult = new InsertQuestionValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    internal class InsertQuestionValidation : AbstractValidator<InsertQuestionCommand>
    {
        public InsertQuestionValidation()
        {
            RuleFor(c => c.Descricao).NotEmpty();
        }
    }
}
