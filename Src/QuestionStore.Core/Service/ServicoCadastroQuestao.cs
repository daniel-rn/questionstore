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
            var q = map.obtenhaQuestoes();
        }
    }
}
