using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuestionStore.WebApp.MVC.Models;

namespace QuestionStore.WebApp.MVC.Controllers
{
    public class CadastroParticipanteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
         public IActionResult Privacy()
        {
            return View("CadastroParticipante");
        }

        public IActionResult FormularioContato(QuestionModel model)
        {
            var x = "x";

            return null;
        }
    }
}