using Microsoft.AspNetCore.Mvc;
using QuestionStore.Core.Commands;
using QuestionStore.Core.Service;
using QuestionStore.Domain.Domain;
using QuestionStore.WebApp.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuestionStore.WebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipanteController : MainController
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
            return CustomResponse(participantes);
        }

        // POST api/participante
        [HttpPost]
        public ActionResult<string> Post([FromBody] ParticipanteModel model)
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
                return CustomResponse(model);
            }

            return CustomResponse(insertCommand);
        }
    }

}