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
    public class TramiteController : ControllerBase
    {
        private readonly ITramiteRepository _tramiteRepository;

        public TramiteController(ITramiteRepository tramiteRepository)
        {
            _tramiteRepository = tramiteRepository;
        }

        // GET: api/<TramiteController>
        [HttpGet]
        public IActionResult Get()
        {
            var tramite = _tramiteRepository.Buscar();
            return Ok(tramite);
        }
        
        // GET api/<TramiteController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var tramite = _tramiteRepository.BuscarID(id);

            if (tramite == null)
                return NotFound();

            return Ok(tramite);
        }

        // POST api/Tramite
        [HttpPost]
        public IActionResult Post([FromBody] TramiteInput novoTramite)
        {
            try
            {
                if (novoTramite != null)
                {
                    var tramite = new Tramite
                    {
                        SolID = novoTramite.SolID,
                        Descricao = novoTramite.Descricao,
                        UsuIDResponsavel = novoTramite.UsuIDResponsavel,
                    };

                    _tramiteRepository.Adicionar(tramite);
                    return Created("", tramite);
                }
                else
                {
                    return BadRequest("Favor inserir os dados validos do Tramite.");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT api/<TramiteController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Tramite novoTramite)
        {
            var tramiteExiteste = _tramiteRepository.BuscarID(id);

            if (tramiteExiteste == null)
                return NotFound();

            tramiteExiteste.AtualizaTramite(novoTramite);

            _tramiteRepository.Atualizar(id, tramiteExiteste);

            return Ok(tramiteExiteste);
        }

        // DELETE api/<TramiteController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var tramite = _tramiteRepository.BuscarID(id);

            if (tramite == null)
                return NotFound();

            _tramiteRepository.Remover(id);

            return NoContent();
        }
    }
}
