using console_product_manager.Models;
using console_product_manager.Repositories;

IProductRepository productRepository = new ProductRepository();

while (true)
{
    Console.WriteLine("Seleccione una opción:");
    Console.WriteLine("1. Agregar producto");
    Console.WriteLine("2. Listar productos");
    Console.WriteLine("3. Buscar producto por ID");
    Console.WriteLine("4. Buscar productos por categoría");
    Console.WriteLine("5. Salir");

    var opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            try
            {
                var producto = new Product();
                Console.Write("Ingrese el ID del producto: ");
                producto.Id = int.Parse(Console.ReadLine() ?? "0");
                Console.Write("Ingrese el nombre del producto: ");
                producto.Nombre = Console.ReadLine() ?? string.Empty;
                Console.Write("Ingrese el precio del producto: ");
                producto.Precio = decimal.Parse(Console.ReadLine() ?? "0");
                Console.Write("Ingrese la categoría del producto: ");
                producto.Categoria = Console.ReadLine() ?? string.Empty;
                productRepository.Agregar(producto);
                break;
            } catch (FormatException)
            {
                Console.WriteLine("Entrada inválida. Por favor, ingrese los datos correctamente.");
                break;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Número demasiado grande. Por favor, ingrese un valor válido.");
                break;
            }
        case "2":
            productRepository.ObtenerTodos().ForEach(p =>
            {
                Console.WriteLine($"ID: {p.Id}, Nombre: {p.Nombre}, Precio: {p.Precio}, Categoría: {p.Categoria}");
            });
            break;
        case "3":
            Console.Write("Ingrese el ID del producto a buscar: ");
            try
            {
                var productId = int.Parse(Console.ReadLine() ?? "0");
                var foundProduct = productRepository.ObtenerPorId(productId);
                if (foundProduct != null)
                {
                    Console.WriteLine($"ID: {foundProduct.Id}, Nombre: {foundProduct.Nombre}, Precio: {foundProduct.Precio}, Categoría: {foundProduct.Categoria}");
                }
                else
                {
                    Console.WriteLine($"Producto con ID {productId} no encontrado.");
                }
                break;
            } catch (FormatException)
            {
                Console.WriteLine("ID inválido. Por favor, ingrese un número entero.");
                break;
            }
            catch (OverflowException)
            {
                Console.WriteLine("ID demasiado grande. Por favor, ingrese un número entero válido.");
                break;
            }
        case "4":
            Console.Write("Ingrese la categoría a buscar: ");
            var categoria = Console.ReadLine() ?? string.Empty;
            var productosPorCategoria = productRepository.BuscarPorCategoria(categoria);
            productosPorCategoria.ForEach(p =>
            {
                Console.WriteLine($"ID: {p.Id}, Nombre: {p.Nombre}, Precio: {p.Precio}, Categoría: {p.Categoria}");
            });
            break;
        case "5":
            return;
        default:
            Console.WriteLine("Opción no válida.");
            break;
    }
}