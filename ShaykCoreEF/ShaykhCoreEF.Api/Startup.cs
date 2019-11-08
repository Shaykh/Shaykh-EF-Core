using ShaykhCoreEF.DataAccess.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using ShaykhCoreEF.DataAccess.Services;

namespace ShaykhCoreEF.Api
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
            // Add the OrderService DI registration code

            var builder = new SqlConnectionStringBuilder(Configuration.GetConnectionString("ShaykhCoreEF"));
            IConfigurationSection ShaykhCoreEFCredentials = Configuration.GetSection("ShaykhCoreEFCredentials");

            builder.UserID = ShaykhCoreEFCredentials["UserId"];
            builder.Password = ShaykhCoreEFCredentials["Password"];

            services.AddDbContext<ShaykhCoreEFContext>(options => options.UseSqlServer(builder.ConnectionString));

            services.AddControllers();
            services.AddApplicationInsightsTelemetry();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
