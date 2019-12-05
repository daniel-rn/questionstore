using QuestionStore.Core.Mapping;
using QuestionStore.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuestionStore.Core.Service
{
    public class ServiceAnswer : IServiceAnswer
    {
        public void InsertAnswer(InsertAnswerCommand insertAnswer)
        {

            var map = new AnswerMapper();
            map.Insert(insertAnswer);
        }

        public List<Answer> GetAllAnswers()
        {
            var map = new AnswerMapper();
            return map.GetAllAnswers();
        }
    }

    public interface IServiceAnswer
    {
    }
}
