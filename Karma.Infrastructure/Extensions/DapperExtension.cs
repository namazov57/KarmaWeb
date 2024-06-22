using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Infrastructure.Extensions
{
    public static class DapperExtension
    {
        public static IEnumerable<T> Query<T>(this DbContext db,
            string command,
            DynamicParameters parameters,
            CommandType commandType = CommandType.Text)
            where T : class
        {
            return db.Database.GetDbConnection().Query<T>(command, parameters, commandType: commandType);
        }

        public static T? QueryFirstOrDefault<T>(this DbContext db,
            string command,
            DynamicParameters parameters,
            CommandType commandType = CommandType.Text)
            where T : class
        {
            return db.Database.GetDbConnection().QueryFirstOrDefault<T>(command, parameters, commandType: commandType);
        }
    }
}
