using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuestionStore.Core.Service;
using QuestionStore.Domain.Domain;
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
        public void Post([FromBody] dynamic value)
        {
            var itens = value as Newtonsoft.Json.Linq.JObject;
            var svc = new ServiceAnswer();

            foreach (var item in itens)
            {
                var command = new CommandInsertAnswer
                {
                    IdQuestion = item.Key.ToString(),
                    IdAnswer = item.Value.ToString()
                };

                svc.InsertAnswer(command);
            }
        }

    }
}