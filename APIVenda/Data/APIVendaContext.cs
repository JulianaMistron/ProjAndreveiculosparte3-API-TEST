using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace APIVenda.Data
{
    public class APIVendaContext : DbContext
    {
        public APIVendaContext (DbContextOptions<APIVendaContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Venda> Venda { get; set; } = default!;
    }
}
