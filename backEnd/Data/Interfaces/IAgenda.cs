using APITarefas.Models.Entidades;

namespace APITarefas.Data.Interfaces
{
    public interface IAgenda
    {
        void Adicionar(Agenda user);

        void Atualizar(string id, Agenda tarefaAtualizada);

        IEnumerable<Agenda> Buscar();

        Agenda BuscarID(string id);

        void Remover(string id);
    }
}
