using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PendenciaFinanceira
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataPendencia { get; set; }
        public DateTime DataCobranca { get; set; }

        public bool Status { get; set; }

        public Cliente cliente { get; set; }    

    }
}

