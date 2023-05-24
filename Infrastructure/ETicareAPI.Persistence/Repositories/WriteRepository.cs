using ETicareAPI.Persistence.Contexts;
using ETicaretAPI.Domain.Entities.Common;
using ETİcaretAPI.Application.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicareAPI.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        readonly private ETicaretAPIDbContext _context;

        public WriteRepository(ETicaretAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>(); //ilgili dbseti elde ettik

        public async Task<bool> AddAsync(T model)
        {
            EntityEntry entityEntry = await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> datas)
        {
            await Table.AddRangeAsync(datas);
            return true;
        }


        public bool Remove(T model) //taskları sildik çünkü bunlar async değil ,await ve async yapıları task dönen fonksiyonkalarda kullanılır
        {
            EntityEntry<T> entityEntry = Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }
        public bool RemoveRange(List<T> datas)
        {
            Table.RemoveRange(datas);
            return true;
        }

        public async Task<bool> RemoveAsync(string id) // bu fonksiyonda await kullanmak zorunda kaldık çünkü içerisinde async kullanıyoruz aslında bu tasklı değildi ama await falan kullanınca sıkıntı çıkarıyor o yüzden mecbur task diye değiştireceğiz
        {
            T model = await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id)); // silinecek datayı bulduk
            return Remove(model);
        }


        public bool Update(T model)
        {
            EntityEntry entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;

        }

        public async Task<int> SaveAsync(T model)
            => await _context.SaveChangesAsync();
       
    }
}
