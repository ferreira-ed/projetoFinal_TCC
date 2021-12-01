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

    public class EquipamentosController : ControllerBase
    {
        private IEquipamentoRepositroy _EquipamentoRepository { get; set; }
        public EquipamentosController()
        {
            _EquipamentoRepository = new EquipamentoRepository();
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_EquipamentoRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("idEquipamento")]
        public IActionResult BuscarPorId(int idEquipamento)
        {
            try
            {
                return Ok(_EquipamentoRepository.BuscarPorId(idEquipamento));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Equipamento EquipamentoCadastrado)
        {
            try
            {
                _EquipamentoRepository.Cadastrar(EquipamentoCadastrado);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPut("{idEquipamento}")]
        public IActionResult Atualizar(int idEquipamento, Equipamento EquipamentoAtualizado)
        {
            try
            {
                _EquipamentoRepository.Atualizar(idEquipamento, EquipamentoAtualizado);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpDelete("{idEquipamento}")]
        public IActionResult Deletar(int idEquipamento)
        {
            try
            {
                _EquipamentoRepository.Deletar(idEquipamento);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }






    }
}
