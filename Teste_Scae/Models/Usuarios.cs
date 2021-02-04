using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_Scae.Models
{
    public class Usuarios
    {
        public int id { get; set; }
        public string nome { get; set; }
        public Enderecos end { get; set; }
    }
}
