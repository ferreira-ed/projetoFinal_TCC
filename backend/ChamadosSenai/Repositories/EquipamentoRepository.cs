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

            if (EquipamentoAtualizado.Marca != null)
            {
                EquipamentoBuscado.Marca = EquipamentoAtualizado.Marca;
            }

            if (EquipamentoAtualizado.TipoEquipamento != null)
            {
                EquipamentoBuscado.TipoEquipamento = EquipamentoAtualizado.TipoEquipamento;
            }

            if (EquipamentoAtualizado.NumeroPatrimonio != null)
            {
                EquipamentoBuscado.NumeroPatrimonio = EquipamentoAtualizado.NumeroPatrimonio;
            }

            if (EquipamentoAtualizado.Quantidade != null)
            {
                EquipamentoBuscado.Quantidade = EquipamentoAtualizado.Quantidade;
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
