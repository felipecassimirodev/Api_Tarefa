using APITarefas.Models.Entidades;

namespace APITarefas.Data.Interfaces
{
    public interface IVendas
    {
        void Adicionar(Vendas user);

        void Atualizar(string id, Vendas tarefaAtualizada);

        IEnumerable<Vendas> Buscar();

        Vendas BuscarID(string id);

        void Remover(string id);
    }
}
