using ChamadosSenai.Domains;
using ChamadosSenai.Interfaces;
using ChamadosSenai.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChamadosSenai.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_usuarioRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("idUsuario")]
        public IActionResult BuscarPorId(int idUsuario)
        {
            try
            {
                return Ok(_usuarioRepository.BuscarPorId(idUsuario));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuario usuarioCadastrado)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuarioCadastrado);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPut("{idUsuario}")]
        public IActionResult Atualizar(int idUsuario, Usuario usuarioAtualizado)
        {
            try
            {
                _usuarioRepository.Atualizar(idUsuario, usuarioAtualizado);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpDelete("{idUsuario}")]
        public IActionResult Deletar(int idUsuario)
        {
            try
            {
                _usuarioRepository.Deletar(idUsuario);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }

    }
}
