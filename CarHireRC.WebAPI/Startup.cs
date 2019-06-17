using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarHireRC.WebAPI.Database;
using CarHireRC.WebAPI.Security;
using CarHireRC.WebAPI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CarHireRC.WebAPI
{
    public class BasicAuthDocumentFilter : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            var securityRequirements = new Dictionary<string, IEnumerable<string>>()
        {
            { "basic", new string[] { } }  // in swagger you specify empty list unless using OAuth2 scopes
        };

            swaggerDoc.Security = new[] { securityRequirements };
        }
    }
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAutoMapper();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
                c.AddSecurityDefinition("basic", new BasicAuthScheme() { Type = "basic" });
                c.DocumentFilter<BasicAuthDocumentFilter>();
            });

            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);


            services.AddScoped<IKorisnikService, KorisnikService>();
            services.AddScoped<ICRUDService<Model.Models.Automobil, Model.Requests.RezervacijaSearchRequest, Model.Requests.AutomobiliUPSERTtRequest, Model.Requests.AutomobiliUPSERTtRequest>,AutomobilService>();
            services.AddScoped<IService<Model.Models.Grad, Model.Requests.GradSearchRequest>,BaseService<Model.Models.Grad,Model.Requests.GradSearchRequest,Database.Grad>>();
            services.AddScoped<IService<Model.Models.KategorijaVozila,object>, BaseService<Model.Models.KategorijaVozila, object, Database.KategorijaVozila>>();
            services.AddScoped<IService<Model.Models.Uloge,object>, BaseService<Model.Models.Uloge, object, Database.Uloge>>();
            services.AddScoped<IService<Model.Models.KorisniciUloge,Model.Requests.KorisniciUlogeSearchRequest>, KorisniciUlogeService>();
            services.AddScoped<ICRUDService<Model.Models.Proizvodjac, Model.Requests.ProizvodjacSearchRequest, Model.Requests.ProizvodjacUpsertRequest, Model.Requests.ProizvodjacUpsertRequest>, ProizvodjacService>();
            services.AddScoped<ICRUDService<Model.Models.ModelAutomobila, Model.Requests.ModelAutomobilaSearch, Model.Requests.ModelAutomobilaUpsertRequest, Model.Requests.ModelAutomobilaUpsertRequest>, ModelService>();
            services.AddScoped<ICRUDService<Model.Models.Klijent, Model.Requests.KlijentSearchRequest, Model.Requests.KlijentUpsertRequest, Model.Requests.KlijentUpsertRequest>, KlijentService>();
            services.AddScoped<ICRUDService<Model.Models.RegistracijaVozila, Model.Requests.RegistracijaVozilaSearchRequest, Model.Requests.RegistracijaVozilaUpsertRequest, Model.Requests.RegistracijaVozilaUpsertRequest>, RegistracijaVozilaService>();
            services.AddScoped<ICRUDService<Model.Models.RezervacijaRentanja, Model.Requests.RezervacijaRentanjaSearchRequest, Model.Requests.RezervacijaRentanjaUpsertRequest, Model.Requests.RezervacijaRentanjaUpsertRequest>, RezervacijaRentanjaService>();
            services.AddScoped<ICRUDService<Model.Models.Poruka, Model.Requests.PorukaSearchRequest, Model.Requests.PorukaUpsertRequest, Model.Requests.PorukaUpsertRequest>, PorukaService>();
            services.AddScoped<ICRUDService<Model.Models.Racun, Model.Requests.RacunSearchRequest, Model.Requests.RacunUpsertRequest, Model.Requests.RacunUpsertRequest>, RacunService>();
            services.AddScoped<ICRUDService<Model.Models.Ocjena, Model.Requests.OcjenaSearchRequest, Model.Requests.OcjenaUpsertRequest, Model.Requests.OcjenaUpsertRequest>, OcjenaService>();

            services.AddScoped<IService<Model.Models.Drzava, Model.Requests.DrzavaSearchRequest>,BaseService<Model.Models.Drzava,Model.Requests.DrzavaSearchRequest,Database.Drzava>>();


            var connection = @"Server=.;Database=CarHireRC;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<CarHireRCContext>(options => options.UseSqlServer(connection));
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
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseAuthentication();
            //app.UseHttpsRedirection();
            app.UseMvc();

         

        }
    }
}
