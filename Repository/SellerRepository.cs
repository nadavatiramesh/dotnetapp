using e_commerce.API.Entities;
using e_commerce.API.Repository.Interface;

namespace e_commerce.API.Repository
{
    public class SellerRepository : ISellerReposetory
    {
        private ECommerceContext _context;
        public SellerRepository(ECommerceContext context)
        {
            _context = context;
        }
        public void AddSeller(Seller seller)
        {
            seller.SellerId = _context.Sellers.Max(e => e.SellerId) + 1;
           _context.Sellers.Add(seller);
            _context.SaveChanges();
        }

        public List<Seller> GetAll()
        {
            return _context.Sellers.ToList();
        }

        public Seller GetSellerById(int id)
        {
            return _context.Sellers.FirstOrDefault(e => e.SellerId == id);
        }

        public Seller GetSellerByName(string userName,string password)
        {
            return _context.Sellers.FirstOrDefault(e => e.UserName.Equals(userName) && e.Passcode.Equals(password));
        }

        public void UpdateSeller(int id, Seller seller)
        {
            throw new NotImplementedException();
        }
    }
}
