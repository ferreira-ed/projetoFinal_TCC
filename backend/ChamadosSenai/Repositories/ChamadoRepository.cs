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


            if (ChamadoAtualizado.IdUsuario != null)
            {
                ChamadoBuscado.IdUsuario = ChamadoAtualizado.IdUsuario;
            }

            if (ChamadoAtualizado.IdInstituicao > 0)
            {
                ChamadoBuscado.IdInstituicao = ChamadoAtualizado.IdInstituicao;
            }

            if (ChamadoAtualizado.IdReceberChamado != null)
            {
                ChamadoBuscado.IdReceberChamado = ChamadoAtualizado.IdReceberChamado;
            }

            if (ChamadoAtualizado.Localizacao != null)
            {
                ChamadoBuscado.Localizacao = ChamadoAtualizado.Localizacao;
            }

            if (ChamadoAtualizado.Motivo != null)
            {
                ChamadoBuscado.Motivo = ChamadoAtualizado.Motivo;
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
            return ctx.Chamados.ToList();
        }
    }
}
