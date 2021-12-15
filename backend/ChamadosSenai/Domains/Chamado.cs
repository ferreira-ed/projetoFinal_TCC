using System;
using System.Collections.Generic;

#nullable disable

namespace ChamadosSenai.Domains
{
    public partial class Chamado
    {
        public int IdChamado { get; set; }
        public Guid? IdUsuario { get; set; }
        public int? IdInstituicao { get; set; }
        public DateTime? Data { get; set; }
        public string TipoProblema { get; set; }
        public string TipoServico { get; set; }
        public string Classe { get; set; }
        public string Andar { get; set; }
        public string Sala { get; set; }
        public string Descricao { get; set; }
        public string Situacao { get; set; }
        public string Prioridade { get; set; }

        public virtual Instituicao IdInstituicaoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
