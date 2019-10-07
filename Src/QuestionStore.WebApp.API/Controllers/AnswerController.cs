using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuestionStore.Core.Service;
using QuestionStore.Domain.Domain;
using QuestionStore.WebApp.API.Models;
using System.Collections.Generic;

namespace QuestionStore.WebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        // GET api/answer
        [HttpGet]
        public ActionResult<string> Get()
        {
            var srv = new ServiceAnswer();
            List<Answer> answers = srv.GetAllAnswers();

            return JsonConvert.SerializeObject(answers);
        }

        // POST api/answer
        [HttpPost]
        public void Post([FromBody] AnswerModel value)
        {
            var command = new CommandInsertAnswer
            {
                IdQuestion = value.IdQuestion,
                Letra = value.Letra
            };

            var svc = new ServiceAnswer();
            svc.InsertAnswer(command);
        }
    }
}