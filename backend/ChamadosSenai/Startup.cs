using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChamadosSenai
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
            services
                .AddControllers()
                 .AddNewtonsoftJson(options =>
                 {
                     // Ignora os loopings nas consultas
                     options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                     // Ignora valores nulos ao fazer jun??es nas consultas
                     options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                 });

            // Adiciona o CORS ao projeto
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000", "http://localhost:19006", "http://localhost:5000")
                                                                    .AllowAnyHeader()
                                                                    .AllowAnyMethod();
                    }
                );
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ChamadosSenai", Version = "v1" });
            });

            services
              // Define a forma de autenticação
              .AddAuthentication(options =>
              {
                  options.DefaultAuthenticateScheme = "JwtBearer";
                  options.DefaultChallengeScheme = "JwtBearer";
              })

              .AddJwtBearer("JwtBearer", options =>
              {
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      // valida o issuer
                      ValidateIssuer = true,

                      // valida o audience
                      ValidateAudience = true,

                      //valida o tempo de vida
                      ValidateLifetime = true,

                      // forma de criptografia e a chave de autentica��o
                      IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("chamados-chave-autenticacao")),

                      // faz a verificação do tempo de expiração do token
                      ClockSkew = TimeSpan.FromMinutes(30),

                      //nome do emissor, de onde está vendo
                      ValidIssuer = "chamados.webApi",

                      // nome do destinatário
                      ValidAudience = "chamados.webApi"
                  };
              });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ChamadosSenai v1"));
            }

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            // Habilita o CORS
            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
