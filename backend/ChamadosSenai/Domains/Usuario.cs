using System;
using System.Collections.Generic;

#nullable disable

namespace ChamadosSenai.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Chamados = new HashSet<Chamado>();
        }

        public int? IdTipoUsuario { get; set; }
        public Guid IdUsuario { get; set; }
        public string EmailUsuario { get; set; }
        public string SenhaUsuario { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Chamado> Chamados { get; set; }
    }
}
