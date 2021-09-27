﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SpMedGroup.webAPI.Domains
{
    public partial class Paciente
    {
        public Paciente()
        {
            Consulta = new HashSet<Consultum>();
        }

        public int IdPaciente { get; set; }
        [Required(ErrorMessage = "Id de usuário necessário")]
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "Nome necessário")]
        public string Nome { get; set; }
        public string Telefone { get; set; }
        [Required(ErrorMessage = "Cpf necessário")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Endereço necessário")]
        public string Endereco { get; set; }
        [Required(ErrorMessage = "Rg necessário")]
        public string Rg { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consultum> Consulta { get; set; }
    }
}