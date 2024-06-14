using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace APICarro.Data
{
    public class APICarroContext : DbContext
    {
        public APICarroContext (DbContextOptions<APICarroContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Carro> Carro { get; set; } = default!;
    }
}
