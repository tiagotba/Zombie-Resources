using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppZombieResources.ViewModels
{
    public class SobreviventeViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string LoginName { get; set; }
        public int Idade { get; set; }
        public string HashSeguranca { get; set; }
    }
}