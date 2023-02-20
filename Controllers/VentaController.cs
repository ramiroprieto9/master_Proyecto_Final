using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Final.Models;
using Proyecto_Final.Repository;

namespace Proyecto_Final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        [HttpGet("{idUsuario}")]
        public List<Venta> TraerVentas(long idUsuario)
        {
            return VentaHandler.TraerVentas(idUsuario);
        }

        [HttpPost("{idUsuario}")]
        public void CargarVenta (long idUsuario, List<Producto> productosVendidos)
        {
            VentaHandler.CargarVenta(idUsuario, productosVendidos);
        }
    }
}
