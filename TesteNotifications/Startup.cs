using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using TesteNotifications.AutoMapper;
using TesteNotifications.Configurations.Filters;
using TesteNotifications.Data.Repositories;
using TesteNotifications.Data.Repositories.Notifications;
using TesteNotifications.Querys;

namespace TesteNotifications
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
            services.AddControllers(option =>
            {
                option.Filters.Add<ResponseFilter>();
            });

            var assembly = AppDomain.CurrentDomain.Load(nameof(TesteNotifications));
            services.AddMediatR(assembly);

            services.AddAutoMapper(typeof(AutoMapperConfiguration));

            services.AddSingleton<RepositoryAluno, RepositoryAlunoImp>();
            services.AddScoped<RepositoryNotification, RepositoryNotificationImp>();
            services.AddScoped<RepositoryQuery, RepositoryQueryImp>();
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
