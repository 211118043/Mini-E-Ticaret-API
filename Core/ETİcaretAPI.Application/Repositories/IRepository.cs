using ETicaretAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETİcaretAPI.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity // generic ifadenin kapsamını daralttık yanı vereceğimiz ifade kesinlikle class olcacak diyoruz yoksa table zırlıyo -_-
    {
        DbSet<T> Table { get; }

        
    }
}
