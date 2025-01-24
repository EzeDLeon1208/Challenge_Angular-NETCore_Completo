using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BECrudAngular_NETCore.Models;

namespace BECrudAngular_NETCore
{
    public class AplicationDbContext: DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options): base(options){ }

        public DbSet<Contacto> Contacto { get; set; }
        public DbSet<Traduccion> Traduccion { get; set; }
    }
}
