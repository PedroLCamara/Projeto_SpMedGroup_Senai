using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SpMedGroup.webAPI.Contexts;
using SpMedGroup.webAPI.Domains;
using SpMedGroup.webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
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
                    Nome = UsuarioAtualizado.Nome,
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
            return Ctx.Usuarios.Select(U => new Usuario()
            {
                IdUsuario = U.IdUsuario,
                Nome = U.Nome,
                Email = U.Email,
                IdTipoUsuario = U.IdTipoUsuario,
                DataDeNascimento = U.DataDeNascimento,
                Medico = U.Medico,
                Paciente = U.Paciente
            }).FirstOrDefault(U => U.IdUsuario == IdUsuario);
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
            return Ctx.Usuarios.Select(U => new Usuario() { 
                IdUsuario = U.IdUsuario,
                Nome = U.Nome,
                Email = U.Email,
                IdTipoUsuario = U.IdTipoUsuario,
                DataDeNascimento = U.DataDeNascimento,
                Medico = U.Medico,
                Paciente = U.Paciente
            }).ToList();
        }

        public Usuario Logar(string Email, string Senha)
        {
            return Ctx.Usuarios.Include(U => U.IdTipoUsuarioNavigation).Include(U => U.Paciente).Include(U => U.Medico).FirstOrDefault(U => U.Email == Email && U.Senha == Senha);
        }

        public string RetornarImgPerfil(int IdUsuario)
        {
            string NomeArquivo = BuscarPorId(IdUsuario).ImagemPerfil;
            string Caminho = Path.Combine("PerfilImgs", NomeArquivo);
            if (File.Exists(Caminho))
            {
                Byte[] BytesImg = File.ReadAllBytes(Caminho);
                return Convert.ToBase64String(BytesImg);
            }
            else return null;
        }

        public void SalvarImgPerfil(IFormFile Img, int IdUsuario, string MimeType)
        {
            string NomeArquivo = $"{IdUsuario}.{MimeType}";

            using (var Stream = new FileStream(Path.Combine("PerfilImgs", NomeArquivo), FileMode.Create))
            {
                Img.CopyTo(Stream);
            }

            Usuario UsuarioNovaFoto = BuscarPorId(IdUsuario);
            UsuarioNovaFoto.ImagemPerfil = NomeArquivo;

            Ctx.Usuarios.Update(UsuarioNovaFoto);
            Ctx.SaveChanges();
        }
    }
}