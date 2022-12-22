using APITarefas.Data.Configurations;
using APITarefas.Models.Entidades;
using MongoDB.Driver;

namespace APITarefas.Data.Repositories
{
    public class TarefasRepository : ITarefasRepository
    {
        private readonly IMongoCollection<Tarefa> _tarefas;

        public TarefasRepository(IDataBaseConfig dataBaseConfig)
        {
            var client = new MongoClient(dataBaseConfig.ConnectionString);
            var database = client.GetDatabase(dataBaseConfig.DataBaseName);

            _tarefas = database.GetCollection<Tarefa>("tarefa");
        }

        public void Adicionar(Tarefa user)
        {
            _tarefas.InsertOne(user);
        }

        public void Atualizar(string id, Tarefa tarefaAtualizada)
        {
            _tarefas.ReplaceOne(tarefa => tarefa.ID == id, tarefaAtualizada);
        }

        public void Remover(string id)
        {
            _tarefas.DeleteOne(tarefa => tarefa.ID == id);
        }
        public IEnumerable<Tarefa> Buscar()
        {
            return  _tarefas.Find(tarefa => true).ToList();
        }

        Tarefa ITarefasRepository.BuscarID(string id)
        {
            return _tarefas.Find(tarefa => tarefa.ID== id).FirstOrDefault();
        }
    }
}
