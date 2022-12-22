using APITarefas.Models.Entidades;

namespace APITarefas.Data.Repositories
{
    public interface IUsuarioRepository
    {
        void Adicionar(User user);

        void Atualizar(string id, User usuario);

        IEnumerable<User> Buscar();

        User BuscarID(string id);

        void Remover(string id);
    }
}
