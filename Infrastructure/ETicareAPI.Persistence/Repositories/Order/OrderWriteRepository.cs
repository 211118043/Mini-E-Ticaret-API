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
    public class OrderWriteRepository : WriteRepository<Order>, IOrderWriteRepository
    {
        public OrderWriteRepository(ETicaretAPIDbContext context) : base(context)
        {
        }

        public async Task SaveAsync()
        {
            return;
        }
    }
}
