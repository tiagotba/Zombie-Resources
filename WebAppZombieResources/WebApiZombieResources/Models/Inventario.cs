using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiZombieResources.Models
{
    public class Inventario
    {
        public int Id { get; set; }
        public int RecursoId { get; set; }
        public int SobreviventeId { get; set; }
        public int QtdRetirada { get; set; }

        public virtual Recursos Recurso { get; set; }
        public virtual Sobrevivente Sobrevivente { get; set; }
    }
}