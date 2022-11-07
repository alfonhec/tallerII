using Microsoft.AspNetCore.Mvc;
using APIalquiler.Data;
using System.Security.Cryptography;

namespace APIalquiler.Controllers
{
    public class ProductoController : Controller
    {
        // GET: ProductoController
        [HttpGet("producto/consultarProducto")]
        public ActionResult Index(int cod_producto)
        {
            conexiondb _conexiondb = new conexiondb();
            var productos = _conexiondb.GetProducto(cod_producto);
            return Ok(productos);
        }

        // GET: ProductoController
        [HttpGet("productos/consultarProductos")]
        public ActionResult Index()
        {
            conexiondb _conexiondb = new conexiondb();
            var productos = _conexiondb.GetProductos();
            return new OkObjectResult(productos);
        }


        // POST: ProductosController/Create
        [HttpPost("productos/create")]
        public ActionResult Create([FromBody] Models.producto _producto)
        {
            try
            {
                conexiondb _conexiondb = new conexiondb();
                _conexiondb.CrearProducto(_producto);
                return new OkObjectResult("Se insertó correctamente el producto " + _producto.descripcion);
            }
            catch (Exception ex)
            {
                return StatusCode(400, "Error en la api: " + ex.Message);
            }
        }

        // POST: ProductosController/Edit/
        [HttpPut("productos/edit")]
        public ActionResult Edit([FromBody] Models.producto producto, int id)
        {
            try
            {
                conexiondb _conexiondb = new conexiondb();
                _conexiondb.ModificarProducto(producto, id);
                return new OkObjectResult("Producto modificado correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(400, "Error en la api: " + ex.Message);
           
            }
        }


        // POST: ProductosController/Delete/5
        [HttpDelete("productos/delete")]
        public ActionResult Delete(int cod_producto)
        {
            try
            {
                conexiondb _conexiondb = new conexiondb();
                _conexiondb.EliminarProducto(cod_producto);
                return new OkObjectResult("El registro se eliminó correctamente");
            }
            catch (Exception ex)
            { 
                return StatusCode(400, "Error en la api: " + ex.Message);

            }
        }
    }
}
