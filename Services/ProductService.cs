using e_commerce.API.Entities;
using e_commerce.API.Repository.Interface;
using e_commerce.API.Services.Interface;

namespace e_commerce.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
             _repository = repository;
        }
        public void AddProduct(Product product)
        {
           _repository.AddProduct(product);
        }

        public Product DeleteProduct(int id)
        {
            if(id > 0)
            {
                var product = _repository.GetProductById(id);
                _repository.DeleteProduct(product);
                return product;
            }
            return null;
        }

        public List<Product> GetAll()
        {
            return _repository.GetAll();
        }

        public Product GetProductById(int id)
        {
            return _repository.GetProductById(id);
        }

        public Product GetProductByName(string name)
        {
            return _repository.GetProductByName(name);
        }

        public Product UpdateProduct(int id,Product product)
        {
           return _repository.UpdateProduct(id,product);
        }
    }
}
