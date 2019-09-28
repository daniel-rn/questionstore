using ControleFamiliar.Mapeadores;
using QuestionStore.Domain.Domain;
using System.Collections.Generic;

namespace QuestionStore.Core.Mapping
{
    public class MapperQuestion
    {
        public List<Question> Obtenha()
        {
            var questionList = new List<Question>();
            using (var transacao = Connection.ObtenhaFbTransaction())
            using (var cmd = Connection.ObtenhaComando())
            {
                cmd.CommandText = $"SELECT * FROM QUESTION";

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        questionList.Add(new Question()
                        {
                            Description = dr.GetValue(1).ToString(),
                            Id = dr.GetValue(2).ToString()
                        });
                    }
                }
            }

            return questionList;
        }

        public bool Insert(CommandInsertQuestion commandInsertQuestion)
        {
            using (var transacao = Connection.ObtenhaFbTransaction())
            {
                //var comando = Connection.ObtehaComando($"SELECT * FROM QUESTION");
                //comando.Transaction = transacao;
                //var dr = comando.ExecuteReader();

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

