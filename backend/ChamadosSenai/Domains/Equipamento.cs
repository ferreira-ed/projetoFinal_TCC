using System;
using System.Collections.Generic;

#nullable disable

namespace ChamadosSenai.Domains
{
    public partial class Equipamento
    {
        public int IdEquipamento { get; set; }
        public int? IdInstituicao { get; set; }
        public string Marca { get; set; }
        public string TipoEquipamento { get; set; }
        public string NumeroPatrimonio { get; set; }
        public string Quantidade { get; set; }

        public virtual Instituicao IdInstituicaoNavigation { get; set; }
    }
}
