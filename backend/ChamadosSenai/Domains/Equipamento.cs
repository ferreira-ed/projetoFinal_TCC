using System;
using System.Collections.Generic;

#nullable disable

namespace ChamadosSenai.Domains
{
    public partial class Equipamento
    {
        public int IdEquipamento { get; set; }
        public int? IdInstituicao { get; set; }
        public string NomeEquipamento { get; set; }
        public string Descricao { get; set; }

        public virtual Instituicao IdInstituicaoNavigation { get; set; }
    }
}
