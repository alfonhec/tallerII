using Dapper;

namespace APIalquiler.Data

{
    public class conexiondb
    {
        #region Variables
        private string CadenaConexion = "Server=localhost;Port=5432;Database=alquileres;User Id=postgres;Password=pentest;";

        private Npgsql.NpgsqlConnection conexion;

        #endregion

        #region Constructor
        public conexiondb()
        {
            this.conexion = new Npgsql.NpgsqlConnection(CadenaConexion);
        }
        #endregion

        #region Lista de métodos

        public string CrearProducto(Models.producto _producto)
        {
            this.conexion.Open();

            string sql = "INSERT INTO producto(descripcion, tipo, color, precio) VALUES (@descripcion, @tipo, @color,  @precio)";

            var arguments = new
            {
                descripcion = _producto.descripcion,
                tipo = _producto.tipo,
                color = _producto.color,
                precio = _producto.precio,
            };

            conexion.ExecuteScalar(sql, arguments);

            return "";
        }


        public IEnumerable<Models.producto> GetProductos()
        {
            string SQL = "select * from producto";
            conexion.Open();
            var productos = conexion.Query<Models.producto>(SQL);

            return productos;
        }

        public Models.producto GetProducto(int cod_producto)
        {
            string SQL = "select * from producto where cod_producto = " + cod_producto;
            conexion.Open();
            var productos = conexion.QueryFirst<Models.producto>(SQL);

            return productos;
        }

        public IEnumerable<Models.cliente> GetCliente()
        {
            string SQL = "select * from cliente";
            conexion.Open();
            var cliente = conexion.Query<Models.cliente>(SQL);

            return cliente;
        }


        public IEnumerable<Models.metodo_pago> GetMetodoPago()
        {
            string SQL = "select * from metodo_pago";
            conexion.Open();
            var metodo_pago = conexion.Query<Models.metodo_pago>(SQL);

            return metodo_pago;
        }

        public bool ModificarProducto(Models.producto _producto, int cod_producto)
        {
            try
            {
                this.conexion.Open();

                string sql = "UPDATE producto SET descripcion=@descripcion, tipo=@tipo, color=@color, precio=@precio WHERE cod_producto = " + cod_producto;

     
                var arguments = new
                {
                    id = _producto.cod_producto,
                    descripcion = _producto.descripcion,
                    tipo = _producto.tipo,
                    color = _producto.color,
                    precio = _producto.precio,
                };

                conexion.Execute(sql, arguments);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EliminarProducto(int cod_producto)
        {
            try
            {
                string SQL = "DELETE FROM producto WHERE cod_producto = " + cod_producto;
                conexion.Execute(SQL);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}
