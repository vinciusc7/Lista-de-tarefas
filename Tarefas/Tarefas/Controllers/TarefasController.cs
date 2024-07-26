using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Tarefas.Models;
using Tarefas.Services;

namespace Tarefas.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefasService _service;

        public TarefasController(ITarefasService service)
        {
            _service = service;
        }
        [HttpGet("GetTarefas")]
        public IActionResult GetTarefas()
        {
            var tarefas = _service.GetTarefas();
            return Ok(tarefas);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetTarefasById(int id)
        {
            if (id != null)
            {
                var tarefa = _service.GetTarefasById(id);
                if (tarefa == null)
                {
                    return NotFound( new { message = "Nenhuma tarefa encontrada" });
                }
                return Ok( new { message = tarefa });

            }
            return BadRequest(new { message =  "Selecione uma tarefa" });
        }
        [HttpPost("CriarTarefa")]
        public IActionResult CriarTarefas(TarefasModel tarefa)
        {
            if (tarefa is null)
            {
                return BadRequest(new { message = "Nenhuma tarefa para adicionar"});
            }
            else
            {
                _service.CriarTarefas(tarefa);
            }
            return Ok(new { message = "tarefa criada com sucesso" });
        }
        [HttpPut("AtualizarTarefa")]
        public IActionResult Finalizartarefa(int id)
        {
            if (id != null)
            {
                _service.Finalizartarefa(id);
                return Ok( new { message = "Tarefa alterada"});
            }
            return BadRequest( new { message = "Selecione uma tarefa para finalizar"});
        }
        [HttpDelete("DeletarTarefa")]
        public IActionResult DeletarTarefas(int id)
        {
            if (id != null)
            {
                _service.DeletarTarefas(id);
                return Ok( new { message = "Tarefa deletada com sucesso"});
            }
            return BadRequest( new { message = "Selecione uma tarefa para deletar"});
        }
    }
}
