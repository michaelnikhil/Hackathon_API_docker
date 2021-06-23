using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using DB_initializer.Database;

namespace DB_initializer
{
    class Program
    {
        private static IConfiguration Configuration { get; set; }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("--- Mongo DB initialise ---");
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .AddCommandLine(args);

            BsonSerializer.RegisterSerializer(typeof(decimal), new DecimalSerializer(BsonType.Decimal128));
            BsonSerializer.RegisterSerializer(typeof(decimal?), new NullableSerializer<decimal>(new DecimalSerializer(BsonType.Decimal128)));

            Configuration = builder.Build();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services
                .AddLogging(configure => configure.AddSerilog())
                .AddTransient<IMongoDbContext, MongoDbContext>();
            services
                 .Configure<MongoDbSettings>(Configuration.GetSection("MongoDb"));
        }
    }
}
