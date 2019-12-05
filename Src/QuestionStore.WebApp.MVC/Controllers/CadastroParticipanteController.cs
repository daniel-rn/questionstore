using Microsoft.AspNetCore.Mvc;
using QuestionStore.Core.Service;
using QuestionStore.WebApp.MVC.Models;
using System.Collections.Generic;
using System.Linq;

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
            return View();
        }
        public IActionResult Privacy()
        {
            return View("CadastroParticipante");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FormularioContato([Bind("Nome")]CadastroParticipanteModel model)
        {
            var validador = new CadastroParticipanteValidador(model);

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

            _serviceParticipante.Insert(participante);

            return View("Index");
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