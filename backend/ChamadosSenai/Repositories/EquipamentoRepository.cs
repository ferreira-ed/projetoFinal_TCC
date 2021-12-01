using ChamadosSenai.Contexts;
using ChamadosSenai.Domains;
using ChamadosSenai.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChamadosSenai.Repositories
{
    public class EquipamentoRepository : IEquipamentoRepositroy
    {
        ChamadoContext ctx = new ChamadoContext();
        public void Atualizar(int idEquipamento, Equipamento EquipamentoAtualizado)
        {
            Equipamento EquipamentoBuscado = BuscarPorId(idEquipamento);

            if (EquipamentoAtualizado.IdEquipamento > 0)
            {
                EquipamentoBuscado.IdEquipamento = EquipamentoAtualizado.IdEquipamento;
            }

            if (EquipamentoAtualizado.IdInstituicao > 0)
            {
                EquipamentoBuscado.IdInstituicao = EquipamentoAtualizado.IdInstituicao;
            }

            if (EquipamentoAtualizado.NomeEquipamento != null)
            {
                EquipamentoBuscado.NomeEquipamento = EquipamentoAtualizado.NomeEquipamento;
            }

            if (EquipamentoAtualizado.Descricao != null)
            {
                EquipamentoBuscado.Descricao = EquipamentoAtualizado.NomeEquipamento;
            }



            ctx.Equipamentos.Update(EquipamentoBuscado);
            ctx.SaveChanges();
        }

        public Equipamento BuscarPorId(int idEquipamento)
        {
            return ctx.Equipamentos.Find(idEquipamento);
        }

        public void Cadastrar(Equipamento novoEquipamento)
        {
            ctx.Equipamentos.Add(novoEquipamento);

            ctx.SaveChanges();
        }

        public void Deletar(int idEquipamento)
        {
            ctx.Equipamentos.Remove(BuscarPorId(idEquipamento));
            ctx.SaveChanges();
        }

        public List<Equipamento> ListarTodos()
        {
            return ctx.Equipamentos.ToList();
        }
    }
}
