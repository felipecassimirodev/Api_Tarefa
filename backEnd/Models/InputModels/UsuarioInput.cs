using System.ComponentModel.DataAnnotations;

namespace APITarefas.Models.InputModels
{
    public class UsuarioInput
    {

        [Required]
        public virtual string? Nome
        {
            get;
            set;
        }
        [Required]
        public virtual string? Usuario
        {
            get;
            set;
        }

        [Required]
        public virtual string? UsuSenha
        {
            get;
            set;
        }

        /// <summary>
        /// There are no comments for Email in the schema.
        /// </summary>
        public string? Email
        {
            get;
            set;
        }

        /// <summary>
        /// There are no comments for Telefone in the schema.
        /// </summary>
        public string? Telefone
        {
            get;
            set;
        }



        public void AtualizaUser(string nome, string senha)
        {
            Nome = nome;
            UsuSenha = senha;
        }
    }
}
