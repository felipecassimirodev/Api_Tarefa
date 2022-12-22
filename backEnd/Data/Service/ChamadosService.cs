using APITarefas.Data.Configurations;
using APITarefas.Models.Entidades;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace APITarefas.Data.Service
{
    public class ChamadosService
    {
        private readonly IMongoCollection<Chamado> _chamados;

        public ChamadosService(IOptions<DataBaseConfig> options)
        { 
            var mongoClient = new MongoClient(options.Value.ConnectionString);

            _chamados = mongoClient.GetDatabase(options.Value.DataBaseName)
                .GetCollection<Chamado>("chamado");
        }

        public async Task<List<Chamado>> Get() =>
            await _chamados.Find(_ => true).ToListAsync();

        public async Task<Chamado> Get(string id) =>
          await _chamados.Find(m => m.SolID == id).FirstOrDefaultAsync();

        public async Task Create(Chamado novoChamado) =>
          await _chamados.InsertOneAsync(novoChamado);


        public async Task Update(string id, Chamado atualizaChamado) =>
          await _chamados.ReplaceOneAsync(m => m.SolID == id, atualizaChamado);

        public async Task remove(string id) =>
          await _chamados.DeleteOneAsync(m => m.SolID == id);

     
    }
}
