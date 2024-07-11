using APITarefas.Data.Interfaces;
using APITarefas.Data.Repositories;
using APITarefas.Models.Entidades;
using APITarefas.Models.InputModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APITarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AgendaController : ControllerBase
    {
        private readonly IAgenda _agenda;

        public AgendaController(IAgenda agendaRepository)
        {
            _agenda = agendaRepository;
        }

        // GET: api/Agenda
        [HttpGet]
        public IActionResult Get()
        {
            var agenda = _agenda.Buscar();
            return Ok(agenda);
        }

        // GET api/Agenda{id}
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var agenda = _agenda.BuscarID(id);

            if (agenda == null)
                return NotFound();

            return Ok(agenda);
        }

        // POST api/Agenda
        [HttpPost]
        public IActionResult Post([FromBody] Agenda novaAgenda)
        {
            var agenda = new Agenda(novaAgenda.Nome, novaAgenda.Procedimento, novaAgenda.Detalhes,novaAgenda.DataAgendamento);
            _agenda.Adicionar(agenda);
            return Created("", agenda);
        }

        // PUT api/Agenda{id}
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] AgendaInput agendaAtualiza)
        {
            var agendaExistente = _agenda.BuscarID(id);

            if (agendaExistente == null)
                return NotFound();

            agendaExistente.AtualizarAgenda(agendaAtualiza.Nome, agendaAtualiza.Detalhes,agendaAtualiza.Procedimento, agendaAtualiza.DataAgendamento, agendaAtualiza.Concluido);

            _agenda.Atualizar(id, agendaExistente);

            return Ok(agendaExistente);
        }

        // DELETE api/Agenda{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var agenda = _agenda.BuscarID(id);

            if (agenda == null)
                return NotFound();

            _agenda.Remover(id);

            return NoContent();
        }
    }
}
