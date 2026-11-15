class Program
{
    static void Main()
    {
        List<string> productos = new List<string>();
        List<double> precios = new List<double>();
        int elecciones = -1;

        while (elecciones != 0)
        {
            /*El menu se repite hasta que el usuario decida salir al menos que sea error de capa 8 y nunca salga*/
            Console.WriteLine("Inventario");
            Console.WriteLine("1: Agregar un producto");
            Console.WriteLine("2: Mostrar todos los productos");
            Console.WriteLine("3: Buscar un producto");
            Console.WriteLine("4: Modificar un producto");
            Console.WriteLine("5: Eliminar un producto");
            Console.WriteLine("6: Mostrar estadisticas");
            Console.WriteLine("7: Ordenar la lista");
            Console.WriteLine("0: Salir");

            Console.Write("Elige una opcion: ");

            if (!int.TryParse(Console.ReadLine(), out elecciones))
            {
                Console.WriteLine("Esta opcion es invalida");
                elecciones = -1;
                continue;
            }

            switch (elecciones)
            {
                case 1:
                    AgregarProducto(productos, precios);
                    break;

                case 2:
                    MostrarProductos(productos, precios);
                    break;

                case 3:
                    BuscarProducto(productos, precios);
                    break;

                case 4:
                    ModificarProducto(productos, precios);
                    break;

                case 5:
                    EliminarProducto(productos, precios);
                    break;

                case 6:
                    MostrarEstadisticas(productos, precios);
                    break;

                case 7:
                    OrdenarLista(productos, precios);
                    break;

                case 0:
                    Console.WriteLine("Saliendo del menu..");
                    break;

                default:
                    Console.WriteLine("Opcion incorrecta");
                    break;
            }
        }
    }

    static void AgregarProducto(List<string> productos, List<double> precios)
    {
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("Precio: ");

        if (!string.IsNullOrWhiteSpace(nombre) && double.TryParse(Console.ReadLine(), out double precio) && precio >= 0)
        {
            productos.Add(nombre);
            precios.Add(precio);

            Console.WriteLine("Producto agregado");
        }
        else
            Console.WriteLine("Datos invaidos");
        // Guardamos el producto junto con su precio para asi no complicanos la vida :)
    }

    static void MostrarProductos(List<string> productos, List<double> precios)
    {
        if (productos.Count > 0)
        {
            for (int i = 0; i < productos.Count; i++)
            {
                Console.WriteLine($"{productos[i]} - RD${precios[i]}");
            }
        }
        else
            Console.WriteLine("No hay productos registrados");
    }

    static void BuscarProducto(List<string> productos, List<double> precios)
    {
        if (productos.Count == 0)
        {
            Console.WriteLine("No hay productos registrados.");
            return;
        }

        Console.Write("Que producto buscar: ");
        string buscar = Console.ReadLine();

        int posicion = productos.IndexOf(buscar);

        if (posicion != -1)
        {
            Console.WriteLine($"Producto encontrado: {productos[posicion]} - RD${precios[posicion]}");
        }
        else
            Console.WriteLine("Producto no encontrado");
    }

    static void ModificarProducto(List<string> productos, List<double> precios)
    {
        Console.Write("Que producto deseas modificar? ");
        string buscar = Console.ReadLine();

        int posicion = productos.IndexOf(buscar);

        if (posicion != -1)
        {
            Console.Write("Nuevo nombre: ");
            string nuevoNombre = Console.ReadLine();

            Console.Write("Nuevo precio: ");

            if (!string.IsNullOrWhiteSpace(nuevoNombre) && double.TryParse(Console.ReadLine(), out double nuevoPrecio) && nuevoPrecio >= 0)
            {
                productos[posicion] = nuevoNombre;
                precios[posicion] = nuevoPrecio;

                Console.WriteLine("Producto modificado.");
            }
            else
                Console.WriteLine("Datos inválidos.");
        }
        else
            Console.WriteLine("Producto no encontrado.");
    }

    static void EliminarProducto(List<string> productos, List<double> precios)
    {
        Console.Write("Que producto deseas eliminar? ");
        string borrar = Console.ReadLine();

        int posicion = productos.IndexOf(borrar); 

        if (posicion != -1)
        {
            productos.RemoveAt(posicion);
            precios.RemoveAt(posicion);

            Console.WriteLine("Producto eliminado.");
        }
        else
            Console.WriteLine("Producto no encontrado.");
    }

    static void MostrarEstadisticas(List<string> productos, List<double> precios)
    {
        if (precios.Count > 0 && productos.Count == precios.Count)
        {
            Console.WriteLine(" <- Estadísticas -> ");
            Console.WriteLine($"Total de productos: {productos.Count}");
            Console.WriteLine($"Precio mayor: RD${precios.Max()}");
            Console.WriteLine($"Precio menor: RD${precios.Min()}");
            Console.WriteLine($"Precio promedio: RD${precios.Average():F2}");
        }
        else
            Console.WriteLine("No hay productos registrados");
    }

    static void OrdenarLista(List<string> productos, List<double> precios)
    {
        for (int i = 0; i < productos.Count - 1; i++)
        {
            for (int j = i + 1; j < productos.Count; j++)
            {
                if (string.Compare(productos[i], productos[j],
                    StringComparison.OrdinalIgnoreCase) > 0)
                {
                    string tempProducto = productos[i];
                    productos[i] = productos[j];
                    productos[j] = tempProducto;

                    double tempPrecio = precios[i];
                    precios[i] = precios[j];
                    precios[j] = tempPrecio;
                }
            }
        }

        Console.WriteLine("Inventario ordenado");
        MostrarProductos(productos, precios);
    }
}