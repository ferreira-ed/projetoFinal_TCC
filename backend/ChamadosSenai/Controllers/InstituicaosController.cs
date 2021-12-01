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

    public class InstituicaosController : Controller
    {
        private IInstituicaoRepository _InstituicaoRepository { get; set; }

        public InstituicaosController()
        {
            _InstituicaoRepository = new InstituicaoRepository();
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_InstituicaoRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("idInstituicao")]
        public IActionResult BuscarPorId(int idInstituicao)
        {
            try
            {
                return Ok(_InstituicaoRepository.BuscarPorId(idInstituicao));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Instituicao InstituicaoCadastrado)
        {
            try
            {
                _InstituicaoRepository.Cadastrar(InstituicaoCadastrado);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPut("{idInstituicao}")]
        public IActionResult Atualizar(int idInstituicao, Instituicao InstituicaoAtualizado)
        {
            try
            {
                _InstituicaoRepository.Atualizar(idInstituicao, InstituicaoAtualizado);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpDelete("{idInstituicao}")]
        public IActionResult Deletar(int idInstituicao)
        {
            try
            {
                _InstituicaoRepository.Deletar(idInstituicao);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }


    }
}
