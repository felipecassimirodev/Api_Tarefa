using APITarefas.Data.Repositories;
using APITarefas.Models.Entidades;
using APITarefas.Models.InputModels;
using Microsoft.AspNetCore.Mvc;


namespace APITarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefasRepository _tarefasRepository;

        public TarefasController(ITarefasRepository tarefasRepository)
        {
            _tarefasRepository = tarefasRepository;
        }

        // GET: api/Tarefas
        [HttpGet]
        public IActionResult Get()
        {
            var tarefas = _tarefasRepository.Buscar();
            return Ok(tarefas);
        }

        // GET api/Tarefa{id}
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var tarefa = _tarefasRepository.BuscarID(id);

            if (tarefa == null)
                return NotFound();

            return Ok(tarefa);      
        }

        // POST api/Tarefas
        [HttpPost]
        public IActionResult Post([FromBody] Tarefa novaTarefa)
        {
            var tarefa = new Tarefa(novaTarefa.Nome , novaTarefa.Titulo, novaTarefa.Detalhes );
            _tarefasRepository.Adicionar(tarefa);
            return Created("", tarefa);
        }

        // PUT api/Tarefas{id}
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] TarefaInputModel tarefaAtualizada)
        {
            var tarefaExistente = _tarefasRepository.BuscarID(id);

            if (tarefaExistente == null)
                return NotFound();

            tarefaExistente.AtualizarTarefa(tarefaAtualizada.Nome , tarefaAtualizada.Titulo,tarefaAtualizada.Detalhes);
            
            _tarefasRepository.Atualizar(id , tarefaExistente);

            return Ok(tarefaExistente);
        }

        // DELETE api/Tarefas{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var tarefa = _tarefasRepository.BuscarID(id);

            if (tarefa == null)
                return NotFound();

            _tarefasRepository.Remover(id);
            
            return NoContent();
        }
    }
}
