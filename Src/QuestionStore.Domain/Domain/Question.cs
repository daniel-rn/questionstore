using System.Collections.Generic;

namespace QuestionStore.Domain.Domain
{
    public class Question : Entity
    {
        public string Description { get; set; }

        public string Id { get; set; }

        public List<Alternativas> Alternativas { get; set; }

    }
}
