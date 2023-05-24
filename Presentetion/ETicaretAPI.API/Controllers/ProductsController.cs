using ETicaretAPI.Domain.Entities;
using ETİcaretAPI.Application.Abstactions;
using ETİcaretAPI.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly IProductWriteRepository _productWriteRepository;
        readonly IProductReadRepository _productReadRepository;
        readonly private IOrderWriteRepository _orderWriteRepository; //ıoc den atelp ettik addli bişeydi public productcontorller falan geldi alttaki
        readonly private ICustomerWriteRepository _customerWriteRepository;
        readonly private IOrderReadRepository _orderReadRepository;
        public ProductsController(
            IProductWriteRepository productWriteRepository,
            IProductReadRepository productReadRepository,
            IOrderWriteRepository orderWriteRepository,
            ICustomerWriteRepository customerWriteRepository,
            IOrderReadRepository orderReadRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _orderWriteRepository = orderWriteRepository;
            _customerWriteRepository = customerWriteRepository;
            _orderReadRepository = orderReadRepository;
        }
        [HttpGet]
        public async Task Get()
        {

            //Order order = await _orderReadRepository.GetByIdAsync(Guid.Parse()); // benim database çalışmadığı için oluşturulan ıdyi basamıyorum
            //order.Address = "Ankara";
            //await _orderWriteRepository.SaveAsync();

            #region Tekrar Test
            //var customerId = Guid.NewGuid();
            //await _customerWriteRepository.AddAsync(new() {Id =  customerId, Name = "Melcegm"  });
            //await _orderWriteRepository.AddAsync(new() { Description = "tanım", Address = "Samsun", });
            //await _orderWriteRepository.AddAsync(new() { Description = "tanım2", Address = "İstanbul", });
            //await _orderWriteRepository.SaveAsync();
            #endregion

            #region
            //await _productWriteRepository.AddAsync(new() { Name = "C Product", Price = 1.500F, Stock = 10, DateTime = DateTime.UtcNow });
            //await _productWriteRepository.SaveAsync();
            #endregion

            
             await _productWriteRepository.AddRangeAsync(new()
             {
                 new(){ Id = Guid.NewGuid(), Name = "Product1", Price = 100, DateTime = DateTime.UtcNow , Stock = 10},
                 new(){ Id = Guid.NewGuid(), Name = "Product2", Price = 200, DateTime = DateTime.UtcNow , Stock = 20},
                 new(){ Id = Guid.NewGuid(), Name = "Product3", Price = 300, DateTime = DateTime.UtcNow , Stock = 30}
             });
            await _productWriteRepository.SaveAsync(); //burada kaldık yorumlarda task yazınca düzelecek dediler ama taski nereye yazacağımı bilmediğimden bırakıyorum
            
        }




        //[HttpGet("{id}")] // id ye göre get
        //public async Task<IActionResult> Get(string id)
        //{
        //    Product product = await _productReadRepository.GetByIdAsync(id);
        //    return Ok(product);
        //}




    }
}
