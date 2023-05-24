using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicareAPI.Persistence.Contexts
{
    public class ETicaretAPIDbContext : DbContext
    {
        public ETicaretAPIDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Product> Products { get; set; } // veri tabanı için tablonun kolonlarını belirttik
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) //interceptor yapmaya çalışıyoruz  
        { // gelen isteklerde insertse DateTime update ise updated date kolonlarını doldurup devam edecek

            //ChangeTracker : Entitiyler üzerinde yapılan değişikliklerin ya da yeni eklenen verinin yakalanmasını sağlayan prop. UpDate operasyonlarında Track edilen verileri yakalayıp elde etmemizi sağlar.

            var datas = ChangeTracker
                .Entries<BaseEntity>();      // Entries de girdileri yakalıyoruz,baseentitiyden gelen customer order prod.. falan filan

            foreach (var data in datas) //ne kadar data girdiyse yakaladık datas la şimdi o data ların içinde gezcez
            {
                _ = data.State switch // var result vardı ama return le falan uğraşmayalım diye _ kullandık, luzumsuz yere datayı tutmıcaz
                {
                    EntityState.Added => data.Entity.DateTime = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedTime = DateTime.UtcNow,

                };
             }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
