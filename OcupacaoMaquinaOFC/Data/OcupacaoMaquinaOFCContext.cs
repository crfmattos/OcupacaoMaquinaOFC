using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OcupacaoMaquinaOFC.Models;

namespace OcupacaoMaquinaOFC.Data
{
    public class OcupacaoMaquinaOFCContext : DbContext
    {
        public OcupacaoMaquinaOFCContext (DbContextOptions<OcupacaoMaquinaOFCContext> options)
            : base(options)
        {
        }

        public DbSet<OcupacaoMaquinaOFC.Models.Maquina> Maquina { get; set; } = default!;

        public DbSet<OcupacaoMaquinaOFC.Models.Projeto>? Projeto { get; set; }
    }
}
