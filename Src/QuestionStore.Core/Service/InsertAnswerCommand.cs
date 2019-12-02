namespace QuestionStore.Core.Service
{
    public class InsertAnswerCommand
    {
        public string IdQuestion { get; set; }

        public string IdAnswer { get; set; }
    }
}