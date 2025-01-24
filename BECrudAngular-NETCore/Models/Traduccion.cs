using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BECrudAngular_NETCore.Models
{
    public class Traduccion
    {
        [Key]
        public int Id { get; set; }
        public string Clave { get; set; }
        public string Idioma { get; set; }
        public string Texto { get; set; }
    }
}
