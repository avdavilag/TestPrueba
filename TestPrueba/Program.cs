// See https://aka.ms/new-console-template for more information
using TestPrueba;
Console.WriteLine("Welcome to Tienda Virtual!");
Console.WriteLine(new string('*',100));

var repositorioProducto = new RepositorioProductos();

while (!string.IsNullOrWhiteSpace("opcion"))
{

	Console.WriteLine("Seleccion una opcion");
	Console.WriteLine("1. Agrega un producto");
	Console.WriteLine("2. Editar un producto");
	Console.WriteLine("3. Eliminar un producto");
	Console.WriteLine("4. Mostrar un producto");
    Console.WriteLine("5. Mostrar lista de Productos");
    Console.WriteLine("6. Salir");
	Console.WriteLine("----------------------");
	var opcion = Console.ReadLine();

	switch (opcion)
	{

		case "1":
			var producto = new Productos
			{
				Nombre = Console.ReadLine()!
			};
			Console.WriteLine("Precio Producto");
			if (double.TryParse(Console.ReadLine(), out double precio))
			{
				producto.Precio = precio;
			}
			else
				producto.Precio = 100;
			Console.WriteLine("Descripcion para el producto");
			producto.Descripcion = Console.ReadLine() ?? string.Empty;
			Console.WriteLine("Se agrego el producto {Enviroment.NewLine}");
			repositorioProducto.Agregar(producto);
			repositorioProducto.Mostrar_Productos();
			break;

		case "2":
			Console.WriteLine("Edicion de un producto");
			Console.WriteLine("Ingrese el codigo a editar");
			var codigo = Console.ReadLine() ?? string.Empty;
			var productoEncontrador = repositorioProducto.BuscarxCodigo(codigo);
			if (productoEncontrador is not null)
			{
				Console.WriteLine("Nuevo nombre: ");
				productoEncontrador.Nombre = Console.ReadLine()!;
				Console.WriteLine("Nuevo precio: ");
				productoEncontrador.Precio = double.Parse(Console.ReadLine()!);
				Console.WriteLine("Descripcion Nueva");
				productoEncontrador.Descripcion = Console.ReadLine();
				Console.WriteLine("Dimensiones: (largo,ancho,alto)");
				double largo, ancho, alto;
				if (double.TryParse(Console.ReadLine(), out largo) &&
					double.TryParse(Console.ReadLine(), out ancho) &&
					double.TryParse(Console.ReadLine(), out alto))
				{
					productoEncontrador.Dimensiones = new Dimensiones(largo, ancho, alto);
				}
				Console.WriteLine("Producto Digitar (s/[n]: ");
				var respuesta = Console.ReadLine();
				productoEncontrador.TipoMercaderia = respuesta?.ToLower() == "s" ? TipoMercaderia.ProductoDigital : TipoMercaderia.ProductoFisico;

				Console.WriteLine("Tipo de producto (1 - Producto / 2 - Servicio): ");
				if (int.TryParse(Console.ReadLine(), out var tipoProducto))
				{
					productoEncontrador.TipoProducto = (TipoProducto)tipoProducto;
				}

				repositorioProducto.Editar(codigo, productoEncontrador);
			}
			else
			{
				Console.WriteLine("No se encontro el producto");
			}
			repositorioProducto.Mostrar_Productos();
			break;
		case "3":
			Console.WriteLine("Eliminar un producto");
			Console.WriteLine("Ingrese el codigo a eliminar");
			var codigoEliminar = Console.ReadLine() ?? string.Empty;
			repositorioProducto.Eliminar(codigoEliminar);
			Console.WriteLine("Producto eliminado Correctamente");
			 break;
		case "4":
			Console.WriteLine("Mostrar un producto");
			Console.WriteLine("Ingresa el codigo de producto a consultar");
			var codigoConsulta= Console.ReadLine() ?? string.Empty;
			var productoConsulta = repositorioProducto.BuscarxCodigo(codigoConsulta);
			Console.WriteLine("Producto que estas consultando es: "+productoConsulta.Descripcion);
            break;
		case "5":
			Console.WriteLine("Muestra la lsita de productos");
			repositorioProducto.Mostrar_Productos();
			Console.WriteLine("--------------------------------");
			break;
			default:
			Console.WriteLine("Gracias por su visita...");
            break;
    }

}
