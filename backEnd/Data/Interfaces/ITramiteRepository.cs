using APITarefas.Models.Entidades;

namespace APITarefas.Data.Interfaces
{
    public interface ITramiteRepository
    {
        void Adicionar(Tramite tramite);

        void Atualizar(string id, Tramite tramiteAtualizado);

        IEnumerable<Tramite> Buscar();

        Tramite BuscarID(string id);

        void Remover(string id);
    }
}
