using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Data.Persistences.Seed
{
    public static class Automigration
    {
        public static IApplicationBuilder UpdateDatabase(this IApplicationBuilder builder)
        {
            using (var scope = builder.ApplicationServices.CreateScope()) 
            {
                var db = scope.ServiceProvider.GetRequiredService<DbContext>();

                db.Database.Migrate();
            }

            return builder;
        }
    }
}
