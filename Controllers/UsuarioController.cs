using System;
using Cadastro.DTO;
using Cadastro.Entity;
using Cadastro.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Cadastro.Controllers
{
    [ApiController]
    [Route("Usuario")]
    public class UsuarioController : ControllerBase
    {
        public IUsuarioRepository _usuarioRepository;
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(IUsuarioRepository usuarioRepository, ILogger<UsuarioController> logger)
        {
            _usuarioRepository = usuarioRepository;
            _logger = logger;
        }

        [HttpGet("obter-todos-com-pedidos/{id}")]
        public IActionResult ObterTodosComPedido(int id)
        {
            return Ok(_usuarioRepository.ObterComPedidos(id));
        }

        [HttpGet("obter-todos-usuarios")]
        public IActionResult ObterTodosUsuario()
        {
            try
            {
                throw new Exception("DEU ERRO!");
                return Ok(_usuarioRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{DateTime.Now:yyyy-MM-dd} | Exception forçada: {ex.Message}");
                return BadRequest();
            }
        }

        [HttpGet("obter-usuario-por-id/{id}")]
        public IActionResult ObterUsuarioId(int id)
        {
            _logger.LogInformation("Executando método ObterPorId");
            return Ok(_usuarioRepository.ObterPorId(id));
        }

        [HttpPost]
        public IActionResult CadastrarUsuario(CadastrarUsuarioDTO usuarioDTO)
        {
            _usuarioRepository.Cadastrar(new Usuario(usuarioDTO));
            var mensagem = $"Usuário cadastrado com sucesso! | Nome: {usuarioDTO.Nome}";
            _logger.LogWarning(mensagem);
            return Ok(mensagem);
        }

        [HttpPut]
        public IActionResult AlterarUsuario(AlterarUsuarioDTO usuarioDTO)
        {
            _usuarioRepository.Alterar(new Usuario(usuarioDTO));
            return Ok("Usuário alterado com sucesso");
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarUsuario(int id)
        {
            _usuarioRepository.Deletar(id);
            return Ok("Usuário deletado com sucesso");
        }
    }
}

