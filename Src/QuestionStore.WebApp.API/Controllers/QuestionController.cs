using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuestionStore.Core.Commands;
using QuestionStore.Core.Processos;
using QuestionStore.WebApp.API.Models;
using System.Threading.Tasks;

namespace QuestionStore.WebApp.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : MainController
    {
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<string> Get()
        {
            var servico = new ServicoCadastroQuestao();
            var questao = servico.Obtenha();

            return CustomResponse(questao);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] QuestionModel model)
        {
            var insertCommand = new InsertQuestionCommand() { Descricao = model.Descricao };
            var servico = new ServicoCadastroQuestao();

            if (insertCommand.EhValido())
            {
                await servico.Insert(insertCommand);
                return CustomResponse(model);
            }

            return CustomResponse(insertCommand);
        }
    }
}