using Microsoft.EntityFrameworkCore;
using ETicareAPI.Persistence.Contexts;
using ETİcaretAPI.Application.Abstactions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETİcaretAPI.Application.Repositories;
using ETicareAPI.Persistence.Repositories;

namespace ETicareAPI.Persistence
{
    //extented metot kullanıyoruz
    //bu katman ıoc katmanı muhtemelen (tam anlayamadım)
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<ETicaretAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
            //yaptığımız çalışmaları ıoc ye eklemeliyiz ınterfacelerı ve concreate leri
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            //mesela ıcostomerreadrep istediginde bız customerreadrep döndüreceğiz


        }
    }
};
