using Cassimiro.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cassimiro.Dominio.Interfaces.Repositorios
{
    internal interface IUsuarioRepository
    {
        void Adicionar(Usuario user);

        void Atualizar(string id, Usuario usuario);

        IEnumerable<Usuario> Buscar();

        Usuario BuscarID(string id);

        void Remover(string id);
    }
}
