using ChamadosSenai.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChamadosSenai.Interfaces
{
    interface IEquipamentoRepositroy
    {
        List<Equipamento> ListarTodos();

        Equipamento BuscarPorId(int idEquipamento);


        void Cadastrar(Equipamento novoEquipamento);


        void Atualizar(int idEquipamento, Equipamento EquipamentoAtualizado);


        void Deletar(int idEquipamento);

    }
}
