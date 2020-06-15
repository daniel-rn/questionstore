using Microsoft.AspNetCore.Mvc;
using QuestionStore.Core.Commands;

namespace QuestionStore.WebApp.API.Controllers
{
    public class MainController : ControllerBase
    {
        public ActionResult CustomResponse()
        {
            if (ModelState.IsValid)
            {
                return Ok();
            }

            return BadRequest();
        }

        public ActionResult CustomResponse(object obj = null)
        {
            if (obj is null)
            {
                return CustomResponse();
            }

            if (obj is Command cmd)
            {
                if (cmd.EhValido())
                {
                    return Ok(new Result(cmd));
                }
                else
                {
                    return BadRequest(new Result(cmd));
                }
            }

            return Ok(new Result(obj));
        }
    }

}