using QuestionStore.Core.Mapping;
using QuestionStore.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuestionStore.Core.Service
{
    public class ServiceAnswer
    {
        public void InsertAnswer(CommandInsertAnswer insertAnswer)
        {

            var map = new MapperAnswer();
            map.Insert(insertAnswer);
        }

        public List<Answer> GetAllAnswers()
        {
            var map = new MapperAnswer();
            return map.GetAllAnswers();
        }
    }
}
