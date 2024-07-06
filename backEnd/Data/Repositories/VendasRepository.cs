using APITarefas.Data.Configurations;
using APITarefas.Data.Interfaces;
using APITarefas.Models.Entidades;
using MongoDB.Driver;

namespace APITarefas.Data.Repositories
{
    public class VendasRepository : IVendas
    {
        private readonly IMongoCollection<Vendas> _vendas;

        public VendasRepository(IDataBaseConfig dataBaseConfig)
        {
            var client = new MongoClient(dataBaseConfig.ConnectionString);
            var database = client.GetDatabase(dataBaseConfig.DataBaseName);

            _vendas = database.GetCollection<Vendas>("vendas");
        }

        public void Adicionar(Vendas user)
        {
            _vendas.InsertOne(user);
        }

        public void Atualizar(string id, Vendas tarefaAtualizada)
        {
            _vendas.ReplaceOne(tarefa => tarefa.ID == id, tarefaAtualizada);
        }

        public void Remover(string id)
        {
            _vendas.DeleteOne(tarefa => tarefa.ID == id);
        }
        public IEnumerable<Vendas> Buscar()
        {
            return _vendas.Find(tarefa => true).ToList();
        }

        Vendas IVendas.BuscarID(string id)
        {
            return _vendas.Find(tarefa => tarefa.ID == id).FirstOrDefault();
        }
    }
}
