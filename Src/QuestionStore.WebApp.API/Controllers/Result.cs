using QuestionStore.Core.Commands;
using System.Collections.Generic;
using System.Linq;

namespace QuestionStore.WebApp.API.Controllers
{
    public class Result
    {
        private readonly Command _command;

        public Result(Command command)
        {
            _command = command;
        }

        public Result(object data)
        {
            Data = data;
        }

        public List<string> Errors => _command?.Errors.Select(c => c.ErrorMessage).ToList() ?? new List<string>();

        public bool Success => !Errors.Any();

        public object Data { get; }
    }

}