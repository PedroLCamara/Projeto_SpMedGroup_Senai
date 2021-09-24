using System;
using System.Collections.Generic;

#nullable disable

namespace SpMedGroup.webAPI.Domains
{
    public partial class Clinica
    {
        public Clinica()
        {
            Medicos = new HashSet<Medico>();
        }

        public short IdClinica { get; set; }
        public TimeSpan? HorarioDeAbertura { get; set; }
        public TimeSpan? HorarioDeFechamento { get; set; }
        public string Endereco { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
