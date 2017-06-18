using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiZombieResources.Models;

namespace WebApiZombieResources.Repositorios
{
    public interface IRecursosRepository
    {
        List<Recursos> GetRecursosList();
        void CreateRecursos(Recursos modelo);
        void EditaMovimentacoesRecursos(string id);
        void EditaDetalhesRecursos(string id);

    }
}
