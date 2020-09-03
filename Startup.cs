using System;
using ApiPatents.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace ApiPatents
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IRepoPatent, PatentRepository>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API do Sistema para Recuperação e Inferência de Informação sobre a COVID-19",
                    Description = "ASP.NET Core Web API para intercâmbio de dados entre aplicativos do projeto",
                    TermsOfService = new Uri("https://github.com/Iniciacao-Cientifica-COVID-19-2020"),
                    Contact = new OpenApiContact
                    {
                        Name = "Contato",
                        Email = "wesleydiasmaciel@gmail.com",
                        Url = new Uri("https://github.com/Iniciacao-Cientifica-COVID-19-2020"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Todos os direitos reservados ao Instituto Anima.",
                        Url = new Uri("https://github.com/Iniciacao-Cientifica-COVID-19-2020"),
                    }
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
            });

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
