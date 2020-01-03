using ControleFamiliar.Mapeadores;
using Microsoft.Extensions.Configuration;
using QuestionStore.Core.Data;
using QuestionStore.Core.Service;
using QuestionStore.Domain.Domain;
using System;
using System.Collections.Generic;

namespace QuestionStore.Core.Mapping
{
    public class AnswerMapper : IMapper
    {
        private readonly IConfiguration Configuration;

        public AnswerMapper(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void Insert(InsertAnswerCommand insertAnswer)
        {
            using (var conexao = Connection.Factory.Crie(Configuration))
            using (var cmd = conexao.ObtenhaComando())
            {
                var tx = cmd.Transaction;

                var ultimoCodigo = ObtenhaUltimoCodigo();
                cmd.CommandText = $@"INSERT INTO ANSWER (ANSCODIGO, ANSQSID, ANSLETRA) VALUES ('{ultimoCodigo}', '{insertAnswer.IdQuestion}', '{insertAnswer.IdAnswer}');";
                cmd.ExecuteNonQuery();

                tx.Commit();
            }

        }

        public List<Answer> GetAllAnswers()
        {
            var answerList = new List<Answer>();

            using (var transacao = Connection_obsoleta.ObtenhaFbTransaction())
            using (var cmd = Connection_obsoleta.ObtenhaComando())
            {
                cmd.CommandText = $@"SELECT ANSQSID, ANSLETRA FROM ANSWER";

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        answerList.Add(new Answer
                        {
                            Question = dr.GetValue(0).ToString(),
                            Resposta = dr.GetValue(1).ToString()
                        });
                    }
                }

                transacao.Connection.Close();
            }

            return answerList;
        }

        private int ObtenhaUltimoCodigo()
        {
            using (var transacao = Connection_obsoleta.ObtenhaFbTransaction())
            using (var cmd = Connection_obsoleta.ObtenhaComando())
            {
                cmd.CommandText = $@"SELECT MAX(ANSWER.ANSCODIGO) FROM ANSWER";
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (dr.IsDBNull(0))
                        {
                            return 1;
                        }

                        return Convert.ToInt32(dr.GetValue(0)) + 1;
                    }

                }

                transacao.Connection.Close();
            }

            return 0;
        }

        public void Insert(Command command)
        {
            throw new NotImplementedException();
        }
    }

}