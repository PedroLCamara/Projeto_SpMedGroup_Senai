using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SpMedGroup.webAPI.Domains
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "Email necessário")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Senha necessário")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "Id do tipo de usuário necessário")]
        public byte IdTipoUsuario { get; set; }
        public DateTime? DataDeNascimento { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual Medico Medico { get; set; }
        public virtual Paciente Paciente { get; set; }
    }
}
