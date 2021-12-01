using ChamadosSenai.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChamadosSenai.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuario> ListarTodos();

        Usuario BuscarPorId(int idUsuario);

        void Cadastrar(Usuario novoUsuario);

        void Atualizar(int idUsuario, Usuario UsuarioAtualizado);

        void Deletar(int idUsuario);

        Usuario Login(string email, string senha);
    }
}
