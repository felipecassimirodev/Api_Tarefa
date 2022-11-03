using APITarefas.Data.Service;
using APITarefas.Models;
using APITarefas.Models.InputModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APITarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChamadosController : ControllerBase
    {
        private readonly ChamadosService _chamadosService;

        public ChamadosController(ChamadosService chamadosService)
        {
            _chamadosService = chamadosService;
        }

        [HttpGet]
        public async Task<List<Chamado>> GetChamados()
            => await _chamadosService.Get();

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var chamado = await _chamadosService.Get(id);
            if (chamado == null)
            {
                return NotFound();
            }

            return Ok(chamado);
        }
        [HttpPost]
        public async Task<Chamado> CreateChamado(Chamado novoChamado)
        {
            var chamado = new Chamado(novoChamado.Titulo, novoChamado.Descricao, novoChamado.Status!);
            await _chamadosService.Create(chamado);

            return chamado;
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Chamado atualizaChamado)
        {
            var chamado = await _chamadosService.Get(id);

            if (chamado is null)
            {
                return NotFound();
            }

            atualizaChamado.Id = chamado.Id;

            await _chamadosService.Update(id, atualizaChamado);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var chamado = await _chamadosService.Get(id);

            if (chamado is null)
            {
                return NotFound();
            }

            await _chamadosService.remove(id);

            return NoContent();
        }
    }
}
