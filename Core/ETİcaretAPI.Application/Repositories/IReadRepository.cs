using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETİcaretAPI.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity //solid prensiplerine uysun diye ayırdık read ve write
    {
        // Neden ıque ? sorgu üzerinde çalışmak istiyorsak ıque, inmemory de çalışacaksak ıenum,ıque falan çoğulu ifade ediyor tekil çağıracaksak T diyeceğiz sadece
        IQueryable<T> GetAll(bool tracking = true); // Bana tüm T tipindeki verileri getir
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true); // verdiğim şarta uygun olanları getir
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true); //şarta uygun olan ilkini getir, tekil olduğu için sadece T
        Task<T> GetByIdAsync(string id, bool tracking = true); // ıd ye uygun hangisiyse onu getir. //asenkron çalıştırıyoruz

    }
}
