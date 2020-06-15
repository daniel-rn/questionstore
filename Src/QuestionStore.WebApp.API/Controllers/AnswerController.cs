using Microsoft.AspNetCore.Mvc;
using QuestionStore.Core.Commands;
using QuestionStore.Core.Service;

namespace QuestionStore.WebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : MainController
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
            return CustomResponse(serviceAnswer.GetAllAnswers());
        }

        // POST api/answer
        [HttpPost]
        public ActionResult Post([FromBody] dynamic value)
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

            return CustomResponse();
        }

    }
}