using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Models;

namespace PlatformService.Data
{
    public static class DbPreparation
    {
        public static void PreparePopulation(this IApplicationBuilder builder)
        {
            using (var serviceScope = builder.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<PlatformDbContext>());
            }
        }

        private static void SeedData(PlatformDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("-----> Seeding data into database.");

                context.Platforms.AddRange(
                    new Platform {Name = ".NET", Publisher = "Microsoft", Cost = "Free"},
                    new Platform {Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free"},
                    new Platform {Name = "SQL Server Express", Publisher = "Microsoft", Cost = "Free"},
                    new Platform {Name = "node.js", Publisher = "OpenJS Foundation", Cost = "Free"}
                );

                context.SaveChanges();
                return;
            }

            Console.WriteLine("-----> We already have data in our database.");
        }
    }
}