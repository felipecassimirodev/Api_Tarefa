namespace APITarefas.Models.Entidades
{
    public class Tramite
    {

        public string? TraID 
        { 
            get;
            set;
        } 


        public int?  SolID
        { 
            get;
            set;
        } 

        public int UsuIDDestino
        { 
            get;
            set;
        }
        
        public global::System.Nullable<System.DateTime> TraData
        { 
            get;
            set;
        }
        

    }
}