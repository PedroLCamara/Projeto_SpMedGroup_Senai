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
    /// Repositório para a definição da usabilidade dos métodos da entidade de Usuario
    /// </summary>
    public class UsuarioRepository : IUsuarioRepository
    {
        /// <summary>
        /// Objeto do tipo contexto para as interações com o BD
        /// </summary>
        private SpMedGroupContext Ctx { get; set; }

        public void Atualizar(Usuario UsuarioAtualizado, int IdUsuarioAtualizado)
        {
            Usuario UsuarioBuscado = BuscarPorId(IdUsuarioAtualizado);

            if (UsuarioBuscado != null)
            {
                UsuarioBuscado = new Usuario()
                {
                    Email = UsuarioAtualizado.Email,
                    Senha = UsuarioAtualizado.Senha,
                    DataDeNascimento = UsuarioAtualizado.DataDeNascimento,
                    IdTipoUsuario = UsuarioAtualizado.IdTipoUsuario,
                    IdUsuario = IdUsuarioAtualizado
                };

                Ctx.Usuarios.Update(UsuarioBuscado);
                Ctx.SaveChanges();
            }
        }

        public Usuario BuscarPorId(int IdUsuario)
        {
            return Ctx.Usuarios.Include(U => U.IdTipoUsuarioNavigation).Include(U => U.Paciente).Include(U => U.Medico).FirstOrDefault(U => U.IdUsuario == IdUsuario);
        }

        public void Cadastrar(Usuario NovoUsuario)
        {
            Ctx.Usuarios.Add(NovoUsuario);
            Ctx.SaveChanges();
        }

        public void Deletar(int IdUsuarioDeletado)
        {
            Ctx.Remove(BuscarPorId(IdUsuarioDeletado));
            Ctx.SaveChanges();
        }

        public List<Usuario> ListarTodos()
        {
            return Ctx.Usuarios.Include(U => U.IdTipoUsuarioNavigation).Include(U => U.Paciente).Include(U => U.Medico).ToList();
        }

        public Usuario Logar(string Email, string Senha)
        {
            return Ctx.Usuarios.Include(U => U.IdTipoUsuarioNavigation).Include(U => U.Paciente).Include(U => U.Medico).FirstOrDefault(U => U.Email == Email && U.Senha == Senha);
        }
    }
}
