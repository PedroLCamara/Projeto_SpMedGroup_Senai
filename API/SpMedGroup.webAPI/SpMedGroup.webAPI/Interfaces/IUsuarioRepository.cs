using SpMedGroup.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedGroup.webAPI.Interfaces
{
    /// <summary>
    /// Interface da entidade de usuário
    /// </summary>
    interface IUsuarioRepository
    {
        /// <summary>
        /// Método para o cadastro de um novo usuário
        /// </summary>
        /// <param name="NovoUsuario">Novo usuário recebido</param>
        void Cadastrar(Usuario NovoUsuario);

        /// <summary>
        /// Método para a leitura de todos os usuários
        /// </summary>
        /// <returns>Uma lista com todos os usuários</returns>
        List<Usuario> ListarTodos();

        /// <summary>
        /// Método para a leitura de um usuário específico
        /// </summary>
        /// <param name="IdUsuario">Id do usuário buscado</param>
        /// <returns>Usuário encontrado</returns>
        Usuario BuscarPorId(int IdUsuario);

        /// <summary>
        /// Método para o update de um usuário 
        /// </summary>
        /// <param name="UsuarioAtualizado">Usuário atualizado</param>
        /// <param name="IdUsuarioAtualizado">Id do usuário a ser atualizado</param>
        void Atualizar(Usuario UsuarioAtualizado, int IdUsuarioAtualizado);

        /// <summary>
        /// Método para a remoção de um usuário
        /// </summary>
        /// <param name="IdUsuarioDeletado">Id do usuário a ser removido</param>
        void Deletar(int IdUsuarioDeletado);

        /// <summary>
        /// Método para o login(leitura por email e senha) de um usuário
        /// </summary>
        /// <param name="Email">Email do usuário buscado</param>
        /// <param name="Senha">Senha do usuário buscado</param>
        /// <returns>Usuário encontrado</returns>
        Usuario Logar(string Email, string Senha);
    }
}
