using FluentValidation.Results;
using System;
using MediatR;
using System.Collections.Generic;

namespace QuestionStore.Core.Commands
{
    public abstract class Command : IRequest<bool>
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        public IList<ValidationFailure> Errors => ValidationResult.Errors;

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}
