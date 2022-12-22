using APITarefas.Models.Entidades;

namespace APITarefas.Data.Repositories
{
    public interface ITarefasRepository
    {
        void Adicionar(Tarefa user);

        void Atualizar(string id,Tarefa tarefaAtualizada);

        IEnumerable<Tarefa> Buscar();

        Tarefa BuscarID(string id);

        void Remover(string id);
    }
}
