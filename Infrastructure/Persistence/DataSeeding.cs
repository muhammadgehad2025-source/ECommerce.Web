using DomainLayer.Contracts;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Persistence
{
    public class DataSeeding(StoreDbContext dbContext) : IDataSeeding
    {
        public async Task DataSeedAsync()
        {
            // first ensure all migrations are applied
            // check if there is any pending migrations
            // inject object from DbContext
            if (( await dbContext.Database.GetPendingMigrationsAsync()).Any())
            {
                await dbContext.Database.MigrateAsync();
            }

            try
            {

                #region ProductBrands
                // use dataseeding if their is no data
                if (!dbContext.ProductBrands.Any())
                {
                    var ProductsBrandData = File.OpenRead(@"..\Infrastructure\Persistence\Data\DataSeed\brands.json");
                    // convert data to c# objects
                    var ProductsBrands = await JsonSerializer.DeserializeAsync<List<ProductBrand>>(ProductsBrandData);

                    // add data
                    if (ProductsBrands is not null && ProductsBrands.Any())
                    {
                        await dbContext.ProductBrands.AddRangeAsync(ProductsBrands);

                    }
                }
                #endregion

                #region ProductTypes
                // use dataseeding if their is no data
                if (!dbContext.ProductTypes.Any())
                {
                    var ProductsTypesData = File.OpenRead(@"..\Infrastructure\Persistence\Data\DataSeed\types.json");
                    // convert data to c# objects
                    var ProductsTypes = await JsonSerializer.DeserializeAsync<List<ProductType>>(ProductsTypesData);

                    // add data
                    if (ProductsTypes is not null && ProductsTypes.Any())
                    {
                        await dbContext.ProductTypes.AddRangeAsync(ProductsTypes);

                    }
                }
                #endregion

                dbContext.SaveChanges();

                #region Products
                // use dataseeding if their is no data
                if (!dbContext.Products.Any())
                {
                    var ProductsData = File.OpenRead(@"..\Infrastructure\Persistence\Data\DataSeed\products.json");
                    // convert data to c# objects
                    var Products = await JsonSerializer.DeserializeAsync<List<Product>>(ProductsData);

                    // add data
                    if (Products is not null && Products.Any())
                    {
                        await dbContext.Products.AddRangeAsync(Products);

                    }
                }
                #endregion

                //savechanges
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                //ToDo
            }
        }
    }
}
