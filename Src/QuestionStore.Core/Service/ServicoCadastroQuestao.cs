using QuestionStore.Core.Commands;
using QuestionStore.Core.Mapping;
using QuestionStore.Core.Service;
using QuestionStore.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuestionStore.Core.Processos
{
    public class ServicoCadastroQuestao
    {
        public List<Question> Obtenha()
        {
            var map = new QuestionMapper();
            return map.Obtenha();
        }

        public Task Insert(InsertQuestionCommand insertCommand)
        {
            throw new NotImplementedException();
        }
    }
}
