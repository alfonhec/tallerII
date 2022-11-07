using Microsoft.AspNetCore.Mvc;
using APIalquiler.Data;
using System.Security.Cryptography;

namespace APIalquiler.Controllers
{
    public class MetodoPagoController : Controller
    {
        // GET: PagosController
        [HttpGet("Metodo-Pago/consultarMetodosPago")]
        public ActionResult Index()
        {
            conexiondb _conexiondb = new conexiondb();
            var metodo_pago = _conexiondb.GetMetodoPago();
            return new OkObjectResult(metodo_pago);
        }
    }
}




