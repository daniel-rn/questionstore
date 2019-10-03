using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuestionStore.Core.Service;
using QuestionStore.WebApp.API.Models;

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

        // GET api/answer/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/answer
        [HttpPost]
        [HttpGet]
        public void Post([FromBody] AnswerModel value)
        {
            var command = new CommandInsertAnswer();
            command.Descricao = value.Descricao;

            var svc = new ServiceAnswer();
            svc.InsertAnswer(command);
        }

        // PUT api/answer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/answer/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}