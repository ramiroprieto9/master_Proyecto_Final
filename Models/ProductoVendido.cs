using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final.Models
{
    public class ProductoVendido
    {
        public long Id { get; set; }
        public long IdProducto{ get; set; }
        public long idVenta { get; set; }
        public int Stock { get; set; }
    }
}
