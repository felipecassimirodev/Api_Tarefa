namespace Cassimiro.Dominio.Entidades
{
    public class Tramite
    {
        public Tramite()
        {

        }

        public string TraID 
        { 
            get;
            set;
        } 
        

        public int  SolID
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