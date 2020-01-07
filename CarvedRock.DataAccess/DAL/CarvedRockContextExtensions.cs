using CarvedRock.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarvedRock.DataAccess.DAL
{
    public static class CarvedRockContextExtensions
    {
        public static void Seed(this CarvedRockContext context)
        {
            if (!context.Products.Any())
            {
                context.Products.AddRange(new List<Product>
                {
                    new Product
                    {
                        Name = "Mountain Walkers",
                        Description = "Walking boots designed for mountaineering",
                        Price = 219.5m,
                        Rating = 4,
                        Stock = 12,
                        IntroducedAt = new DateTimeOffset(DateTime.Now),
                        PhotoFileName = "shutterstock_66842440.jpg",
                        ProductType = ProductType.Boots
                    },
                    new Product
                    {
                        Name = "Climbers Feet",
                        Description = "Get the agility you need with these boot add-ons.",
                        Price = 199m,
                        Rating = 5,
                        Stock = 5,
                        IntroducedAt = new DateTimeOffset(DateTime.Now),
                        PhotoFileName = "",
                        ProductType = ProductType.Gear
                    }
                });
                context.SaveChanges();
            }
        }
    }
}
