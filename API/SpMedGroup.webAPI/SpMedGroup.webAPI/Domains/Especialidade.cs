﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SpMedGroup.webAPI.Domains
{
    public partial class Especialidade
    {
        public Especialidade()
        {
            Medicos = new HashSet<Medico>();
        }

        public byte IdEspecialidade { get; set; }
        [Required(ErrorMessage = "Nome necessário")]
        public string Nome { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}