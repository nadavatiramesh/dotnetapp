using e_commerce.API.Entities;

namespace e_commerce.API.Services.Interface
{
    public interface IProductService
    {
        public void AddProduct(Product product);
        public Product UpdateProduct(int id,Product product);
        public Product DeleteProduct(int id);
        public Product GetProductById(int id);
        public Product GetProductByName(string name);
        public List<Product> GetAll();
    }
}
