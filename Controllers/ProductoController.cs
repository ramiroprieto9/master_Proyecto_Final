using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Final.Models;
using Proyecto_Final.Repository;

namespace Proyecto_Final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpPost]
        public Producto CrearProducto(Producto producto)
        {
            ProductoHandler.CrearProducto(producto);
            return producto;
        }

        [HttpGet("{idUsuario}")]
        public List<Producto> TraerProducto(long idUsuario)
        {
            return ProductoHandler.TraerProducto(idUsuario);
        }

        [HttpDelete("{id}")]
        public int EliminarProducto (long id)
        {
            return ProductoHandler.EliminarProducto(id);
        }

        [HttpPut]
        public int ModificarProducto(Producto producto)
        {
            return ProductoHandler.ModificarProducto(producto);
        }

    }


}

