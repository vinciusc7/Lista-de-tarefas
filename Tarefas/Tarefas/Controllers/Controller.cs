using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tarefas.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Controller : ControllerBase
    {
        [HttpGet]
        public IActionResult ConnectStatus()
        {
            return Ok("Api conectada com sucesso");
        }
    }
}
