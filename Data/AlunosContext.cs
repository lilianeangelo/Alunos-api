using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Alunos;

namespace Data
{
    public class AlunosContext : DbContext
    {
        public AlunosContext (DbContextOptions<AlunosContext> options)
            : base(options)
        {
        }

        public DbSet<Alunos.Alunosclass> Alunos { get; set; } = default!;
    }
}
