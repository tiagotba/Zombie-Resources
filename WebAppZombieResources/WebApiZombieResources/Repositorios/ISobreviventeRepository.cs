using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiZombieResources.Models;

namespace WebApiZombieResources.Repositorios
{
   public interface ISobreviventeRepository
    {
        List<Sobrevivente> GetSobreviventesList();
        void CreateSobreviventes(Sobrevivente modelo);
    }
}
