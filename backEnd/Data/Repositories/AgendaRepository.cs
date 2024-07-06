using APITarefas.Data.Configurations;
using APITarefas.Data.Interfaces;
using APITarefas.Models.Entidades;
using MongoDB.Driver;

namespace APITarefas.Data.Repositories
{
    public class AgendaRepository : IAgenda
    {
        private readonly IMongoCollection<Agenda> _agenda;

        public AgendaRepository(IDataBaseConfig dataBaseConfig)
        {
            var client = new MongoClient(dataBaseConfig.ConnectionString);
            var database = client.GetDatabase(dataBaseConfig.DataBaseName);

            _agenda = database.GetCollection<Agenda>("agenda");
        }

        public void Adicionar(Agenda user)
        {
            _agenda.InsertOne(user);
        }

        public void Atualizar(string id, Agenda tarefaAtualizada)
        {
            _agenda.ReplaceOne(tarefa => tarefa.ID == id, tarefaAtualizada);
        }

        public void Remover(string id)
        {
            _agenda.DeleteOne(tarefa => tarefa.ID == id);
        }
        public IEnumerable<Agenda> Buscar()
        {
            return _agenda.Find(tarefa => true).ToList();
        }

        Agenda IAgenda.BuscarID(string id)
        {
            return _agenda.Find(tarefa => tarefa.ID == id).FirstOrDefault();
        }
    }
}
