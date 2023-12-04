using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVCApp.Data;
using System;
using System.Linq;

namespace MVCApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MVCAppContext(
            serviceProvider.GetRequiredService<DbContextOptions<MVCAppContext>>()))
            {
                //Look for my movies
                if (context.Movie.Any()) {
                    return; //Db has been seeded
                }
                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Romantic",
                        Price = 7.99M,
                        Rating = "R"
                    },
                    new Movie
                    {
                        Title = "Ghostbusters",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Comedy",
                        Price = 8.99M,
                        Rating = "PG-13"
                    },
                    new Movie
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-2-13"),
                        Genre = "Comedy",
                        Price = 9.99M,
                        Rating = "PG-13"
                    },
                    new Movie
                    {
                        Title = "Río Bravo",
                        ReleaseDate = DateTime.Parse("1954-4-15"),
                        Genre = "Western",
                        Price = 3.99M,
                        Rating = "R"
                    }
                );
                context.SaveChanges();
            }
        }
        
    }
}
