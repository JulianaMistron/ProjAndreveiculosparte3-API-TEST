using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace APIServicoCarro.Data
{
    public class APIServicoCarroContext : DbContext
    {
        public APIServicoCarroContext (DbContextOptions<APIServicoCarroContext> options)
            : base(options)
        {
        }

        public DbSet<Models.CarroServico> CarroServico { get; set; } = default!;
    }
}
