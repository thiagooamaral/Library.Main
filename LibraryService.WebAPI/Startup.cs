using Microsoft.AspNetCore.Mvc;
using LibraryService.WebAPI.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using LibraryService.WebAPI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LibraryService.WebAPI.Services.Contracts;

namespace LibraryService.WebAPI
{
    public class Startup
    {
        public const string DatabaseFileName = "database.db";

        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TestProjectContext>(options => options.UseLazyLoadingProxies().UseSqlite($"Data Source={DatabaseFileName}"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddControllers();
            services.AddSwaggerGen();

            services.AddTransient<IBooksService, BooksService>();
            services.AddTransient<ILibrariesService, LibrariesService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                    {
                        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                        options.RoutePrefix = string.Empty;
                    });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
