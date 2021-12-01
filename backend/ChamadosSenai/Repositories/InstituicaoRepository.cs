using ChamadosSenai.Contexts;
using ChamadosSenai.Domains;
using ChamadosSenai.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChamadosSenai.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        ChamadoContext ctx = new ChamadoContext();

        public void Atualizar(int idInstituicao, Instituicao InstituicaoAtualizado)
        

        {
            Instituicao InstituicaoBuscado = BuscarPorId(idInstituicao);

            if (InstituicaoAtualizado.IdInstituicao > 0)
            {
                InstituicaoBuscado.IdInstituicao = InstituicaoAtualizado.IdInstituicao;
            }

            if (InstituicaoAtualizado.NomeInstituicao != null)
            {
                InstituicaoBuscado.NomeInstituicao = InstituicaoAtualizado.NomeInstituicao;
            }

            if (InstituicaoAtualizado.Cnpj != null)
            {
                InstituicaoBuscado.Cnpj = InstituicaoAtualizado.Cnpj;
            }

            if (InstituicaoAtualizado.Cep != null)
            {
                InstituicaoBuscado.Cep = InstituicaoAtualizado.Cep;
            }

            if (InstituicaoAtualizado.Pais != null)
            {
                InstituicaoBuscado.Pais = InstituicaoAtualizado.Pais;
            }

            if (InstituicaoAtualizado.Estado != null)
            {
                InstituicaoBuscado.Estado = InstituicaoAtualizado.Estado;
            }

            if (InstituicaoAtualizado.Cidade != null)
            {
                InstituicaoBuscado.Cidade = InstituicaoAtualizado.Cidade;
            }

            if (InstituicaoAtualizado.Bairro != null)
            {
                InstituicaoBuscado.Bairro = InstituicaoAtualizado.Bairro;
            }

            if (InstituicaoAtualizado.Numero != null)
            {
                InstituicaoBuscado.Numero = InstituicaoAtualizado.Numero;
            }

            if (InstituicaoAtualizado.Endereco != null)
            {
                InstituicaoBuscado.Endereco = InstituicaoAtualizado.Endereco;
            }

            if (InstituicaoAtualizado.Telefone != null)
            {
                InstituicaoBuscado.Telefone = InstituicaoAtualizado.Telefone;
            }


            ctx.Instituicaos.Update(InstituicaoBuscado);
            ctx.SaveChanges();

        }

        public Instituicao BuscarPorId(int idInstituicao)
        {
            return ctx.Instituicaos.Find(idInstituicao);
        }

        public void Cadastrar(Instituicao novaInstituicao)
        {
            ctx.Instituicaos.Add(novaInstituicao);

            ctx.SaveChanges();
        }

        public void Deletar(int idInstituicao)
        {
            ctx.Instituicaos.Remove(BuscarPorId(idInstituicao));
            ctx.SaveChanges();
        }

        public List<Instituicao> ListarTodos()
        {
            return ctx.Instituicaos.ToList();
        }
    }
}
