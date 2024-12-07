using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoP2.Models
{
    internal class Membresias
    {
        
        public int Id_Membresias {  get; set; }
        [MinLength(10)]
        [MaxLength(10)]
        public string Cedula {  get; set; }
        public string Nombre { get; set; }
        public string Membresia { get; set; }
        
    }
}
