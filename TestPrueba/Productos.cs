using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPrueba
{
    public class Productos
    {
        private string _codigo = default;
        private double _precio;
        public string Codigo
        {
            get
            {
                Console.WriteLine("Se esta esytrayendo un codigo");
                return _codigo;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    _codigo = "0000";

            }
        }
        public required string Nombre { get; set; } = default!;

        public double Precio { get; set; }
        public string? Descripcion { get; set; }

    }
}



