using APITarefas.Data.Interfaces;
using APITarefas.Models.Entidades;
using APITarefas.Models.InputModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APITarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VendasController : ControllerBase
    {
        private readonly IVendas _vendas;

        public VendasController(IVendas vendaRepository)
        {
            _vendas = vendaRepository;
        }

        // GET: api/Agenda
        [HttpGet]
        public IActionResult Get()
        {
            var vendas = _vendas.Buscar();
            return Ok(vendas);
        }

        // GET api/vendas{id}
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var vendas = _vendas.BuscarID(id);

            if (vendas == null)
                return NotFound();

            return Ok(vendas);
        }

        // POST api/vendas
        [HttpPost]
        public IActionResult Post([FromBody] Vendas novaVendas)
        {
            var vendas = new Vendas(novaVendas.Nome, novaVendas.Procedimento, novaVendas.Detalhes, novaVendas.DataCadastro,novaVendas.Valor);
            _vendas.Adicionar(vendas);
            return Created("", vendas);
        }

        // PUT api/vendas{id}
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] VendasInput vendasAtualiza)
        {
            var vendasExistente = _vendas.BuscarID(id);

            if (vendasExistente == null)
                return NotFound();

            vendasExistente.AtualizarVenda(vendasAtualiza.Nome, vendasAtualiza.Detalhes, vendasAtualiza.Procedimento,vendasAtualiza.Valor ,vendasAtualiza.Concluido);

            _vendas.Atualizar(id, vendasExistente);

            return Ok(vendasExistente);
        }

        // DELETE api/vendas{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var agenda = _vendas.BuscarID(id);

            if (agenda == null)
                return NotFound();

            _vendas.Remover(id);

            return NoContent();
        }
    }
}