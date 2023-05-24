using ETicareAPI.Persistence.Contexts;
using ETicaretAPI.Domain.Entities;
using ETİcaretAPI.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicareAPI.Persistence.Repositories
{
    public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(ETicaretAPIDbContext context) : base(context)
        {
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
