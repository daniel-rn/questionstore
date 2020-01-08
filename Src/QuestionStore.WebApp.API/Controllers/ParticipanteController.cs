using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuestionStore.Core.Service;
using QuestionStore.WebApp.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionStore.WebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipanteController : ControllerBase
    {
        private readonly IServiceParticipante serviceParticipante;

        public ParticipanteController(IServiceParticipante serviceParticipante)
        {
            this.serviceParticipante = serviceParticipante;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            var participantes = Task.Run(async () =>
            {
                return await serviceParticipante.Consulte();
            }).Result;

            return JsonConvert.SerializeObject(participantes);
        }

        // POST api/participante
        [HttpPost]
        public ActionResult<string> Post([FromBody] CadastroParticipanteModel model)
        {
            var insertCommand = new InsertParticipanteCommand()
            {
                Nome = model.Nome,
                Idade = model.Idade,
                Cpf = model.CPF
            };

            if (insertCommand.EhValido())
            {
                serviceParticipante.Insert(insertCommand);
                return Ok();
            }

            return JsonConvert.SerializeObject(new Error(insertCommand));
        }
    }

    public class Error
    {
        //pensar em algo melhor 
        private readonly Command command;

        public Error(Command command)
        {
            this.command = command;
            Erros = command.ValidationResult.Errors.Select(c => c.ErrorMessage).ToList();
        }

        public List<string> Erros { get; }
    }

}