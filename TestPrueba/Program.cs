// See https://aka.ms/new-console-template for more information
using TestPrueba;
Console.WriteLine("Welcome to Tienda Virtual!");
Console.WriteLine(new string('*',100));

var almacen = new Almacen();

while (almacen.Count() < 10)
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
	almacen.Agregar(producto);
    }

almacen.Mostrar_Productos();
Console.WriteLine("Edicion de un producto");
Console.WriteLine("Ingrese el codigo a editar");
var codigo=Console.ReadLine() ?? string.Empty;
Console.WriteLine("Ingrese el nuevo nombre");
almacen.Editar(codigo, Console.ReadLine() ?? string.Empty);

Console.WriteLine("Ingrese el nuevo precio: ");
if(double.TryParse(Console.ReadLine(), out double precioEdit))
{
	almacen.Editar(codigo, precioEdit);
}

almacen.Mostrar_Productos();


