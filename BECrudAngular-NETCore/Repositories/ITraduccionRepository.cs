using BECrudAngular_NETCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BECrudAngular_NETCore.Repositories
{
    public interface ITraduccionRepository : IRepository<Traduccion>
    {
        Task<List<Traduccion>> GetByIdiomaAsync(string idioma);
    }
}
