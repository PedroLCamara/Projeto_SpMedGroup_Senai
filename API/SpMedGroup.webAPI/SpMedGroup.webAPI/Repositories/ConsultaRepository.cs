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
    /// Repositório para a definição da usabilidade dos métodos da entidade de Consulta
    /// </summary>
    public class ConsultaRepository : IConsultaRepository
    {
        /// <summary>
        /// Objeto do tipo contexto para as interações com o BD
        /// </summary>
        private SpMedGroupContext Ctx { get; set; }

        public ConsultaRepository()
        {
            List<Consultum> Consultas= Ctx.Consulta.ToList();

            foreach (Consultum item in Consultas)
            {
                if (item.IdSituacao != 3)
                {
                    if (item.DataHorario < DateTime.Now)
                    {
                        item.IdSituacao = 2;
                        Ctx.Update(item);
                    }
                }
            }
            Ctx.SaveChanges();
        }

        public void Agendar(Consultum NovaConsulta)
        {
            NovaConsulta.IdSituacao = 1;
            Ctx.Consulta.Add(NovaConsulta);
            Ctx.SaveChanges();
        }

        public void AlterarDescricao(int IdConsulta, string Descricao)
        {
            Consultum ConsultaBuscada = BuscarPorId(IdConsulta);

            if (ConsultaBuscada != null)
            {
                ConsultaBuscada.Descricao = Descricao;
                Ctx.Consulta.Update(ConsultaBuscada);
                Ctx.SaveChanges();
            };
        }

        public void Atualizar(Consultum ConsultaAtualizada, int IdConsultaAtualizada)
        {
            Consultum ConsultaBuscada = BuscarPorId(IdConsultaAtualizada);

            if (ConsultaBuscada != null)
            {
                ConsultaBuscada = new()
                {
                    IdPaciente = ConsultaAtualizada.IdPaciente,
                    IdMedico = ConsultaAtualizada.IdMedico,
                    DataHorario = ConsultaAtualizada.DataHorario,
                    Descricao = ConsultaAtualizada.Descricao,
                    IdSituacao = ConsultaAtualizada.IdSituacao,
                    IdConsulta = IdConsultaAtualizada
                };
                if (ConsultaBuscada.IdSituacao != 3)
                {
                    if (ConsultaAtualizada.DataHorario < DateTime.Now)
                    {
                        ConsultaBuscada.IdSituacao = 2;
                    }
                }
                Ctx.Update(ConsultaBuscada);
                Ctx.SaveChanges();
            }
        }

        public Consultum BuscarPorId(int IdConsulta)
        {
            return Ctx.Consulta.Include(C => C.IdMedicoNavigation).Include(C => C.IdPacienteNavigation).FirstOrDefault(C => C.IdConsulta == IdConsulta);
        }

        public void Cancelar(int IdConsultaCancelada)
        {
            Consultum ConsultaBuscada = BuscarPorId(IdConsultaCancelada);

            if (ConsultaBuscada != null)
            {
                ConsultaBuscada.IdSituacao = 3;
                Ctx.Consulta.Update(ConsultaBuscada);
                Ctx.SaveChanges();
            };
        }

        public void Deletar(int IdConsultaDeletada)
        {
            Ctx.Remove(BuscarPorId(IdConsultaDeletada));
            Ctx.SaveChanges();
        }

        public List<Consultum> ListarPorMedico(int IdMedico)
        {
            return Ctx.Consulta.Include(C => C.IdMedicoNavigation).Include(C => C.IdPacienteNavigation).Where(C => C.IdMedico == IdMedico).ToList();
        }

        public List<Consultum> ListarPorPaciente(int IdPaciente)
        {
            return Ctx.Consulta.Include(C => C.IdMedicoNavigation).Include(C => C.IdPacienteNavigation).Where(C => C.IdPaciente == IdPaciente).ToList();
        }

        public List<Consultum> ListarTodas()
        {
            return Ctx.Consulta.Include(C => C.IdMedicoNavigation).Include(C => C.IdPacienteNavigation).ToList();
        }
    }
}
