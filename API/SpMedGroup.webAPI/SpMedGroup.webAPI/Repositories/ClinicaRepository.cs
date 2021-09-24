using Microsoft.EntityFrameworkCore;
using SpMedGroup.webAPI.Contexts;
using SpMedGroup.webAPI.Domains;
using SpMedGroup.webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedGroup.webAPI.Repositories
{
    /// <summary>
    /// Repositório para a definição da usabilidade dos métodos da entidade de Clinica
    /// </summary>
    public class ClinicaRepository : IClinicaRepository
    {
        /// <summary>
        /// Objeto do tipo contexto para as interações com o BD
        /// </summary>
        private SpMedGroupContext Ctx { get; set; }

        public void Atualizar(Clinica ClinicaAtualizada, int IdClinicaAtualizada)
        {
            Clinica ClinicaBuscada = BuscarPorId(IdClinicaAtualizada);

            if (ClinicaBuscada != null)
            {
                ClinicaBuscada = new()
                {
                    HorarioDeAbertura = ClinicaAtualizada.HorarioDeAbertura,
                    HorarioDeFechamento = ClinicaAtualizada.HorarioDeFechamento,
                    Endereco = ClinicaAtualizada.Endereco,
                    RazaoSocial = ClinicaAtualizada.RazaoSocial,
                    NomeFantasia = ClinicaAtualizada.NomeFantasia,
                    Cnpj = ClinicaAtualizada.Cnpj,
                    IdClinica = Convert.ToInt16(IdClinicaAtualizada)
                };

                Ctx.Update(ClinicaBuscada);
                Ctx.SaveChanges();
            }
        }

        public Clinica BuscarPorId(int IdClinica)
        {
            return Ctx.Clinicas.Include(C => C.Medicos).FirstOrDefault(C => C.IdClinica == IdClinica);
        }

        public void Cadastrar(Clinica NovaClinica)
        {
            Ctx.Clinicas.Add(NovaClinica);
            Ctx.SaveChanges();
        }

        public void Deletar(int IdClinicaDeletada)
        {
            Ctx.Remove(BuscarPorId(IdClinicaDeletada));
            Ctx.SaveChanges();
        }

        public List<Clinica> ListarTodas()
        {
            return Ctx.Clinicas.Include(C => C.Medicos).ToList();
        }
    }
}
