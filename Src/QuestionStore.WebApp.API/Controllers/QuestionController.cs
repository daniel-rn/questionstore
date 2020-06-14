using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuestionStore.Core.Commands;
using QuestionStore.Core.Processos;
using QuestionStore.Core.Service;
using QuestionStore.WebApp.API.Models;
using System.Threading.Tasks;

namespace QuestionStore.WebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            var servico = new ServicoCadastroQuestao();
            var questao = servico.Obtenha();

            return Ok(questao);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] QuestionModel model)
        {
            var insertCommand = new InsertQuestionCommand() { Descricao = model.Descricao };
            var servico = new ServicoCadastroQuestao();

            if (insertCommand.EhValido())
            {
                await servico.Insert(insertCommand);
                return Ok();
            }

            return BadRequest(new Error(insertCommand));
        }
    }
}