using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPrueba
{
    public class Productos
    {
        private string _codigo = default!;
        private double _precio;
        public string Codigo
        {
            get => _codigo;
             set
            {
                if (!string.IsNullOrEmpty(value))
                    _codigo = value;
                else
                {
                    _codigo = "0000";
                }                   
            }
        }
        public required string Nombre { get; set; } = default!;
        public double Precio { get; set; }
        public string? Descripcion { get; set; }
        public TipoMercaderia TipoMercaderia { get; set; }
        public TipoProducto TipoProducto { get; set; }
        public Dimensiones? Dimensiones { get; set; }

    }
}

public enum TipoMercaderia
{
    ProductoFisico,
    ProductoDigital
}
public enum TipoProducto
{
    Producto,
    Servicio
}

public struct Dimensiones
{
    public double Alto { get; set; }
    public double Ancho { get; set; }
    public double Profundidad { get; set; }

    public Dimensiones(double alto, double ancho, double profundidad)
    {
        Alto = alto;
        Ancho = ancho;
        Profundidad = profundidad;
    }
}

