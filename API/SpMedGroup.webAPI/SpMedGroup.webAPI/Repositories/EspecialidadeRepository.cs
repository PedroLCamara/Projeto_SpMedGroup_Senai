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
    /// Repositório para a definição da usabilidade dos métodos da entidade de Especialidade
    /// </summary>
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        /// <summary>
        /// Objeto do tipo contexto para as interações com o BD
        /// </summary>
        private SpMedGroupContext Ctx { get; set; }

        public void Atualizar(Especialidade EspecialidadeAtualizada, int IdEspecialidadeAtualizada)
        {
            Especialidade EspecialidadeBuscada = BuscarPorId(IdEspecialidadeAtualizada);

            if (EspecialidadeBuscada != null)
            {
                EspecialidadeBuscada.Nome = EspecialidadeAtualizada.Nome;
                Ctx.Especialidades.Update(EspecialidadeBuscada);
                Ctx.SaveChanges();
            }
        }

        public Especialidade BuscarPorId(int IdEspecialidade)
        {
            List<Medico> ListaMedicos = Ctx.Medicos.Include(M => M.IdUsuarioNavigation).ToList();
            foreach (Medico item in ListaMedicos)
            {
                Usuario UsuarioLista = new Usuario()
                {
                    Nome = item.IdUsuarioNavigation.Nome,
                    Email = item.IdUsuarioNavigation.Email,
                    DataDeNascimento = item.IdUsuarioNavigation.DataDeNascimento,
                };

                item.IdUsuarioNavigation = UsuarioLista;
            }
            return Ctx.Especialidades.Select(E => new Especialidade()
            {
                IdEspecialidade = E.IdEspecialidade,
                Nome = E.Nome,
                Medicos = ListaMedicos.FindAll(M => M.IdEspecialidade == E.IdEspecialidade)
            }).FirstOrDefault(E => E.IdEspecialidade == IdEspecialidade);
        }

        public void Cadastrar(Especialidade NovaEspecialidade)
        {
            Ctx.Especialidades.Add(NovaEspecialidade);
            Ctx.SaveChanges();
        }

        public void Deletar(int IdEspecialidadeDeletada)
        {
            Ctx.Especialidades.Remove(BuscarPorId(IdEspecialidadeDeletada));
            Ctx.SaveChanges();
        }

        public List<Especialidade> ListarTodas()
        {
            List<Medico> ListaMedicos = Ctx.Medicos.Include(M => M.IdUsuarioNavigation).ToList();
            foreach (Medico item in ListaMedicos)
            {
                Usuario UsuarioLista = new Usuario()
                {
                    Nome = item.IdUsuarioNavigation.Nome,
                    Email = item.IdUsuarioNavigation.Email,
                    DataDeNascimento = item.IdUsuarioNavigation.DataDeNascimento,
                };

                item.IdUsuarioNavigation = UsuarioLista;
            }
            return Ctx.Especialidades.Select(E => new Especialidade() { 
                IdEspecialidade = E.IdEspecialidade,
                Nome = E.Nome,
                Medicos = ListaMedicos.FindAll(M => M.IdEspecialidade == E.IdEspecialidade)
            }).ToList();
        }
    }
}
