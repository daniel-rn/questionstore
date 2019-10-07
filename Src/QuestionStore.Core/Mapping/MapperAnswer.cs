using ControleFamiliar.Mapeadores;
using QuestionStore.Core.Service;
using QuestionStore.Domain.Domain;
using System;
using System.Collections.Generic;

namespace QuestionStore.Core.Mapping
{
    public class MapperAnswer
    {
        public MapperAnswer()
        {
        }

        public void Insert(CommandInsertAnswer insertAnswer)
        {
            using (var transacao = Connection.ObtenhaFbTransaction())
            using (var cmd = Connection.ObtenhaComando())
            {
                var ultimoCodigo = ObtenhaUltimoCodigo();
                cmd.CommandText = $@"INSERT INTO ANSWER (ANSCODIGO, ANSQSID, ANSLETRA) VALUES ('{ultimoCodigo}', '{insertAnswer.IdQuestion}', '{insertAnswer.Letra}');";
                cmd.ExecuteNonQuery();

                transacao.Commit();
            }

        }

        public List<Answer> GetAllAnswers()
        {
            var answerList = new List<Answer>();

            using (var transacao = Connection.ObtenhaFbTransaction())
            using (var cmd = Connection.ObtenhaComando())
            {
                cmd.CommandText = $@"SELECT ANSQSID, ANSLETRA FROM ANSWER";

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        answerList.Add(new Answer
                        {
                            IdQuestion = dr.GetValue(0).ToString(),
                            Letra = dr.GetValue(1).ToString()
                        });
                    }
                }
            }

            return answerList;
        }

        private int ObtenhaUltimoCodigo()
        {
            using (var transacao = Connection.ObtenhaFbTransaction())
            using (var cmd = Connection.ObtenhaComando())
            {
                cmd.CommandText = $@"SELECT MAX(ANSWER.ANSCODIGO) FROM ANSWER";
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        return Convert.ToInt32(dr.GetValue(0)) + 1;
                    }

                }
            }

            return 0;
        }
    }

}