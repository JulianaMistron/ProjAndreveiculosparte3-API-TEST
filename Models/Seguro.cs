using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Seguro
    {
        public int Id { get; set; }
        public Cliente cliente { get; set; }
        public Decimal Franquia { get; set; }   
        public Carro carro { get; set; }
        public Condutor condutorPrincipal { get; set; }
    }
}
