using e_commerce.API.Entities;

namespace e_commerce.API.Services.Interface
{
    public interface ISellerService
    {
        public void AddSeller(Seller seller);
        public void UpdateSeller(int id, Seller seller);
        public Seller GetSellerById(int id);
        public Seller GetSellerByName(string userName,string password);
        public List<Seller> GetAll();
    }
}
