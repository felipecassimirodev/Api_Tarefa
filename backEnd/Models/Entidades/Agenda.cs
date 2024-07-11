using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using APITarefas.Models.Enum;

namespace APITarefas.Models.Entidades
{
    public class Agenda
    {
        // Construtor sem parâmetros para a desserialização
        public Agenda() { }

        // Construtor com parâmetros para inicialização
        public Agenda(string nome, string detalhes, string procedimento, DateTime dataAgendamento)
        {
            Nome = nome;
            Detalhes = detalhes;
            Procedimento = procedimento;
            DataCadastro = DateTime.Now;
            DataAgendamento = dataAgendamento;
            Concluido = false;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? ID { get; set; }

        public string Nome { get; set; }

        public string Procedimento { get; set; }

        public string Detalhes { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataAgendamento { get; set; }

        public bool Concluido { get; set; }

        public void AtualizarAgenda(string nome, string detalhes, string procedimento, DateTime dataAgendamento, bool? concluido = false)
        {
            Nome = nome;
            Detalhes = detalhes;
            Procedimento = procedimento;
            Concluido = concluido ?? false;
            DataAgendamento = dataAgendamento;
        }
    }
}
