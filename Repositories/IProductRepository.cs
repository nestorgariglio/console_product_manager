using console_product_manager.Models;

namespace console_product_manager.Repositories
{
    public interface IProductRepository
    {
        void Agregar(Product producto);
        List<Product> ObtenerTodos();
        Product? ObtenerPorId(int id);
        List<Product> BuscarPorCategoria(string categoria);
    }
}