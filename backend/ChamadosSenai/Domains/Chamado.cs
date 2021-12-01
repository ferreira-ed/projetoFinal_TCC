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
        public Guid? IdReceberChamado { get; set; }
        public string Localizacao { get; set; }
        public string Motivo { get; set; }
        public string Descricao { get; set; }

        public virtual Instituicao IdInstituicaoNavigation { get; set; }
    }
}
