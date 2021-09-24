using System;
using System.Collections.Generic;

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
        public string Nome { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
