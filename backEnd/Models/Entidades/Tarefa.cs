using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace APITarefas.Models.Entidades
{
    public class Tarefa
    {
        public Tarefa(string nome, string titulo, string detalhes)
        {
            Nome = nome;
            Titulo = titulo;
            Detalhes = detalhes;
            DataCadastro = DateTime.Now;
        }




        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? ID { get; set; }

        public string Nome { get; set; }

        public string Titulo { get; set; }

        public string Detalhes { get; set; }

        public DateTime DataCadastro { get; set; }


        public DateTime? DataConclusao { get; set; }

        public bool Concluido { get; set; }

        public void AtualizarTarefa(string nome, string titulo, string detalhes,  bool? concluido = false)
        {
            Nome = nome;
            Titulo = titulo;
            Detalhes = detalhes;
            Concluido = concluido ?? false;
            DataConclusao = Concluido ? DateTime.Now : null;
        }


    }
}
