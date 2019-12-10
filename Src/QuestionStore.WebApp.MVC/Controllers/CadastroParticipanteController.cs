using Microsoft.AspNetCore.Mvc;
using QuestionStore.Core.Service;
using QuestionStore.WebApp.MVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionStore.WebApp.MVC.Controllers
{
    public class CadastroParticipanteController : BaseController
    {
        private ServicoCadastroParticipante _serviceParticipante;

        public CadastroParticipanteController(IServiceParticipante serviceParticipante)
        {
            _serviceParticipante = (ServicoCadastroParticipante)serviceParticipante;
        }

        public IActionResult Index()
        {
            return View("CadastroParticipante");
        }

        public IActionResult FormularioContato(CadastroParticipanteModel model)
        {
            var participante = new InsertParticipanteCommand
            {
                Id = model.Id,
                Nome = model.Nome,
                Idade = model.Idade
            };

            var valid = participante.EhValido();

            if (!valid)
            {
                TempData["Erros"] = participante.ValidationResult.Errors.Select(c => c.ErrorMessage).ToArray();
                return View("Default", model);
            }

            Task.Run(async () =>
            {
                await _serviceParticipante.Insert(participante);
            });

            Task.WaitAll();

            return View("CadastroParticipante", new CadastroParticipanteModel { Id = 0 });
        }
    }

    public abstract class BaseController : Controller
    {
        public Command MyProperty;

        public BaseController(Command command)
        {
            MyProperty = command;
        }
        public BaseController()
        {
        }

        protected IEnumerable<string> ObterMensagensErro()
        {
            return MyProperty.ValidationResult.Errors.Select(c => c.ErrorMessage).ToArray();
        }
    }
}