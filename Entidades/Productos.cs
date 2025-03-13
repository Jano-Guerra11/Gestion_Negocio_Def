using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Productos
    {
        private int idProducto_pr;
        private string nombre_pr;
        private int? idSeccion_pr;
        private string descripcion_pr;
        private float precio_pr;
        private int stock_pr;
        private bool activo_pr;
        private string urlImagen_pr;

        public Productos(int idProducto = -1, string nombre = "predeterminado",
                      int? idSeccion = -1, string descripcion = "predeterminada",
                      float precio = -1, int stock = -1, bool activo = false, string urlImagen_pr = null)
        {
            this.idProducto_pr = idProducto;
            this.nombre_pr = nombre;
            this.idSeccion_pr = idSeccion;
            this.descripcion_pr = descripcion;
            this.precio_pr = precio;
            this.stock_pr = stock;
            this.activo_pr = activo;
            this.UrlImagen_pr = urlImagen_pr;
        }
        public int IdProducto_pr { get => idProducto_pr; set => idProducto_pr = value; }
        public string Nombre_pr { get => nombre_pr; set => nombre_pr = value; }
        public int? IdSeccion_pr { get => idSeccion_pr; set => idSeccion_pr = value; }
        public string Descripcion_pr { get => descripcion_pr; set => descripcion_pr = value; }
        public float Precio_pr { get => precio_pr; set => precio_pr = value; }
        public int Stock_pr { get => stock_pr; set => stock_pr = value; }
        public bool Activo_pr { get => activo_pr; set => activo_pr = value; }
        public string UrlImagen_pr { get => urlImagen_pr; set => urlImagen_pr = value; }
    }
}
