using e_commerce.API.Entities;
using e_commerce.API.Repository.Interface;

namespace e_commerce.API.Repository
{
    public class ProductRepository : IProductRepository
    {
        private ECommerceContext _context;
        public ProductRepository(ECommerceContext context)
        {
            _context = context;
        }
        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(e => e.ProductId == id);
        }

        public Product GetProductByName(string name)
        {
            return _context.Products.FirstOrDefault(e => e.Name.Equals(name));
        }

        public Product UpdateProduct(int id, Product product)
        {
            var upd = _context.Products.FirstOrDefault(e => e.ProductId == id);
            if (upd != null)
            {
                upd.Name = !string.IsNullOrWhiteSpace(product.Name) ? product.Name : upd.Name;
                upd.Description = product.Description ?? upd.Description;
                upd.Price = product.Price > 0 ? upd.Price : product.Price;
                upd.Category = product.Category ?? upd.Category;
                upd.ActualCost = product.ActualCost > 0 ? product.ActualCost : upd.ActualCost;
                upd.Price = product.Price > 0 ? product.Price : upd.Price;
                upd.ImageLink = product.ImageLink ?? upd.ImageLink;
                upd.UpdatedBy = product.UpdatedBy;
                _context.Products.Update(upd);
                _context.SaveChanges();
            }
            return upd;
        }
    }
}
