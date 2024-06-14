using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Cliente : Pessoa
    {

        public Decimal Renda { get; set; }
        public string DocumentoPDF { get; set; }
    }
}
