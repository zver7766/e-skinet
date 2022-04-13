using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Core.Entities.OrderAggregate;
using Core.Entities.ProductAggregate;
using Core.Entities.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Infrastructure.Data
{
    public static class ReflectionExtensions
    {
        public static object SetValueToProperty<TValue>(this object source, string propertyName, TValue value)
        {
            var sourceType = source.GetType();
            var propertyInfo = sourceType.GetProperty(propertyName,
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            if (propertyInfo == null)
            {
                throw new ArgumentOutOfRangeException(nameof(propertyName),
                    $"Property {propertyName} was not found in Type {source.GetType().FullName}");
            }

            sourceType.InvokeMember(propertyName,
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty | BindingFlags.Instance,
                null,
                source,
                new object?[] {value});

            return source;
        }
    }

    public class SeedingProduct 
    {
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public decimal Price { get; set; }

        public string PictureUrl { get; set; }

        public int ProductTypeId { get; set; }

        public int ProductBrandId { get; set; }
    }

    public class SeedingDeliveryMethods
    {
        public int Id { get; set; }

        public string ShortName { get; set; }

        public string Description { get; set; }

        public string DeliveryTime { get; set; }

        public decimal Price { get; set; }
    }

    public class RawDataHelper
    {
        private const string ContentDirectoryName = "../Skinet.Infrastructure/Data/SeedData";
        public static TResult GetRawDataOf<TResult>(string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), ContentDirectoryName, fileName);

            using StreamReader streamReader = File.OpenText(filePath);
            using JsonTextReader jsonTextReader = new(streamReader);
            JsonSerializer serializer = new();
            var entries = serializer.Deserialize<TResult>(jsonTextReader);

            return entries;
        }
        
        public static Dictionary<int, string> GetBrands()
        {
            var rawBrandEntries = GetRawDataOf<Dictionary<string, string>>("brands.json");

            var result = new Dictionary<int, string>(rawBrandEntries.Count);

            foreach (var entry in rawBrandEntries)
            {
                result.Add(int.Parse(entry.Key), entry.Value);
            }

            return result;
        }
        
        public static Dictionary<int, string> GetTypes()
        {
            var rawTypersEntries = GetRawDataOf<Dictionary<string, string>>("types.json");

            var result = new Dictionary<int, string>(rawTypersEntries.Count);

            foreach (var entry in rawTypersEntries)
            {
                result.Add(int.Parse(entry.Key), entry.Value);
            }

            return result;
        }
    }
    
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
                        var rawBrands = RawDataHelper.GetBrands();
                        
                        foreach (var (brandId, brandName) in rawBrands)
                        {
                            var brand = new ProductBrand(brandName);
                            brand.SetValueToProperty(nameof(ProductBrand.Id), brandId);
                            context.ProductBrands.Add(brand);
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
                        var rawTypes = RawDataHelper.GetTypes();
                        
                        foreach (var (typeId, typeName) in rawTypes)
                        {
                            var type = new ProductType(typeName);
                            type.SetValueToProperty(nameof(ProductType.Id), typeId);
                            context.ProductTypes.Add(type);
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
                         File.ReadAllText("../Skinet.Infrastructure/Data/SeedData/products.json");
                
                    var products = System.Text.Json.JsonSerializer.Deserialize<List<SeedingProduct>>(productsData);
                
                    foreach (var item in products)
                    {
                        var price = new Price(item.Price);
                        var productType = context.ProductTypes.FirstOrDefault(x => x.Id == item.ProductTypeId);
                        var productBrand = context.ProductBrands.FirstOrDefault(x => x.Id == item.ProductBrandId);
                        
                        var product = new Product(item.Name, item.Description, price, item.PictureUrl, productType!, productBrand!);

                        context.Products.Add(product);
                    }
                
                    await context.SaveChangesAsync();
                }
                
                if (!context.DeliveryMethods.Any())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        var dmData =
                             File.ReadAllText("../Skinet.Infrastructure/Data/SeedData/delivery.json");
                
                        var methods = System.Text.Json.JsonSerializer.Deserialize<List<SeedingDeliveryMethods>>(dmData);
                
                        foreach (var item in methods)
                        {
                            var price = new Price(item.Price);

                            var deliveryMethod = new DeliveryMethod(price, item.ShortName, item.DeliveryTime, item.Description);
                            deliveryMethod.SetValueToProperty(nameof(DeliveryMethod.Id), item.Id);
                            
                            context.DeliveryMethods.Add(deliveryMethod);
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