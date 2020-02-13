using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuestionStore.Core.Commands;
using QuestionStore.Core.Service;
using QuestionStore.Domain.Domain;
using System.Collections.Generic;

namespace QuestionStore.WebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly ServiceAnswer serviceAnswer;

        public AnswerController(IServiceAnswer serviceAnswer)
        {
            this.serviceAnswer = (ServiceAnswer)serviceAnswer;
        }

        // GET api/answer
        [HttpGet]
        public ActionResult<string> Get()
        {
            List<Answer> answers = serviceAnswer.GetAllAnswers();
            return JsonConvert.SerializeObject(answers);
        }

        // POST api/answer
        [HttpPost]
        public void Post([FromBody] dynamic value)
        {
            var itens = value as Newtonsoft.Json.Linq.JObject;

            foreach (var item in itens)
            {
                var command = new InsertAnswerCommand
                {
                    IdQuestion = item.Key.ToString(),
                    IdAnswer = item.Value.ToString()
                };

                serviceAnswer.InsertAnswer(command);
            }
        }

    }
}