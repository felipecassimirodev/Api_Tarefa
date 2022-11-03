using System.ComponentModel.DataAnnotations;

namespace APITarefas.Models.InputModels
{
    public class ChamadoInput
    {
        [Required]
        public string? Nome { get; set; }

        [Required]
        public string? Titulo { get; set; }

        [Required]
        public string? Detalhes { get; set; }
    }
}
