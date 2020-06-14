using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuestionStore.Core.Commands;
using QuestionStore.Core.Service;
using QuestionStore.Domain.Domain;
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
        public async Task<ActionResult<List<Participante>>> Get()
        {
            var participantes = await serviceParticipante.Consulte();
            return Ok(participantes);
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

            return BadRequest(new Error(insertCommand));
        }
    }

    public class Error
    {
        //pensar em algo melhor 
        private readonly Command _command;

        public Error(Command command)
        {
            this._command = command;
            Erros = command.ValidationResult.Errors.Select(c => c.ErrorMessage).ToList();
        }

        public List<string> Erros { get; }
    }

}