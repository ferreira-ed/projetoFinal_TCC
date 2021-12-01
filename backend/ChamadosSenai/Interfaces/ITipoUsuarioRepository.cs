using ChamadosSenai.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChamadosSenai.Interfaces
{
    interface ITipoUsuarioRepository
    {
        List<TipoUsuario> ListarTodos();


        TipoUsuario BuscarPorId(int idTipoUsuario);


        void Cadastrar(TipoUsuario novoTipoUsuario);


        void Atualizar(int idTipoUsuario, TipoUsuario TipoUsuarioAtualizado);


        void Deletar(int idTipoUsuario);


    }
}
