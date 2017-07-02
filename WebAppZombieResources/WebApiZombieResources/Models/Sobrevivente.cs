using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiZombieResources.Models
{
    public class Sobrevivente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Genero { get; set; }
        public int Idade { get; set; }
        public string HashSeguranca { get; set; }
        public string LoginName { get; set; }
        public bool EAdmin { get; set; }
        public virtual List<Recursos> Recursos { get; set; }
    }
}