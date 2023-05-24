using ETicareAPI.Persistence.Contexts;
using ETicaretAPI.Domain.Entities.Common;
using ETİcaretAPI.Application.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace ETicareAPI.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ETicaretAPIDbContext _context;

        public ReadRepository(ETicaretAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking(); // gelecek olan dataların track edilmesini kesiyoruz ( kodu yazdık da optimizasyonu kaldı)
            return query;
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method); // where neticesinde ıqueryable gelıyor
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return query;
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking(); // tracking i kopardık
            }
            return await query.FirstOrDefaultAsync(method);
        }



        public async Task<T> GetByIdAsync(string id, bool tracking = true) // normalde t: classtı ama bu sefer her classs id içermediğinden parametre id bulamıyor ve hata veriyordu  bızde class yerıne base entıty yazdık çünkü onda id var ve temel bir sınıf 

        //=>await  Table.FirstOrDefaultAsync(data=> data.Id == Guid.Parse(id)); //marker patternla yapıldı o nedemekse artık
        // => await Table.FindAsync(Guid.Parse(id));
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));




        }


    }
}
