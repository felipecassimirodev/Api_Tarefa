using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace APITarefas.Models
{
    public class Chamado
    {
        public Chamado(string titulo, string descricao, string status)
        {
            Titulo = titulo;
            Descricao = descricao;
            Status = status;
            DataAbertura = DateTime.Now;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Titulo")]
        public string Titulo { get; set; } = "";
        public string Descricao { get; set; } = "";
        public string? Status { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime? DataFechamento { get; set; } = null;

        public bool Concluido { get; set; }

        public void AtualizarChamado(string titulo, string descricao, string detalhes, string status ,bool? concluido = false)
        {
            Titulo = titulo;
            Descricao = descricao;
            Status = status;
            Concluido = concluido ?? false;
            DataFechamento = Concluido ? DateTime.Now : null;
        }
    }
}
