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

    public class ChamadosController : ControllerBase
    {
        private IChamadoRepository _ChamadoRepository { get; set; }

        public ChamadosController()
        {
            _ChamadoRepository = new ChamadoRepository();
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_ChamadoRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("idChamado")]
        public IActionResult BuscarPorId(int idChamado)
        {
            try
            {
                return Ok(_ChamadoRepository.BuscarPorId(idChamado));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Chamado ChamadoCadastrado)
        {
            try
            {
                _ChamadoRepository.Cadastrar(ChamadoCadastrado);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPut("{idChamado}")]
        public IActionResult Atualizar(int idChamado, Chamado ChamadoAtualizado)
        {
            try
            {
                _ChamadoRepository.Atualizar(idChamado, ChamadoAtualizado);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpDelete("{idChamado}")]
        public IActionResult Deletar(int idChamado)
        {
            try
            {
                _ChamadoRepository.Deletar(idChamado);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }



    }
}
