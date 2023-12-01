using e_commerce.API.Entities;
using e_commerce.API.Models;
using e_commerce.API.Services.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace e_commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly ISellerService _service;

        public SellerController(ISellerService service)
        {
            _service = service;
        }
        // GET: api/<SellerController>
        [HttpGet]
        public IActionResult Get()
        {
            var sellerList = _service.GetAll();
            if (sellerList == null)
            {
                return Ok(Enumerable.Empty<SellerModel>());
            }
            else
            {
                var model = new List<SellerModel>();
                sellerList.ForEach(seller =>
                {
                    model.Add(new SellerModel()
                    {
                        Email = seller.Email,
                        Mobile = seller.Mobile,
                        SellerId = seller.SellerId,
                        SellerName = $"{seller.FirstName} {seller.LastName}"
                    });
                });
                return Ok(model);
            }
        }

        // GET api/<SellerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
            {
                return BadRequest(new { message = "Invalid SellerId" });
            }

            var seller = _service.GetSellerById(id);
            if (seller == null)
            {
                return Ok(new SellerModel());
            }
            else
            {
                return Ok(new SellerModel()
                {
                    Email = seller.Email,
                    Mobile = seller.Mobile,
                    SellerId = seller.SellerId,
                    SellerName = $"{seller.FirstName} {seller.LastName}"
                });
            }
        }

        // POST api/<SellerController>
        [HttpPost]
        public IActionResult Post([FromBody] AddSellerModel seller)
        {
            if (seller == null)
            {
                return BadRequest(new { message = "Invalid/empty request" });
            }

            var entity = new Seller()
            {
                CreatedBy = "me",
                CreatedOn = DateTime.Now,
                Email = seller.Email,
                FirstName = seller.FirstName,
                LastName = seller.LastName,
                Passcode = seller.Passcode,
                Mobile = seller.Mobile,
                UserName = seller.UserName
            };
            _service.AddSeller(entity);
            return Created("seller", entity);
        }


        [HttpGet("/Login")]
        public IActionResult SellerLogin(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(password))
            {
                return BadRequest(new { message = "Invalid Credentials, please try again with correct values" });
            }

            var seller = _service.GetSellerByName(userName, password);
            if (seller == null)
            {
                return NotFound();
            }
            return Ok(new SellerModel()
            {
                Email = seller.Email,
                Mobile = seller.Mobile,
                SellerId = seller.SellerId,
                SellerName = $"{seller.FirstName} {seller.LastName}"
            });
        }
    }
}
