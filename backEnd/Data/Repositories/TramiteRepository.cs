using APITarefas.Data.Configurations;
using APITarefas.Data.Interfaces;
using APITarefas.Models.Entidades;
using MongoDB.Driver;

namespace APITarefas.Data.Repositories
{
    public class TramiteRepository : ITramiteRepository
    {
        private readonly IMongoCollection<Tramite> _tramite;

        public TramiteRepository(IDataBaseConfig dataBaseConfig)
        {
            var client = new MongoClient(dataBaseConfig.ConnectionString);
            var database = client.GetDatabase(dataBaseConfig.DataBaseName);

            _tramite = database.GetCollection<Tramite>("tramite");
        }


        public void Adicionar(Tramite tramite)
        {
            _tramite.InsertOne(tramite);
        }

        public void Atualizar(string id, Tramite tramiteAtualizado)
        {
            _tramite.ReplaceOne(tarefa => tarefa.TraID == id, tramiteAtualizado);
        }

        public IEnumerable<Tramite> Buscar()
        {
            return _tramite.Find(tramire => true).ToList();
        }

        public Tramite BuscarID(string id)
        {
           return _tramite.Find(tramite => tramite.TraID == id).FirstOrDefault();
        }

        public void Remover(string id)
        {
            _tramite.DeleteOne(tramite => tramite.TraID ==  id);
        }
    }
}
