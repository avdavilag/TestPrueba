using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPrueba
{
    public class RepositorioProductos
    {
        public delegate void OnRegistroEliminadoDelegate();
        public delegate void OnRegistroEliminado2(string codigo);


        public event OnRegistroEliminadoDelegate? OnRegistroEliminadoEvent;
        public event OnRegistroEliminado2? OnDelete;

        public event Action? OnRegsitroAgregadoEvent;
        public event Action<Productos>? OnRegistroActualizadoEvent;

        public readonly List<Productos> _productos;
        public RepositorioProductos()
        {
            _productos = new List<Productos>();
            for(int i = 0; i < 10; i++)
            {
                var producto= new Productos {
                    Codigo = (i + 1).ToString("D4"),
                    Nombre = $"Producto {i + 1}",
                    Precio = 100 * (i + 1),
                };
                _productos.Add(producto);
            }
        }

        public void Agregar(Productos producto)
        {
            var codigo = (_productos.Count +1).ToString("000#");
            producto.Codigo = codigo;
            _productos.Add(producto);
            OnRegsitroAgregadoEvent?.Invoke();
        }

        public void Editar(string codigo, string nombre)
        {
            bool existe = false;
            
            foreach (var prod in _productos)
            {
                if (prod.Codigo == codigo)
                {
                     prod.Nombre = nombre;
                    existe = true;
                    break;                                       
                }
            }

            if (!existe)
            {
                Console.WriteLine($"No se encontro el producto con el codigo {codigo}");
            }   
        }

        public void Editar(string codigo, double precio)
        {
            var producto = _productos.FirstOrDefault(p => p.Codigo == codigo);
            if(producto is not null)
                producto!.Precio = precio;
            else
            {
                Console.WriteLine("No se encontro el producto el producto con el codigo {codigo}");
            }
        }
        
        public void Editar(string codigo, Productos producto)
        {
            var registro=_productos.FirstOrDefault(p => p.Codigo == codigo);
            if(registro is not null)
            {
                registro.Nombre = producto.Nombre;
                registro.Precio = producto.Precio;
                registro.Descripcion = producto.Descripcion;
                registro.TipoMercaderia = producto.TipoMercaderia;
                registro.Dimensiones = producto.Dimensiones;
                
                OnRegistroActualizadoEvent?.Invoke(registro);
            }
            else
            {
                Console.WriteLine("No se encontro el producto el producto con el codigo {codigo}");
            }
        }

        public void Eliminar (string eliminar)
        {
            var registro = _productos.FirstOrDefault(p => p.Codigo == eliminar);
            if (registro is not null)
            {
                _productos.Remove(registro);
                ///Invocamos al eventop que origina esta accion
                 OnRegistroEliminadoEvent?.Invoke();
                OnDelete?.Invoke(eliminar);
            }
            else
            {
                Console.WriteLine("No se encontro el producto el producto con el codigo {eliminar}");
            }
        }
        public int Count() => _productos.Count;    
        public List<Productos> Listar => _productos.OrderBy(p=>p.Codigo).ToList();
    
        public Productos? BuscarxCodigo(string codigo) => _productos.FirstOrDefault(p => p.Codigo == codigo);   

        public void Mostrar_Productos()
        {
            Console.WriteLine("CODIGO | NOMBRE | PRECIO | DESCRIPCION | TIPO | PROD/SEV | DIMENSIONES ");
            foreach (var prod in _productos)
            {
                Console.WriteLine($"| {prod.Codigo} | {prod.Nombre} | {prod.Precio:N2} | {prod.Descripcion}	| {prod.TipoProducto} | {prod.TipoMercaderia} | {prod.Dimensiones}");
            }
            Console.WriteLine(new string('-', 70));
            Console.WriteLine($"Elementos agregados al almacen: {Count()}");
        }
    }
}