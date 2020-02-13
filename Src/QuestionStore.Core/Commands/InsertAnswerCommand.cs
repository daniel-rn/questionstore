namespace QuestionStore.Core.Commands
{
    public class InsertAnswerCommand
    {
        public string IdQuestion { get; set; }

        public string IdAnswer { get; set; }
    }
}