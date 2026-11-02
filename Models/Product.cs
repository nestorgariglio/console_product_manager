namespace console_product_manager.Models
{
    public class Product
    {
        public int Id {get; set;}
        public string Nombre {get; set;} = string.Empty;
        public decimal Precio {get; set;}
        public string Categoria {get; set;} = string.Empty;
        public bool Activo {get; set;} = true;
    }
}