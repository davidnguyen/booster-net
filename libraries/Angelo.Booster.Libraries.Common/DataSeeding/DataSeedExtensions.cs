using Serilog;
using Microsoft.EntityFrameworkCore;
using CsvHelper;
using System.Globalization;
using System.Text.Json;
using CsvHelper.Configuration;

namespace Angelo.Booster.Libraries.Common.DataSeeding;

public static class SeedDataExtensions
{
    public static void LoadSeedData<TEntityType>(
        this DbContext dbContext, 
        string path = "Seeds", 
        bool includingTest = true,
        Func<dynamic, TEntityType>? customEntityMapper = null
        )
        where TEntityType : class
    {
        var entityType = dbContext.Model.FindEntityType(typeof(TEntityType));
        var tableName = entityType?.GetTableName();

        if (dbContext.Set<TEntityType>().Any())
        {
            Log.Information($"{tableName} table is already populated");
            return;
        }

        var directoryInfo = new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, path));
        
        var file = new FileInfo(Path.Combine(directoryInfo.FullName, $"{tableName}.csv"));
        Log.Information($"LoadSeedData: {file.FullName}, Exists: {file.Exists}");

        if (!file.Exists) return;

        using (var reader = new StreamReader(file.OpenRead()))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            if (customEntityMapper != null)
            {
                var records = csv.GetRecords<dynamic>().ToArray();
                Log.Information($"{records.Count()} seed records found");
                foreach (var record in records)
                {
                    var entity = customEntityMapper(record);
                    dbContext.Set<TEntityType>().Add(entity);
                }
            }
            else
            {
                var records = csv.GetRecords<TEntityType>().ToArray();
                Log.Information($"{records.Count()} seed records found");
                foreach (var record in records)
                {
                    dbContext.Set<TEntityType>().Add(record);
                }
            }

            var results = dbContext.SaveChanges();
            Log.Information($"{results} records saved");
        }
    }
}