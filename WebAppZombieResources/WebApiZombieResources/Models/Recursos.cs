using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiZombieResources.Models
{
    public class Recursos
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public string Observacao { get; set; }
        public virtual Sobrevivente Sobrevivente { get; set; }
        public int IdSobrevivente { get; set; }
    }
}