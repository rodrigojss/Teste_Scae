using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_Scae.Models
{
    public class Enderecos
    {
        public int idEnd { get; set; }
        public string end { get; set; }
        

        public static implicit operator Enderecos(string v)
        {
            throw new NotImplementedException();
        }
    }
}
