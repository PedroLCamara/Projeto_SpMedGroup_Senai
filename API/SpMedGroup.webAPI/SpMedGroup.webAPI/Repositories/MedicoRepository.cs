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
    /// Repositório para a definição da usabilidade dos métodos da entidade de Medico
    /// </summary>
    public class MedicoRepository : IMedicoRepository
    {
        /// <summary>
        /// Objeto do tipo contexto para as interações com o BD
        /// </summary>
        private SpMedGroupContext Ctx { get; set; }

        public void Atualizar(Medico MedicoAtualizado, int IdMedicoAtualizado)
        {
            Medico MedicoBuscado = BuscarPorId(IdMedicoAtualizado);
            int IdUsuario = MedicoBuscado.IdUsuario;

            if (MedicoBuscado != null)
            {
                MedicoBuscado = new Medico()
                {
                    Nome = MedicoAtualizado.Nome,
                    Crm = MedicoAtualizado.Crm,
                    IdEspecialidade = MedicoAtualizado.IdEspecialidade,
                    IdClinica = MedicoAtualizado.IdClinica,
                    IdMedico = Convert.ToInt16(IdMedicoAtualizado),
                    IdUsuario = IdUsuario
                };

                Ctx.Medicos.Update(MedicoBuscado);
                Ctx.SaveChanges();
            }
        }

        public Medico BuscarPorId(int IdMedico)
        {
            return Ctx.Medicos.Include(M => M.IdUsuarioNavigation).FirstOrDefault(M => M.IdMedico == IdMedico);
        }

        public void Cadastrar(Medico NovoMedico)
        {
            Ctx.Add(NovoMedico);
            Ctx.SaveChanges();
        }

        public void Deletar(int IdMedicoDeletado)
        {
            Ctx.Remove(BuscarPorId(IdMedicoDeletado));
            Ctx.SaveChanges();
        }

        public List<Medico> ListarTodos()
        {
            return Ctx.Medicos.Select(M => new Medico() { 
                IdMedico = M.IdMedico,
                IdUsuario = M.IdUsuario,
                IdClinica = M.IdClinica,
                IdEspecialidade = M.IdEspecialidade,
                Crm = M.Crm,
                Nome = M.Nome
            }).ToList();
        }
    }
}
