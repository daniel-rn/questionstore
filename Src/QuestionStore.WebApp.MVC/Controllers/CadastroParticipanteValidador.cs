using QuestionStore.WebApp.MVC.Models;

namespace QuestionStore.WebApp.MVC.Controllers
{
    internal class CadastroParticipanteValidador : FluentValidation.Validators, IValidador
    {
        private readonly CadastroParticipanteModel _cadastroParticipanteModel;

        public CadastroParticipanteValidador(CadastroParticipanteModel model) 
            : base(model)
        {
            _cadastroParticipanteModel = model;
        }

        public void AdicioneRegras()
        {
            
        }

        public void Valide()
        {

        }
    }
}