using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using APITarefas.Models.Enum;

namespace APITarefas.Models.Entidades
{
    public class Vendas
    {
        public Vendas() { }
        public Vendas(string nome, string detalhes, string procedimento, DateTime dataAgendamento, string valor)
        {
            Nome = nome;
            Detalhes = detalhes;
            Procedimento = procedimento;
            DataCadastro = DateTime.Now;
            DataAgendamento = dataAgendamento;
            Valor = valor;
            Concluido = false;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? ID { get; set; }
        public string Nome { get; set; }
        public string Procedimento { get; set; }
        public string Detalhes { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAgendamento { get; set; }
        public bool Concluido { get; set; }
        public string Valor { get; set; }


        public void AtualizarVenda(string nome, string detalhes,string procedimento, string valor,bool? concluido = false)
        {
            Nome = nome;
            Detalhes = detalhes;
            Concluido = concluido ?? false;
            Procedimento = procedimento;
            DataAgendamento = Concluido ? DateTime.Now : null;
            Valor = valor;
        }
    }
}
