using Cassimiro.Dominio.Enum;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace APITarefas.Models.Entidades
{
    public class Chamado
    {
        public Chamado(string titulo, string descricao, Status status)
        {
            Titulo = titulo;
            Descricao = descricao;
            Status = status;
            SolAbertura = DateTime.Now;
        }

        #region Properties

        /// <summary>
        /// There are no comments for SolID in the schema.
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? SolID
        { 
            get;
            set;
        }

        /// <summary>
        /// There are no comments for Titulo in the schema.
        /// </summary>
        [BsonElement("Titulo")]
        public string Titulo 
        {
            get;
            set; 
        } = "";

        /// <summary>
        /// There are no comments for Descricao in the schema.
        /// </summary>
        public string Descricao 
        { 
            get;
            set; 
        } = "";

        /// <summary>
        /// There are no comments for Status in the schema.
        /// </summary>
        public Status Status
        { 
            get;
            set;
        }

        /// <summary>
        /// There are no comments for SolAbertura in the schema.
        /// </summary>
        public DateTime SolAbertura
        {
            get;
            set;
        }

        /// <summary>
        /// There are no comments for SolFechamento in the schema.
        /// </summary>
        public DateTime? SolFechamento
        {
            get;
            set;
        }

        /// <summary>
        /// There are no comments for Concluido in the schema.
        /// </summary>
        public bool Concluido
        {
            get;
            set;
        }

        #endregion

        public void AtualizarChamado(string titulo, string descricao, string detalhes, Status status, bool? concluido = false)
        {
            Titulo = titulo;
            Descricao = descricao;
            Status = status;
            Concluido = concluido ?? false;
            SolFechamento = Concluido ? DateTime.Now : null;
        }
    }
}
