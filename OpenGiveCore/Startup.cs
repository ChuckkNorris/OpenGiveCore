using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO;
using OpenGiveCore.Server.Entities;
using Microsoft.EntityFrameworkCore;

namespace OpenGiveCore
{
    public class Startup
    {
		private const string DB_USERNAME = "commander";
		private const string DB_PASSWORD = "Cobra1234";
		private static readonly string LADOT_DB_CONNECTION_STRING = $"Server=tcp:chucknorrisdev.database.windows.net,1433;Initial Catalog=LadotDB;Persist Security Info=False;User ID={DB_USERNAME};Password={DB_PASSWORD};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
		public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
			services.AddDbContext<LadotContext>(options => options.UseSqlServer(LADOT_DB_CONNECTION_STRING));
			
            // Add framework services.
            services.AddMvc();
			services.AddSwaggerGen(c => {
				c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "LADOT Web API", Version = "v1" });
			});
		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
			
			loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
			app.Use(async (context, next) => {
				await next();
				if (context.Response.StatusCode == 404 &&
				   !Path.HasExtension(context.Request.Path.Value) &&
				   !context.Request.Path.Value.StartsWith("/api/")) {
					context.Request.Path = "/index.html";
					await next();
				}
			});
			app.UseMvc();

			app.UseDefaultFiles();
			app.UseStaticFiles();
			app.UseSwagger();
		}
    }
}
