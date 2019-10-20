using ControleFamiliar.Mapeadores;
using QuestionStore.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuestionStore.Core.Mapping
{
    public class MapperQuestion
    {
        public List<Question> Obtenha()
        {
            var questionList = new Dictionary<int, Question>();

            using (var transacao = Connection.ObtenhaFbTransaction())
            using (var cmd = Connection.ObtenhaComando())
            {
                cmd.CommandText = $@"SELECT * FROM QUESTION
INNER JOIN ALTERNATIVE ON ALTQSID = QSID";

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int codigo = Convert.ToInt16(dr.GetValue(0).ToString());

                        if (!questionList.TryGetValue(codigo, out var question))
                        {
                            question = new Question()
                            {
                                Description = dr.GetValue(1).ToString(),
                                Id = dr.GetValue(2).ToString()
                            };

                            questionList.Add(codigo, question);
                        }

                        question.Alternativas.Add(new Alternativa()
                        {
                            Id = Convert.ToInt16(dr.GetValue(3).ToString()),
                            Descricao = dr.GetValue(4).ToString(),
                            Letra = dr.GetValue(6).ToString()
                        });
                    }
                }

                transacao.Connection.Close();
            }

            return questionList.Select(c => c.Value).ToList();
        }
    }
}

