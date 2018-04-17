using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;
using WebApiCore.Domain;
using WebApiCore.Domain.Concrete;
using WebApiCore.Domain.Interface;

namespace WebApiCore
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
            string conn = Configuration.GetConnectionString("test_conn");
            services.AddDbContext<TestContext>(options =>
                                               options.UseSqlServer(conn));
            //依赖注入
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddMvc();
            services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Title",
                    Description = "Description",
                    TermsOfService = "TermsOfService",
                    Contact = new Contact()
                    {
                        Name = "Name",
                        Email = "Email",
                        Url = "Url"
                    }
                });
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "WebApiCore.xml");
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json","king");
                c.DisplayRequestDuration();
            });
        }
    }
}
