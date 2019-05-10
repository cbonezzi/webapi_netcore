using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WACore.Data.Core;
using WACore.Data.Core.Interfaces;
using WACore.Data.Model;
using WACore.Dto.Users;
using WACore.Service.Interfaces;
using WACore.Service.Mappers;
using WACore.Service.Mappers.Interfaces;
using WACore.Service.Services;

namespace WACore
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //here is where I add the context from the data layer.
            services.AddDbContext<WebAppContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            //adding dbcontext
            services.AddSingleton(typeof(DbContext), typeof(WebAppContext));

            //repo and services
            //this is how we are capable of using only one class for the repo, without the need to 
            //create contextfactory and had to create additional repo classes per type
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IMappers<UserDto, UserCred>), typeof(MapperToUserCred));
            services.AddScoped(typeof(IMappers<UserCred, UserDto>), typeof(MapperToUserDto));
            services.AddTransient<IUserService, UserService>();

            services.AddMvcCore(options =>
            {
                options.RequireHttpsPermanent = true;
            })
            .AddJsonFormatters()
            .AddRazorViewEngine()
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}")
                .MapRoute("default", "{controller=Home}/{action=Index}/{email?}");
            });
        }
    }
}
