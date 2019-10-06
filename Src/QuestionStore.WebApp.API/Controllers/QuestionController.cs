using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuestionStore.Core.Processos;

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
    }
}