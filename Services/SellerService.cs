using e_commerce.API.Entities;
using e_commerce.API.Repository.Interface;
using e_commerce.API.Services.Interface;

namespace e_commerce.API.Services
{
    public class SellerService : ISellerService
    {
        private readonly ISellerReposetory _repo;
        public SellerService(ISellerReposetory repo)
        {
            _repo = repo;
        }

        public void AddSeller(Seller seller)
        {
            _repo.AddSeller(seller);
        }

        public List<Seller> GetAll()
        {
            return _repo.GetAll();
        }

        public Seller GetSellerById(int id)
        {
            return _repo.GetSellerById(id);
        }

        public Seller GetSellerByName(string userName,string password)
        {
            return _repo.GetSellerByName(userName, password);
        }

        public void UpdateSeller(int id, Seller seller)
        {
            _repo.UpdateSeller(id, seller);
        }
    }
}
