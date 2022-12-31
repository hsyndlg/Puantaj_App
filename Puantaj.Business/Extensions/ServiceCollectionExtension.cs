using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Puantaj.Business.Abstract;
using Puantaj.Business.Concrete;
using Puantaj.Data.Abstract;
using Puantaj.Data.Concrete;
using Puantaj.Data.Concrete.EntityFramework.Contexts;
using Puantaj.Data.Concrete.EntityFramework.Repositories;
using Puantaj.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puantaj.Business.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection services)
        {
            services.AddIdentity<User, Role>().AddEntityFrameworkStores<PuantajAppContext>();

            services.AddTransient<IUnitOfWork,UnitOfWork>();

            services.AddTransient<IPersonelService,PersonelManager>();
            services.AddTransient<IProjeService,ProjeManager>();
            services.AddTransient<IPuantajCizelgeService,PuantajCizelgeManager>();

            services.AddDbContext<PuantajAppContext>(opt =>
             opt.UseSqlServer("Server=localhost;Database=PuantajApp;Trusted_Connection=True;TrustServerCertificate=True"
         ));

            return services;
        }
    }
}