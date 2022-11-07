using Microsoft.AspNetCore.Mvc;
using APIalquiler.Data;
using System.Security.Cryptography;

namespace APIalquiler.Controllers

{
    public class ClienteController : Controller
    {
        // GET: ClienteController
        [HttpGet("cliente/consultarCliente")]
        public ActionResult Index()
        {
            conexiondb _conexiondb = new conexiondb();
            var cliente = _conexiondb.GetCliente();
            return new OkObjectResult(cliente);
        }

    }

}
