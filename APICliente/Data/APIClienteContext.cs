using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace APICliente.Data
{
    public class APIClienteContext : DbContext
    {
        public APIClienteContext (DbContextOptions<APIClienteContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Cliente> Cliente { get; set; } = default!;
    }
}
