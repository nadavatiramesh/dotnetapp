using e_commerce.API.Entities;

namespace e_commerce.API.Repository.Interface
{
    public interface IProductRepository
    {
        public void AddProduct(Product product);
        public Product UpdateProduct(int id, Product product);
        public void DeleteProduct(Product product);
        public Product GetProductById(int id);
        public Product GetProductByName(string name);
        public List<Product> GetAll();
    }
}
