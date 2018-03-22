using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StoreControl.Infrastructure.Database.Context;
using StoreControl.Infrastructure.Database.DAO;
using StoreControl.Infrastructure.Database.DAO.Interfaces;
using Swashbuckle.AspNetCore.Swagger;

namespace StoreControl
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
            services.AddDbContext<ApplicationDbContext>(pX =>
              pX.UseSqlServer(ApplicationDbContext.GetConnection()));

            services.AddSwaggerGen(pX =>
                pX.SwaggerDoc("v1", new Info { Title = "StoreControl", Version = "v1" }));

            services.AddAutoMapper();
            services.AddCors(
                pX => pX.AddPolicy("AllowAll", pY =>
                    pY.AllowAnyHeader()
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowCredentials()));
            //services.AddOData();
            services.AddMvc().AddJsonOptions(pX =>
            {
                pX.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
                pX.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            });

            services.AddScoped(typeof(ICustomerAccountDAO), typeof(CustomerAccountDAO));
            services.AddScoped(typeof(IPurchaseDAO), typeof(PurchaseDAO));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                context.Database.Migrate();
            }

            app.UseSwagger()
                .UseSwaggerUI(pX => pX.SwaggerEndpoint("/swagger/v1/swagger.json", "StoreControl v1"))
                .UseAuthentication()
                .UseCors("AllowAll")
                .UseMvc();
        }
    }
}

