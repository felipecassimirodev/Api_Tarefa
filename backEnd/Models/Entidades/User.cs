using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace APITarefas.Models.Entidades
{
    public class User
    {
        public User()
        {
            Nome = "";

        }

        #region Properties

        /// <summary>
        /// There are no comments for UsuId in the schema.
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? UsuId
        {
            get;
            set;
        }

        /// <summary>
        /// There are no comments for Nome in the schema.
        /// </summary>
        public string? Nome
        {
            get;
            set;
        }

        /// <summary>
        /// There are no comments for Usuario in the schema.
        /// </summary>
        public string? Usuario
        {
            get;
            set;
        }

        /// <summary>
        /// There are no comments for Senha in the schema.
        /// </summary>
        public string? Senha
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

        #endregion

        public void AtualizaUser(string nome, string senha)
        {
            Nome = nome;
            Senha = senha;
        }

    }




}
