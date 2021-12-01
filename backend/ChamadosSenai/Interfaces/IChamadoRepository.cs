using ChamadosSenai.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChamadosSenai.Interfaces
{
    interface IChamadoRepository
    {
        List<Chamado> ListarTodos();

        Chamado BuscarPorId(int idChamado);

        void Cadastrar(Chamado novoChamado);

        void Atualizar(int idChamado, Chamado ChamadoAtualizado);

        void Deletar(int Chamado);
    }
}
