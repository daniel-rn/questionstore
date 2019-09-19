using QuestionStore.Core.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuestionStore.Core.Processos
{
    public class ServicoCadastroQuestao
    {
        public void Obtenha()
        {
            var map = new MapperQuestion();
            var q = map.Obtenha();
        }

        public bool Insert(CommandInsertQuestion commandInsertQuestion)
        {
            var map = new MapperQuestion();
            var response = map.Insert(commandInsertQuestion);

            return response;
        }

        public bool Delete()
        {

            return false;
        }

        public bool Update()
        {

            return false;
        }

    }
}
