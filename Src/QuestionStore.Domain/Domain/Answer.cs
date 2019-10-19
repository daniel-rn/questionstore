namespace QuestionStore.Domain.Domain
{
    public class Answer : Entity
    {
        public string Question { get; set; }
        public string Resposta { get; set; }
    }
}
