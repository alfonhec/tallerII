namespace APIalquiler.Models
{
    public class producto
    {
        public int cod_producto { get; }
        public string descripcion { get; set; }
        public string tipo { get; set; }
        public string color { get; set; }
        public float precio { get; set; }
    }
}
