using ControleFamiliar.Mapeadores;
using System.Collections.Generic;

namespace QuestionStore.Core.Mapping
{
    public class MapperQuestion
    {

        public Question obtenhaQuestoes()
        {
            var question = new Question();

            using (var transacao = Connection.ObtenhaFbTransaction())
            {
                var comando = Connection.ObtehaComando($"SELECT * FROM QUESTION");
                comando.Transaction = transacao;
                var dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    question = new Question()
                    {
                        Description = dr.GetValue(1).ToString()
                    };
                }
            }

            return question;
        }

    }

    public class Question
    {
        public string Description { get; set; }
    }
}

