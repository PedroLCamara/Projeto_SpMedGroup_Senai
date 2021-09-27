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
            return Ctx.Clinicas.Select(C => new Clinica()
            {
                IdClinica = C.IdClinica,
                HorarioDeAbertura = C.HorarioDeAbertura,
                HorarioDeFechamento = C.HorarioDeFechamento,
                Endereco = C.Endereco,
                RazaoSocial = C.RazaoSocial,
                NomeFantasia = C.NomeFantasia,
                Cnpj = C.Cnpj,
                Medicos = ListaMedicos.FindAll(M => M.IdClinica == C.IdClinica),
            }).FirstOrDefault(C => C.IdClinica == IdClinica);
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
            return Ctx.Clinicas.Select(C => new Clinica() { 
                IdClinica = C.IdClinica,
                HorarioDeAbertura = C.HorarioDeAbertura,
                HorarioDeFechamento = C.HorarioDeFechamento,
                Endereco = C.Endereco,
                RazaoSocial = C.RazaoSocial,
                NomeFantasia = C.NomeFantasia,
                Cnpj = C.Cnpj,
                Medicos = ListaMedicos.FindAll(M => M.IdClinica == C.IdClinica),    
            }).ToList();
        }
    }
}
