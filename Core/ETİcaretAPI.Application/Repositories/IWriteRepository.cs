using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETİcaretAPI.Application.Repositories
{
    //Read dediğimiz database SELECT
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity //solid prensiplerine uysun diye ayırdık read ve write, bunlarda da class kullanacağımızın garatisini sisteme verdik
    {
        Task<bool> AddAsync(T model); // gelen model neyse onu ekle
        Task<bool> AddRangeAsync(List<T> datas); // birden fazla ya da koleksiyon gelirse de böyle ekliyoruz, ayrıca addasync in overload unu oluşturmuş olduk
        bool Remove(T model);
        bool RemoveRange(List<T> datas);
        
        bool Update(T model);
        Task<int> SaveAsync(T model);





    }
}
