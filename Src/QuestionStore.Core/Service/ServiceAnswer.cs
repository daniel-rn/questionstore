using QuestionStore.Core.Mapping;
using QuestionStore.Domain.Domain;
using System.Collections.Generic;

namespace QuestionStore.Core.Service
{
    public class ServiceAnswer : IServiceAnswer
    {
        private readonly AnswerMapper mapper;

        public ServiceAnswer(IMapper mapper)
        {
            this.mapper = (AnswerMapper)mapper;
        }

        public void InsertAnswer(InsertAnswerCommand insertAnswer)
        {
            mapper.Insert(insertAnswer);
        }

        public List<Answer> GetAllAnswers()
        {
            return mapper.GetAllAnswers();
        }
    }

    public interface IServiceAnswer
    {
    }
}
