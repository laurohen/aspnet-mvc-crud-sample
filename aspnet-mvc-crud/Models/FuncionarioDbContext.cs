using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace aspnet_mvc_crud.Models
{
    public class FuncionarioDbContext: DbContext
    {
        public FuncionarioDbContext(DbContextOptions<FuncionarioDbContext> options) : base(options)
        { }

        public DbSet<FuncionarioModel> Funcionarios { get; set; }
        public DbSet<EstadoModel> Estados { get; set; }
    }
}
