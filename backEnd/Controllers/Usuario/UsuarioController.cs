using APITarefas.Models.InputModels;
using Microsoft.AspNetCore.Mvc;
using APITarefas.Models.Entidades;
using APITarefas.Data.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace APITarefas.Controllers.Usuario
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // GET: api/Usuarios
        [HttpGet]
        public IActionResult Get()
        {
            var usuario = _usuarioRepository.Buscar();
            return Ok(usuario);
        }

        // GET api/Usuario{id}
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var usuario = _usuarioRepository.BuscarID(id);

            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }
        // POST api/Usuario/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginInput loginInput)
        {
            var usuario = _usuarioRepository.BuscarPorUsuarioSenha(loginInput.Username, loginInput.Password);

            if (usuario == null)
                return Unauthorized();

            // Aqui você pode retornar dados adicionais do usuário se necessário
            return Ok(new { Nome = usuario.Nome, Email = usuario.Email });
        }

        // POST api/Usuarios
        [HttpPost]
        public IActionResult Post([FromBody] UsuarioInput novoUsuario)
        {
            try
            {
                if (novoUsuario != null)
                {
                    var user = new User
                    {
                        Nome = novoUsuario.Nome,
                        Usuario = novoUsuario.Usuario,
                        Senha = novoUsuario.UsuSenha,
                        Email = novoUsuario.Email,
                        Telefone = novoUsuario.Telefone
                    };

                    _usuarioRepository.Adicionar(user);
                    return Created("", user);
                }
                else
                {
                    return BadRequest("Favor inserir os dados do Usuario.");
                }        
            }
            catch (Exception)
            {
                throw;
            }
        }

        // PUT api/Usuarios{id}
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] UsuarioInput novoUsuario)
        {
            try
            {
                var usuarioExistente = _usuarioRepository.BuscarID(id);

                if (usuarioExistente == null)
                    return NotFound("usuario não encontrado.");

                var usuario = new User
                {
                    Nome = novoUsuario.Nome,
                    Usuario = novoUsuario.Usuario,
                    Senha = novoUsuario.UsuSenha,
                    Email = novoUsuario.Email,
                    Telefone = novoUsuario.Telefone
                };
                
                usuarioExistente.AtualizaUser(usuario);

                _usuarioRepository.Atualizar(id, usuarioExistente);

                return Ok(usuarioExistente);
            }
            catch (Exception e)
            {

                throw;
            }        
        }

        // DELETE api/Usuario{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var usuario = _usuarioRepository.BuscarID(id);

            if (usuario == null)
                return NotFound();

            _usuarioRepository.Remover(id);

            return NoContent();
        }
    }
}
