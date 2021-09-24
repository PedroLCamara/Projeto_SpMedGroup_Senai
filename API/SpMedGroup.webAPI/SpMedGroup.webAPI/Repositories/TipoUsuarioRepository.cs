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
    /// Repositório para a definição da usabilidade dos métodos da entidade de TipoUsuario
    /// </summary>
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        /// <summary>
        /// Objeto do tipo contexto para as interações com o BD
        /// </summary>
        private SpMedGroupContext Ctx { get; set; }

        public void Atualizar(TipoUsuario TipoUsuarioAtualizado, int IdTipoUsuarioAtualizado)
        {
            TipoUsuario TipoUsuarioBuscado = new TipoUsuario();

            if (TipoUsuarioBuscado != null)
            {
                TipoUsuarioBuscado.TituloTipoUsuario = TipoUsuarioAtualizado.TituloTipoUsuario;
                Ctx.Update(TipoUsuarioBuscado);
                Ctx.SaveChanges();
            }
        }

        public TipoUsuario BuscarPorId(int IdTipoUsuario)
        {
            List<Usuario> ListaUsuarios = new List<Usuario>();
            foreach (TipoUsuario item in Ctx.TipoUsuarios.Select(Tpu => new TipoUsuario() { Usuarios = Tpu.Usuarios }).ToList())
            {
                foreach (Usuario item2 in item.Usuarios)
                {
                    Usuario UsuarioLista = new()
                    {
                        IdUsuario = item2.IdUsuario,
                        Email = item2.Email,
                        DataDeNascimento = item2.DataDeNascimento
                    };

                    ListaUsuarios.Add(UsuarioLista);
                }
            }

            return Ctx.TipoUsuarios.Select(TpU => new TipoUsuario()
            {
                IdTipoUsuario = TpU.IdTipoUsuario,
                TituloTipoUsuario = TpU.TituloTipoUsuario,
                Usuarios = ListaUsuarios
            }
            ).FirstOrDefault(TpU => TpU.IdTipoUsuario == IdTipoUsuario);
        }

        public void Cadastrar(TipoUsuario NovoTipoUsuario)
        {
            Ctx.TipoUsuarios.Add(NovoTipoUsuario);
            Ctx.SaveChanges();
        }

        public void Deletar(int IdTipoUsuarioDeletado)
        {
            Ctx.TipoUsuarios.Remove(BuscarPorId(IdTipoUsuarioDeletado));
            Ctx.SaveChanges();
        }

        public List<TipoUsuario> ListarTodas()
        {
            List<Usuario> ListaUsuarios = new List<Usuario>();
            foreach (TipoUsuario item in Ctx.TipoUsuarios.Select(Tpu => new TipoUsuario() { Usuarios = Tpu.Usuarios }).ToList())
            {
                foreach (Usuario item2 in item.Usuarios)
                {
                    Usuario UsuarioLista = new()
                    {
                        IdUsuario = item2.IdUsuario,
                        Email = item2.Email,
                        DataDeNascimento = item2.DataDeNascimento
                    };

                    ListaUsuarios.Add(UsuarioLista);
                }
            }

            return Ctx.TipoUsuarios.Select(TpU => new TipoUsuario()
            {
                IdTipoUsuario = TpU.IdTipoUsuario,
                TituloTipoUsuario = TpU.TituloTipoUsuario,
                Usuarios = ListaUsuarios
            }
            ).ToList();
        }
    }
}
