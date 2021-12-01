using ChamadosSenai.Contexts;
using ChamadosSenai.Domains;
using ChamadosSenai.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChamadosSenai.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        ChamadoContext ctx = new ChamadoContext();

        public void Atualizar(int idTipoUsuario, TipoUsuario TipoUsuarioAtualizado)
        {
            TipoUsuario TipoUsuarioBuscado = BuscarPorId(idTipoUsuario);


            if (TipoUsuarioAtualizado.NomeTipoUsuario != null)
            {
               TipoUsuarioBuscado.NomeTipoUsuario = TipoUsuarioAtualizado.NomeTipoUsuario;
            }

            ctx.TipoUsuarios.Update(TipoUsuarioBuscado);
            ctx.SaveChanges();

        }

        public TipoUsuario BuscarPorId(int idTipoUsuario)
        {
            return ctx.TipoUsuarios.Find(idTipoUsuario);
        }

        public void Cadastrar(TipoUsuario novoTipoUsuario)
        {
            ctx.TipoUsuarios.Add(novoTipoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int idTipoUsuario)
        {
            ctx.TipoUsuarios.Remove(BuscarPorId(idTipoUsuario));

            ctx.SaveChanges();
        }

        public List<TipoUsuario> ListarTodos()
        {
            return ctx.TipoUsuarios.ToList();
        }
    }
}
