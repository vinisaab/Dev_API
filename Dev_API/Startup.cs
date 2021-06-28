using Dev_API.Dominio.Interfaces.Negocio;
using Dev_API.Dominio.Interfaces.Repositório;
using Dev_API.Negocio;
using Dev_API.Repositorio.Conexao;
using Dev_API.Repositorio.Repositorios;
using Dev_API.ServicoExterno.GitHub;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IO.Compression;
using Utilitario.JWT;

namespace Dev_API
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
            services.AddHttpClient();


            var key = System.Text.Encoding.ASCII.GetBytes(JwtSecret.SecretKey);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            //Menor trafego de dados
            services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Optimal);
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
            });

            // O m�todo AddJsonOptions permite a customiza��o das configura��es de serializa��o
            // Ignorar propriedades nulas
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreNullValues = true;
            });

            InjecaoDeDependencia(services);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Dev_API", Version = "v1" });
               
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
{
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            BearerFormat = "JWT",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        Array.Empty<string>()
                        }
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dev_API v1")
                ) ;
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void InjecaoDeDependencia(IServiceCollection services)
        {
            
            #region Negocio
            services.AddScoped<IDevNegocio, DevNegocio>();
            services.AddScoped<IGithubNegocio, GitHubNegocio>();
            services.AddScoped<ILinguagemNegocio, LinguagemNegocio>();
            services.AddScoped<IDevLinguagemNegocio, DevLinguagemNegocio>();
            services.AddScoped<IAutenticacaoNegocio, AutenticacaoNegocio>();
            #endregion Negocio

            #region Repositorio
            services.AddScoped<IConexaoSqlServer, ConexaoSqlServer>();
            services.AddScoped<IDevRepositorio, DevRepositorio>();
            services.AddScoped<ILinguagemRepositorio, LinguagemRepositorio>();
            services.AddScoped<IDevLinguagemRepositorio, DevLinguagemRepositorio>();
            services.AddScoped<IAutenticacaoRepositorio, AutenticacaoRepositorio>();
            #endregion Repositorio

            #region ServicoExterno
            services.AddScoped<IGitHub, GitHub>();
            #endregion ServicoExterno

        }
    }
}
