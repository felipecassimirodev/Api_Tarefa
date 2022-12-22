using System.ComponentModel.DataAnnotations;

namespace APITarefas.Models.InputModels
{
    public class TramiteInput
    {
        [Required]
        public virtual string? Descricao
        {
            get;
            set;
        }
        [Required]
        public virtual int? SolID
        {
            get;
            set;
        }

        [Required]
        public virtual int? UsuIDResponsavel
        {
            get;
            set;
        }
    }
}
