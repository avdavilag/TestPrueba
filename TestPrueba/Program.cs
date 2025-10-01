// See https://aka.ms/new-console-template for more information
using TestPrueba;
Console.WriteLine("Welcome to Tienda Virtual!");
Console.WriteLine(new string('*',100));

var repositorioProducto = new RepositorioProductos();

while (repositorioProducto.Count() < 10)
{
	Console.WriteLine("Ingrese el valor para el producto");
    Console.WriteLine("Nombre del producto");
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
    }

repositorioProducto.Mostrar_Productos();
Console.WriteLine("Edicion de un producto");
Console.WriteLine("Ingrese el codigo a editar");
var codigo=Console.ReadLine() ?? string.Empty;

//Console.WriteLine("Ingrese el nuevo nombre");
//almacen.Editar(codigo, Console.ReadLine() ?? string.Empty);

//Console.WriteLine("Ingrese el nuevo precio: ");
//if(double.TryParse(Console.ReadLine(), out double precioEdit))
//{
//	almacen.Editar(codigo, precioEdit);
//}

var productoEncontrador=repositorioProducto.BuscarxCodigo(codigo);
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
	if(int.TryParse(Console.ReadLine(), out var tipoProducto))
	{
		productoEncontrador.TipoProducto = (TipoProducto)tipoProducto;
    }

    repositorioProducto.Editar(codigo,productoEncontrador);
}
else
{
	Console.WriteLine("No se encontro el producto");
}
repositorioProducto.Mostrar_Productos();


