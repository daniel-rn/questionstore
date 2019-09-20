using ControleFamiliar.Mapeadores;
using QuestionStore.Domain.Domain;
using System;

namespace QuestionStore.Core.Mapping
{
    public class MapperQuestion
    {
        public Question Obtenha()
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
                        Description = dr.GetValue(1).ToString(),
                        Id = dr.GetValue(2).ToString()
                    };
                }
            }

            return question;
        }

        public bool Insert(CommandInsertQuestion commandInsertQuestion)
        {
            using (var transacao = Connection.ObtenhaFbTransaction())
            {
                var comando = Connection.ObtehaComando($"SELECT * FROM QUESTION");
                comando.Transaction = transacao;
                var dr = comando.ExecuteReader();

            }

            return false;
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

    //public class Question
    //{
    //    public Question()
    //    {
    //        Guid = Guid.NewGuid();
    //    }

    //    public Guid Guid { get; }

    //    public string Id { get; set; }

    //    public string Description { get; set; }
    //}
}

