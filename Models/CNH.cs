using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CNH
    {
        [Key]
        public long Cnh { get; set; }
        public DateTime DataVencimento { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public string NomeMae { get; set; }
        public string NomePai { get; set; }
        public Categoria Categoria { get; set; }
    }
}
