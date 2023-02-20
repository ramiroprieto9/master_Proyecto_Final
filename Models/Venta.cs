using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final.Models
{
    public class Venta
    {
        public long Id { get; set; }
        public long IdUsuario { get; set; }
        public string Comentarios { get; set; }
    }
}
