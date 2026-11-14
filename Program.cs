class Program
{
    static void Main()
    {
        List<string> productos = new List<string>();
        int elecciones = -1;

        while (elecciones != 0)
        {
            Console.WriteLine("--- Inventario ---");
            Console.WriteLine("1: Agregar un producto");
            Console.WriteLine("2: Mostrar todos los productos");
            Console.WriteLine("3: Buscar un producto");
            Console.WriteLine("4: Modificar un producto");
            Console.WriteLine("5: Eliminar un producto");
            Console.WriteLine("6: Mostra estadisticas");
            Console.WriteLine("7: Ordenar la lista");
            Console.WriteLine("0: Salir...");

            Console.Write("Elige una opción: ");
            elecciones = int.Parse(Console.ReadLine());

            switch (elecciones)
            {
                case 1:
                    Console.Write("Nombre del producto: ");
                    string nombre = Console.ReadLine();
                    productos.Add(nombre);
                    Console.WriteLine("Producto agregado");
                    break;

                case 2:
                    for (int i = 0; i < productos.Count; i++)
                    {
                        Console.WriteLine(productos[i]);
                    }
                    break;

                case 3:
                    Console.Write("¿Qué producto deseas buscar? ");
                    string buscar = Console.ReadLine();
                    if (productos.Contains(buscar))
                    {
                        Console.WriteLine("Producto encontrado");
                    }
                    else
                    {
                        Console.WriteLine("Producto no encontrado");
                    }
                    break;

                case 4:
                    Console.Write("¿Qué producto deseas modificar? ");
                    buscar = Console.ReadLine();

                    int posicion = productos.IndexOf(buscar);

                    if (posicion != -1)
                    {
                        Console.Write("Introduce el nuevo nombre: ");
                        string nuevoNombre = Console.ReadLine();

                        productos[posicion] = nuevoNombre;

                        Console.WriteLine("Producto modificado correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("Producto no encontrado.");
                    }
                    break;

                case 5:

                    string borrar = Console.ReadLine();

                    if (productos.Remove(borrar))
                    {
                        Console.WriteLine("Producto eliminado continue estimadado :)");
                    }
                    else
                    {
                        Console.WriteLine("Producto no encontrado me lo confirmo miami :)");
                    }

                    break;

                case 6:

                    break;

                case 7:
                    productos.Sort();

                    foreach (string producto in productos)
                    {
                        Console.WriteLine(producto);
                    }

                    break;


                case 0:
                    Console.WriteLine("Saliendo del menú...");
                    break;

                default:
                    Console.WriteLine("Opción incorrecta.");
                    break;
            }
        }
    }
}