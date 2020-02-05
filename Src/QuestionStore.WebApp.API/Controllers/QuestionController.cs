using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

            return JsonConvert.SerializeObject(questao);
        }

        [HttpPost]
        public async Task<ActionResult<string>> PostAsync([FromBody] QuestionModel model)
        {
            var insertCommand = new InsertQuestionCommand() { Descricao = model.Descricao };

            var servico = new ServicoCadastroQuestao();

            await servico.Insert(insertCommand);

            return JsonConvert.SerializeObject(new Error(insertCommand));
        }
    }
}