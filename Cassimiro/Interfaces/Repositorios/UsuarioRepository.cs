using Cassimiro.Dominio.Interfaces;
using Cassimiro.Dominio.Entidades;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cassimiro.Dominio.Interfaces.Repositorios
{
    internal class UsuarioRepository : IUsuarioRepository
    {
        private readonly IMongoCollection<Usuario> _usuario;

       /* public UsuarioRepository(IDataBaseConfig dataBaseConfig)
        {
            var client = new MongoClient(dataBaseConfig.ConnectionString);
            var database = client.GetDatabase(dataBaseConfig.DataBaseName);

            _usuario = database.GetCollection<Usuario>("Usuario");
        }*/

        public void Adicionar(Usuario user)
        {
            _usuario.InsertOne(user);
        }

        public void Atualizar(string id, Usuario usuario)
        {
            _usuario.ReplaceOne(usu => usu.UsuID == id, usuario);
        }

        public IEnumerable<Usuario> Buscar()
        {
            return _usuario.Find(usuarios => true).ToList();
        }

        public Usuario BuscarID(string id)
        {
            return _usuario.Find(usuario => usuario.UsuID == id).FirstOrDefault();
        }

        public void Remover(string id)
        {
            _usuario.DeleteOne(usuario => usuario.UsuID == id);
        }
    }
}
