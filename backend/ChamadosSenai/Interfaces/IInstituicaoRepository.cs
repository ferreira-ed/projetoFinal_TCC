using ChamadosSenai.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChamadosSenai.Interfaces
{
    interface IInstituicaoRepository
    {
        List<Instituicao> ListarTodos();


        Instituicao BuscarPorId(int idInstituicao);


        void Cadastrar(Instituicao novoInstituicao);


        void Atualizar(int idInstituicao, Instituicao InstituicaoAtualizado);


        void Deletar(int idInstituicao);
    }
}
