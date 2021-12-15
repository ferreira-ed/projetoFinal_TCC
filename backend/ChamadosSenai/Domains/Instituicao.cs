using System;
using System.Collections.Generic;

#nullable disable

namespace ChamadosSenai.Domains
{
    public partial class Instituicao
    {
        public Instituicao()
        {
            Chamados = new HashSet<Chamado>();
            Equipamentos = new HashSet<Equipamento>();
        }

        public int IdInstituicao { get; set; }
        public string NomeInstituicao { get; set; }
        public string Cnpj { get; set; }
        public string Cep { get; set; }
        public string Pais { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }

        public virtual ICollection<Chamado> Chamados { get; set; }
        public virtual ICollection<Equipamento> Equipamentos { get; set; }
    }
}
