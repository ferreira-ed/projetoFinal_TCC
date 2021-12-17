using ChamadosSenai.Contexts;
using ChamadosSenai.Domains;
using ChamadosSenai.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChamadosSenai.Repositories
{
    public class ChamadoRepository : IChamadoRepository
    {
        ChamadoContext ctx = new ChamadoContext();
        public void Atualizar(int idChamado, Chamado ChamadoAtualizado)
        {
            Chamado ChamadoBuscado = BuscarPorId(idChamado);


            if (ChamadoAtualizado.Situacao != null)
            {
                ChamadoBuscado.Situacao = ChamadoAtualizado.Situacao;
            }

            if (ChamadoAtualizado.Prioridade != null)
            {
                ChamadoBuscado.Prioridade = ChamadoAtualizado.Prioridade;
            }

            if (ChamadoAtualizado.Descricao != null)
            {
                ChamadoBuscado.Descricao = ChamadoAtualizado.Descricao;
            }

        }

        public Chamado BuscarPorId(int idChamado)
        {
            return ctx.Chamados.Find(idChamado);
        }

        public void Cadastrar(Chamado novoChamado)
        {
            ctx.Chamados.Add(novoChamado);

            ctx.SaveChanges();
        }

        public void Deletar(int idChamado)
        {
            ctx.Chamados.Remove(BuscarPorId(idChamado));
            ctx.SaveChanges();
        }

        public List<Chamado> ListarTodos()
        {
            return ctx.Chamados
                .Select(u => new Chamado()
                {
                    IdChamado = u.IdChamado,
                    NomeUsuario = u.NomeUsuario,
                    Data = u.Data,
                    TipoProblema = u.TipoProblema,
                    TipoServico = u.TipoServico,
                    Classe = u.Classe,
                    Andar = u.Andar,
                    Sala = u.Sala,
                    Prioridade = u.Prioridade,
                    Descricao = u.Descricao

                })
                .ToList();
        }
    }
}
