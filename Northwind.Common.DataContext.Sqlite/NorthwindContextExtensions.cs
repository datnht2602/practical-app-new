using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace Packt.Shared
{
    public static class NorthwindContextExtensions
    {
        public static IServiceCollection AddNorthwindContext(
            this IServiceCollection services,string relativePath = ".."
        )
        {
            string databasePath = Path.Combine(relativePath,"Northwind.db");
            services.AddDbContext<NorthwindContext>(options =>
            {
                options.UseSqlite($"Data Source={databasePath}");
                options.LogTo(Console.WriteLine,
                new[] { Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.CommandExecuting});
            });
            return services;
        }
    }
}