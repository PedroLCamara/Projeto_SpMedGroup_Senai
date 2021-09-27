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
    /// Repositório para a definição da usabilidade dos métodos da entidade de Situacao
    /// </summary>
    public class SituacaoRepository : ISituacaoRepository
    {
        /// <summary>
        /// Objeto do tipo contexto para as interações com o BD
        /// </summary>
        private SpMedGroupContext Ctx { get; set; }

        public void Atualizar(Situacao SituacaoAtualizada, int IdSituacaoAtualizada)
        {
            Situacao SituacaoBuscada = BuscarPorId(IdSituacaoAtualizada);
            if (SituacaoBuscada != null)
            {
                SituacaoBuscada.Nome = SituacaoAtualizada.Nome;
                Ctx.Situacaos.Update(SituacaoBuscada);
                Ctx.SaveChanges();
            }
        }

        public Situacao BuscarPorId(int IdSituacao)
        {
            return Ctx.Situacaos.Include(S => S.Consulta).FirstOrDefault(S => S.IdSituacao == IdSituacao);
        }

        public void Cadastrar(Situacao NovaSituacao)
        {
            Ctx.Situacaos.Add(NovaSituacao);
            Ctx.SaveChanges();
        }

        public void Deletar(int IdSituacaoDeletada)
        {
            Ctx.Situacaos.Add(BuscarPorId(IdSituacaoDeletada));
            Ctx.SaveChanges();
        }

        public List<Situacao> ListarTodas()
        {
            return Ctx.Situacaos.Include(S => S.Consulta).ToList();
        }
    }
}
