using console_product_manager.Models;

namespace console_product_manager.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> _productos;
        
        public ProductRepository()
        {
            _productos = new List<Product>
            {
                new Product { Id = 1, Nombre = "Teclado", Precio = 25000m, Categoria = "Electrónica", Activo = true },
                new Product { Id = 2, Nombre = "Mouse", Precio = 15000m, Categoria = "Electrónica", Activo = true },
                new Product { Id = 3, Nombre = "Lámpara", Precio = 30000m, Categoria = "Hogar", Activo = true },
                new Product { Id = 4, Nombre = "Cuaderno", Precio = 5000m, Categoria = "Librería", Activo = true }
            };
        }

        public void Agregar(Product producto)
        {
            _productos.Add(producto);
        }

        public List<Product> ObtenerTodos()
        {
            return _productos;
        }

        public Product? ObtenerPorId(int id)
        {
            var prod = _productos.FirstOrDefault(p => p.Id == id);
            return prod;
        }

        public List<Product> BuscarPorCategoria(string categoria)
        {
            return _productos.Where(p => p.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
