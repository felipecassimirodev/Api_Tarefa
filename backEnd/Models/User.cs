using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace APITarefas.Models
{
    public class User
    {
        public User(string nome, string senha)
        {
            Nome = nome;
            Senha = senha;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Nome { get; set; } = null!;

        public string Senha{ get; set; } = null!;

        public void AtualizaUser(string nome, string senha)
        {
            Nome = nome;
            Senha = senha;
        }

    }




}
