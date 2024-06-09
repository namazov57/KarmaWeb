using Karma.Infrastructure.Commons.Concretes;
using Karma.Infrastructure.Entites;
using Karma.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Data.Repositories
{
    internal class SubscriberRepository : Repository<Subscriber>, ISubscriberRepository
    {
        public SubscriberRepository(DbContext db) : base(db)
        {
        }
    }
}
