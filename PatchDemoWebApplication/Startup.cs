using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PatchDemoWebApplication.Context;
using PatchDemoWebApplication.Repository;
using PatchDemoWebApplication.Validators;
using System;
using System.Linq;
using System.Reflection;

namespace PatchDemoWebApplication
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
            //services.AddControllers(options =>
            //{
            //    options.InputFormatters.Insert(0, GetJsonPatchInputFormatter());
            //});
            services.AddControllers().AddNewtonsoftJson().AddFluentValidation(opt =>
            {
                opt.RegisterValidatorsFromAssemblyContaining<EmployeeValidator>();
            });

            services.AddSingleton<IValidator<Employee>, EmployeeValidator>();
            services.AddDbContext<EmployeeDbContext>
                (item => item.UseSqlServer(Configuration.GetConnectionString("employeeConnection")));
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        }

        //private static NewtonsoftJsonPatchInputFormatter GetJsonPatchInputFormatter()
        //{
        //    var builder = new ServiceCollection()
        //        .AddLogging()
        //        .AddMvc()
        //        .AddNewtonsoftJson()
        //        .Services
        //        .BuildServiceProvider();

        //    return builder
        //        .GetRequiredService<IOptions<MvcOptions>>()
        //        .Value
        //        .InputFormatters
        //        .OfType<NewtonsoftJsonPatchInputFormatter>()
        //        .First();
        //}

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
