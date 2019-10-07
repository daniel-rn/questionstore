using Microsoft.AspNetCore.Mvc;
using QuestionStore.Core.Service;
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
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
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