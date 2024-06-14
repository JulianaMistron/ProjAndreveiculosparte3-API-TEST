using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace APIFuncionario.Data
{
    public class APIFuncionarioContext : DbContext
    {
        public APIFuncionarioContext (DbContextOptions<APIFuncionarioContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Funcionario> Funcionario { get; set; } = default!;
    }
}
