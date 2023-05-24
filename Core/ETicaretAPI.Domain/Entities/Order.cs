using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETicaretAPI.Domain.Entities
{
    public class Order: BaseEntity
    {
        [ForeignKey(nameof(Order))]
        public int CustomerId { get; set; } // costomer a ıd verıyor normalde default, ama biz kendımız yonetmek için kendımız yazdık
        public string Description { get; set; }
        public string Address { get; set; }
        public ICollection<Product> Products { get; set; } // many to mant ilişkisi için yapıyoruz bunu, bu bir orderın birden fazla productı olduğunu ifade eder
        public Customer Customer { get; set; } // 1 tane customer olablir o yuzden ıcollection falan yazmadık

    }
}
