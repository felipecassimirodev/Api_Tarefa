using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace APITarefas.Models.Entidades
{
    public class Tramite
    {
        public Tramite()
        {
            Retrabalho = false;
            Solucao = false;
            TraData = DateTime.Now;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? TraID 
        { 
            get;
            set;
        }

        public string? Descricao
        {
            get;
            set;
        }

        public int?  SolID
        { 
            get;
            set;
        } 

        public int? UsuIDResponsavel
        { 
            get;
            set;
        }

        public bool Retrabalho
        { 
            get;
            set;
        }

        public bool Solucao
        {
            get;
            set;
        }

        public global::System.Nullable<System.DateTime> TraData
        { 
            get;
            set;
        }

        public void AtualizaTramite( Tramite tramite)
        {
            SolID= tramite.SolID;
            UsuIDResponsavel= tramite.UsuIDResponsavel;
            Descricao= tramite.Descricao;
        }
    }
}