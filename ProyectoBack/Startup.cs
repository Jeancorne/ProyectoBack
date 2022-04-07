using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using ProyectoBack.Application.Injection.v1;
using ProyectoBack.Infraestructure.Data;
using ProyectoBack.Infraestructure.Injection.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ProyectoBack.Application.Mapper;
using DC_Modelo_Arana.API.Setup.Configuration;

namespace ProyectoBack
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProyectoBack", Version = "v1" });
            });
            
            //Servicios de autenticación
            var secret = Configuration.GetValue<string>("KeySecret");
            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwt => {
                jwt.RequireHttpsMetadata = false;
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            //Claims/roles
            var ClaimsSistema = Configuration.GetSection("TokenSistema").Get<List<ClaseToken>>();
            services.AddAuthorization(options =>
            {
                foreach (var item in ClaimsSistema)
                {
                    options.AddPolicy(item.Token.ToString(), policy => policy.RequireClaim("Token", item.Token.ToString()));
                }
            });
            //Formato Json
            services.AddControllers()
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                options.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Ignore;
            });
            //Registrar las dependencias
            services.RegisterInfrastructerServices(Configuration);
            services.RegisterApplicationServices(Configuration);

            var mappeConfig = new MapperConfiguration(m =>{
                m.AddProfile(new MapperClass());
            });
            IMapper mapper = mappeConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProyectoBack v1"));
            }            

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseCors(builder => builder
              .AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
