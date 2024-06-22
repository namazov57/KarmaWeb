using Karma.Infrastructure.Commons.Abstracts;
using Karma.Infrastructure.Entites.Membership;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Karma.Data
{

    public static class DataServiceInjection
    {
        public static IServiceCollection InstallDataServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<DbContext, DataContext>(cfg =>
            {

                cfg.UseSqlServer(configuration.GetConnectionString("cString"),
                    opt =>
                    {
                        opt.MigrationsHistoryTable("Migrations");
                    });

            });

            services.AddIdentityCore<KarmaUser>()
                .AddRoles<KarmaRole>()
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            services.AddScoped<UserManager<KarmaUser>>();
            services.AddScoped<RoleManager<KarmaRole>>();
            services.AddScoped<SignInManager<KarmaUser>>();


            var repoInterfaceType = typeof(IRepository<>);

            var concretRepositoryAssembly = typeof(DataServiceInjection).Assembly;

            var repositoryPairs = repoInterfaceType.Assembly
                                     .GetTypes()
                                     .Where(m => m.IsInterface
                                             && m.GetInterfaces()
                                                 .Any(i => i.IsGenericType
                                                     && i.GetGenericTypeDefinition() == repoInterfaceType))
                                     .Select(m => new
                                     {
                                         AbstactRepository = m,
                                         ConcrateRepository = concretRepositoryAssembly.GetTypes()
                                                              .FirstOrDefault(r => r.IsClass && m.IsAssignableFrom(r)),
                                     })
                                     .Where(m => m.ConcrateRepository != null);

            foreach (var item in repositoryPairs)
            {
                services.AddScoped(item.AbstactRepository, item.ConcrateRepository!);
            }
            return services;
        }
   
      
    }
}
