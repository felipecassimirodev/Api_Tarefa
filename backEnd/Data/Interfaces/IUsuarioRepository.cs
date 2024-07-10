using APITarefas.Models.Entidades;

namespace APITarefas.Data.Repositories
{
    public interface IUsuarioRepository
    {
        void Adicionar(User user);

        void Atualizar(string id, User usuario);

        IEnumerable<User> Buscar();

        User BuscarID(string id);

        User BuscarPorUsuarioSenha(string usuario, string senha);

        void Remover(string id);
    }
}
