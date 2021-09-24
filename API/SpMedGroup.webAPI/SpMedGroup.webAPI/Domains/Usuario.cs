using System;
using System.Collections.Generic;

#nullable disable

namespace SpMedGroup.webAPI.Domains
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public byte IdTipoUsuario { get; set; }
        public DateTime? DataDeNascimento { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual Medico Medico { get; set; }
        public virtual Paciente Paciente { get; set; }
    }
}
