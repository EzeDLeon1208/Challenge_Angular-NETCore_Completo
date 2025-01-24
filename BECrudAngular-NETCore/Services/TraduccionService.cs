using BECrudAngular_NETCore.Models;
using BECrudAngular_NETCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BECrudAngular_NETCore.Services
{
    public class TraduccionService
    {
        private readonly ITraduccionRepository _repository;

        public TraduccionService(ITraduccionRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Traduccion>> GetTraduccionesPorIdioma(string lang)
        {
            return await _repository.GetByIdiomaAsync(lang);
        }
    }
}
