using System.Collections.Generic;

namespace QuestionStore.Domain.Domain
{
    public class Question : Entity
    {
        public string Description { get; set; }

        public string Id { get; set; }

        public List<Alternativa> Alternativas { get; set; } = new List<Alternativa>();


        public override string ToString()
        {
            return $"ID: {Id} - Pergunta :{Description}";    
        }
    }
}
