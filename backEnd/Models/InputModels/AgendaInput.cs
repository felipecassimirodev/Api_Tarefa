using System.ComponentModel.DataAnnotations;

namespace APITarefas.Models.InputModels
{
    public class AgendaInput
    {
        [Required]
        public string? Nome
        {
            get;
            set;
        }

        [Required]
        public string? Procedimento
        {
            get;
            set;
        }

        public string? Detalhes
        {
            get;
            set;
        }

        [Required]
        public DateTime DataAgendamento
        {
            get;
            set;
        }
        public bool? Concluido
        {
            get;
            set;
        }

    }
}
