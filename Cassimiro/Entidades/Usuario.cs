using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cassimiro.Dominio.Entidades
{
    internal class Usuario
    {
        public Usuario(string nome, string senha)
        {
            Nome = nome;
            UsuSenha = senha;
        }


        #region Properties

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public virtual string? UsuID
        {
            get;
            set;
        }

        public virtual string Nome
        {
            get;
            set;
        }

        public virtual string UsuSenha
        {
            get;
            set;
        }


        #endregion

        public void AtualizaUser(string nome, string senha)
        {
            Nome = nome;
            UsuSenha = senha;
        }
    }
}
