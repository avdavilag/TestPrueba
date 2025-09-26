using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPrueba
{
    public class Almacen
    {
       public List<Productos> Productos { get; set; }
        public Almacen()
        {
            Productos = new List<Productos>();
        }
    }
}
