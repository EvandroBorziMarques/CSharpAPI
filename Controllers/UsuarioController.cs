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

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet("obter-todos-com-pedidos/{id}")]
        public IActionResult ObterTodosComPedido(int id)
        {
            return Ok(_usuarioRepository.ObterComPedidos(id));
        }

        [HttpGet("obter-todos-usuarios")]
        public IActionResult ObterTodosUsuario()
        {
            return Ok(_usuarioRepository.ObterTodos());
        }

        [HttpGet("obter-usuario-por-id/{id}")]
        public IActionResult ObterUsuarioId(int id)
        {
            return Ok(_usuarioRepository.ObterPorId(id));
        }

        [HttpPost]
        public IActionResult CadastrarUsuario(CadastrarUsuarioDTO usuarioDTO)
        {
            _usuarioRepository.Cadastrar(new Usuario(usuarioDTO));
            return Ok("Usuário cadastrado com sucesso");
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

