using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Final.Models;
using Proyecto_Final.Repository;

namespace Proyecto_Final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoVendidoController : ControllerBase
    {
        [HttpDelete("{idProducto}")]
        public int EliminarProductosVendidos (long idProducto)
        {
            return ProductoVendidoHandler.EliminarProductosVendidos(idProducto);
        }

        [HttpGet("{idUsuario}")]
        public List<Producto> TraerProductoVendido(long idUsuario)
        { 
            return ProductoVendidoHandler.TraerProductosVendidos(idUsuario);
        }
    }
}
