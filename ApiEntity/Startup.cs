using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebFramework.Middlewares;
using ElmahCore.Mvc;
using ElmahCore.Sql;
using WebFramework.Configuration;
using Common;
using System;
using AutoMapper;
using Entites;
using WebFramework.CustomMapping;
using WebFramework.Swagger;
using Microsoft.Extensions.Logging;
using Data.Contracts;
using Data.Repositories;

namespace ApiEntity
{
    public class Startup
    {
        private SiteSettings _siteSetting;
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            AutoMapperConfiguration.InitializeAutoMapper();
            _siteSetting = Configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddDbContext<ApplicationDbContext>(options =>
            //{
            //    options.UseSqlServer(Configuration.GetConnectionString("SqlServer"));
            //});
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.Configure<SiteSettings>(Configuration.GetSection(nameof(SiteSettings)));            
            services.AddDbContext(Configuration);           
            services.AddMinimalMvc();           
            //services.AddElmah(Configuration, _siteSetting);          
            services.AddJwtAuthentication(_siteSetting.JwtSettings);
            services.AddCustomApiVersioning();
            services.AddSwagger();
            return services.BuildAutofacServiceProvider();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //string Date = DateTime.Now.ToString("dd-MM-yyyy");
            //string addres = AppDomain.CurrentDomain.BaseDirectory + "\\LogFolder" + "\\ApiEntity" + Date + ".txt";
            //loggerFactory.AddFile(addres);
            app.UseCustomExceptionHandler();
            if (env.IsDevelopment())
            {
                
            }
            else
            {
                
                app.UseHsts();
            }
            
            //app.UseElmah();
            app.UseHttpsRedirection();
            //app.UseWhen(x => (x.Request.Path.StartsWithSegments("/api/v1/User/Token", StringComparison.OrdinalIgnoreCase)),
            //builder =>
            //{
            //    builder.UseMiddleware<AuthenticationMiddleware>();
            //});
            app.UseMiddleware<AuthenticationMiddleware>();
            app.UseSwaggerAndUI();
            app.UseAuthentication();
            app.UseMvc();
            
        }
    }
}
