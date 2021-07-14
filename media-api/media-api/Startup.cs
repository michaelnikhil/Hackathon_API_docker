using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using media_api.Database;
using Microsoft.Extensions.Options;

namespace media_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ////services.AddRazorPages();
            //services
            //.Configure<ImageDBSettings>(options => Configuration.GetSection("MongoDbSettings").Bind(options))
            //.AddTransient<IMongoDbContext,MongoDbContext>()
            //.AddScoped<IImageRepository,ImageRepository>();
            //

            services.Configure<ImageDBSettings>(
                Configuration.GetSection("MongoDbSettings"));

            services.AddSingleton<IImageDBSettings>(sp =>
                sp.GetRequiredService<IOptions<ImageDBSettings>>().Value);
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddControllers();
            // Add to enable CORS
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                                  builder =>
                                  {
                                      builder.WithOrigins("https://localhost:51566");
                                  });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
