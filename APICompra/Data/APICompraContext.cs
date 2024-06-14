using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace APICompra.Data
{
    public class APICompraContext : DbContext
    {
        public APICompraContext (DbContextOptions<APICompraContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Compra> Compra { get; set; } = default!;
    }
}
