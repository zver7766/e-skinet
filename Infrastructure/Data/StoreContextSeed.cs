using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ProductBrands.Any())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        var brandsData =
                             File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");

                        var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                        foreach (var item in brands)
                        {
                            context.ProductBrands.Add(item);
                        }

                        context.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT dbo.ProductBrands ON;");
                        await context.SaveChangesAsync();
                        context.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT dbo.ProductBrands OFF");
                        transaction.Commit();
                    }
                }

                if (!context.ProductTypes.Any())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        var typesData =
                             File.ReadAllText("../Infrastructure/Data/SeedData/types.json");

                        var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                        foreach (var item in types)
                        {
                            context.ProductTypes.Add(item);
                        }

                        context.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT dbo.ProductTypes ON;");
                        await context.SaveChangesAsync();
                        context.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT dbo.ProductTypes OFF");
                        transaction.Commit();
                    }
                }

                if (!context.Products.Any())
                {
                    var productsData =
                         File.ReadAllText("../Infrastructure/Data/SeedData/products.json");

                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    foreach (var item in products)
                    {
                        context.Products.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.DeliveryMethods.Any())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        var dmData =
                             File.ReadAllText("../Infrastructure/Data/SeedData/delivery.json");

                        var methods = JsonSerializer.Deserialize<List<DeliveryMethod>>(dmData);

                        foreach (var item in methods)
                        {
                            context.DeliveryMethods.Add(item);
                        }

                        context.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT dbo.DeliveryMethods ON;");
                        await context.SaveChangesAsync();
                        context.Database.ExecuteSqlInterpolated($"SET IDENTITY_INSERT dbo.DeliveryMethods OFF");
                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message, "Exception on StoreContextSeed");
            }
        }
    }
}