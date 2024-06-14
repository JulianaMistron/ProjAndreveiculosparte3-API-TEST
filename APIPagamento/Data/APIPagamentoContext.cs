using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace APIPagamento.Data
{
    public class APIPagamentoContext : DbContext
    {
        public APIPagamentoContext (DbContextOptions<APIPagamentoContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Pagamento> Pagamento { get; set; } = default!;
    }
}
