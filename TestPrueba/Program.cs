// See https://aka.ms/new-console-template for more information
using TestPrueba;
Console.WriteLine("Welcome to Tienda Virtual!");
Console.WriteLine(new string('*',100));

var almacen = new Almacen();

while (almacen.Productos.Count < 3)
{
	Console.WriteLine("Ingrese el valor para el producto");

	var producto = new Productos
	{
		Nombre = Console.ReadLine()!
	};
	Console.WriteLine("Ingrese el codigo para el producto");
	producto.Codigo = Console.ReadLine() ?? string.Empty;
	Console.WriteLine("Ingrese el precio para el producto");
    if (double.TryParse(Console.ReadLine(), out double precio))
	{
		producto.Precio = precio;
	}
	else
    producto.Precio = 100;

	Console.WriteLine("Ingrese la descripcion para el producto");
	producto.Descripcion = Console.ReadLine() ?? string.Empty;


    Console.WriteLine("Se agrego el producto");
	almacen.Productos.Add(producto);
	Console.WriteLine("Codigo: {0} | Nombre: {1} | Precio: {2} | Descripcion: {3}", producto.Codigo, producto.Nombre, producto.Precio, producto.Descripcion);
}
jkhkh
Console.WriteLine("CODIGO | NOMBRE | PRECIO | DESCRIPCION");
foreach (var prod in almacen.Productos)
{
	Console.WriteLine($"| {prod.Codigo} | {prod.Nombre} | {prod.Precio:N2} | {prod.Descripcion}	");
}
Console.WriteLine(new string ('-',70));
Console.WriteLine($"Elementos agregados al almacen: {almacen.Productos.Count}");


