using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using TesteNotifications.Application.AutoMapper;
using TesteNotifications.Configurations.Filters;
using TesteNotifications.Domain.Contracts;
using TesteNotifications.Domain.Global.Notifier.Queues.Error;
using TesteNotifications.Infra.Data;
using TesteNotifications.Infra.Repositories;

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

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Api Teste Notifications",
                    Description = "Api (Rest) Teste Notifications tem o intuito de servir como teste para a " +
                    "implementação do padrão Domain Notifications. Está sendo utilizado recursos da biblioteca MediatR " +
                    "e do Result Filters para atender ao problema proposto.",
                    Contact = new OpenApiContact
                    {
                        Name = "Luis Fernando",
                        Email = "luisz.dantass@hotmail.com"
                    }
                });
            });

            DependiciesConfiguration(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(s => s.SwaggerEndpoint("/swagger/v1/swagger.json", ""));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void DependiciesConfiguration(IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load(nameof(TesteNotifications));
            services.AddMediatR(assembly);

            services.AddDbContext<ProjectContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("MyConnection")));

            services.AddAutoMapper(typeof(AutoMapperConfiguration));

            services.AddScoped<IErrorQueue, ErrorQueue>();

            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IAlunoQueryRepository, AlunoQueryRepository>();
        }
    }
}
