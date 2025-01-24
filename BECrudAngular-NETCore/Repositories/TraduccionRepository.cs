using BECrudAngular_NETCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BECrudAngular_NETCore.Repositories
{
    public class TraduccionRepository : Repository<Traduccion>, ITraduccionRepository
    {
        private readonly AplicationDbContext _context;

        //public TraduccionRepository(AplicationDbContext context)
        //{
        //    _context = context;
        //}
        public TraduccionRepository(AplicationDbContext context) : base(context){ }

        public async Task<List<Traduccion>> GetByIdiomaAsync(string lang)
        {
            var traduccion = await _context.Traduccion
            .Where(t => t.Idioma == lang)
            .ToListAsync();

            return traduccion;
            
            //return await _context.Traduccion
            //    .Where(t => t.Idioma == lang)
            //    .ToListAsync();
        }
    }
}
