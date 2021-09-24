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
    /// Repositório para a definição da usabilidade dos métodos da entidade de Paciente
    /// </summary>
    public class PacienteRepository : IPacienteRepository
    {
        /// <summary>
        /// Objeto do tipo contexto para as interações com o BD
        /// </summary>
        private SpMedGroupContext Ctx { get; set; }

        public void Atualizar(Paciente PacienteAtualizado, int IdPacienteAtualizado)
        {
            Paciente PacienteBuscado = BuscarPorId(IdPacienteAtualizado);
            int IdUsuario = PacienteBuscado.IdUsuario;

            if (PacienteBuscado != null)
            {
                PacienteBuscado = new Paciente()
                {
                    Nome = PacienteAtualizado.Nome,
                    Telefone = PacienteAtualizado.Telefone,
                    Cpf = PacienteAtualizado.Cpf,
                    Endereco = PacienteAtualizado.Endereco,
                    Rg = PacienteAtualizado.Rg,
                    IdPaciente = IdPacienteAtualizado,
                    IdUsuario = IdUsuario
                };

                Ctx.Pacientes.Update(PacienteBuscado);
                Ctx.SaveChanges();
            }
        }

        public Paciente BuscarPorId(int IdPaciente)
        {
            return Ctx.Pacientes.Include(P => P.IdUsuarioNavigation).FirstOrDefault(P => P.IdPaciente == IdPaciente);
        }

        public void Cadastrar(Paciente NovoPaciente)
        {
            Ctx.Pacientes.Add(NovoPaciente);
            Ctx.SaveChanges();
        }

        public void Deletar(int IdPacienteDeletado)
        {
            Ctx.Pacientes.Remove(BuscarPorId(IdPacienteDeletado));
            Ctx.SaveChanges();
        }

        public List<Paciente> ListarTodos()
        {
            return Ctx.Pacientes.Include(P => P.IdUsuarioNavigation).ToList();
        }
    }
}
