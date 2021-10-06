using business.Implementation;
using business.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace subcon
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "subcon", Version = "v1" });
            });

            services.AddScoped<IAdmin_Serv, Admin_Serv>();
            services.AddScoped<IStaff_Serv, Staff_Serv>();

            #region CORS
            services.AddCors();

            string corsUrl = Configuration["CORS:site"];
            string[] corsUrls;
            if (corsUrl.Contains(","))
            {
                corsUrls = corsUrl.Split(',').ToArray();
            }
            else
            {
                corsUrls = new string[1];
                corsUrls[0] = corsUrl;
            }
            services.AddCors(options =>
            {
                options.AddPolicy("angular",
                    builder =>
                    {
                        builder.WithOrigins(corsUrls)
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                    });
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "subcon v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
