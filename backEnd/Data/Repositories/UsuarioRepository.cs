﻿using APITarefas.Data.Configurations;
using APITarefas.Models.Entidades;
using MongoDB.Driver;

namespace APITarefas.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IMongoCollection<User> _usuario;

        public UsuarioRepository(IDataBaseConfig dataBaseConfig)
        {
            var client = new MongoClient(dataBaseConfig.ConnectionString);
            var database = client.GetDatabase(dataBaseConfig.DataBaseName);

            _usuario = database.GetCollection<User>("Usuario");
        }

        public void Adicionar(User user)
        {
            _usuario.InsertOne(user);
        }

        public void Atualizar(string id, User usuario)
        {
            _usuario.ReplaceOne(usu => usu.UsuId== id, usuario);
        }

        public IEnumerable<User> Buscar()
        {
            return _usuario.Find(usuarios => true).ToList();
        }
        public User BuscarPorUsuarioSenha(string username, string senha)
        {
            return _usuario.Find(user => user.Usuario == username && user.Senha == senha).FirstOrDefault();
        }
        public User BuscarID(string id)
        {
            return _usuario.Find(usuario => usuario.UsuId == id).FirstOrDefault();
        }

        public void Remover(string id)
        {
            _usuario.DeleteOne(usuario => usuario.UsuId == id);
        }

        public async Task<User> GetUserByUsername(string username) =>
       await _usuario.Find(user => user.Usuario == username).FirstOrDefaultAsync();

    }
}
