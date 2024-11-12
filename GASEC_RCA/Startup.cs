using GASEC_RCA.Data;
using GASEC_RCA.ResultatService;
using GASEC_RCA.Service;
using GASEC_RCA.ServiceResultat;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MudBlazor.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace GASEC_RCA
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
            //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzU2MDE4NEAzMjMwMmUzNDJlMzBaRTc3U2s1dUpNcFVseC92UTFMbVg4cG5VMUxPSVFnK3E0N2kweFJKcFU4PQ==");
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzU2MDE4NUAzMjM3MmUzMDJlMzBCdFY4U2d1bGxZbDFRM050N1Y3dUFHSS9EYXlKb2g3cFFkM21GVUhVb2pFPQ==");
            services.AddRazorPages();
			services.AddServerSideBlazor();
			services.AddSingleton<WeatherForecastService>();

			services.AddScoped<ActesNaissService>();
			services.AddScoped<ActesDeNaissance>();
			services.AddScoped<ActesNaissResultatService>();

			services.AddScoped<ActesMariageService>();
			services.AddScoped<ActesDeMariage>();
			services.AddScoped<ActesMariageResultatService>();

			services.AddScoped<AuthentificationService>();
            services.AddScoped<Authentification>();
            services.AddScoped<AuthentificationResultatService>();

            services.AddScoped<GeographieService>();
			services.AddScoped<Geographie>();
			services.AddScoped<GeographieResultatService>();

			services.AddScoped<RegionService>();
			services.AddScoped<Region>();
			services.AddScoped<RegionResultatService>();
			
            services.AddScoped<PrefectureQuery>();
            services.AddScoped<Prefecture>();
            services.AddScoped<PrefectureResultatService>();

			services.AddScoped<RoleServices>();
			services.AddScoped<Role>();
			services.AddScoped<RoleResultatService>();

			services.AddScoped<ZoneService>();
			services.AddScoped<Zone>();
			services.AddScoped<ZoneResultatService>();

			services.AddScoped<NationaliteService>();
			services.AddScoped<Nationalite>();
			services.AddScoped<NationaliteResultatService>();

			services.AddScoped<UtilisateurService>();
			services.AddScoped<Utilisateur>();
			services.AddScoped<UtilisateurResultatService>();

            services.AddScoped<SessionState>();

            services.AddScoped<HttpClient>();
			services.AddMudServices();
			services.AddControllersWithViews();

			// La partie suivante concerne la partie Login
			services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
			.AddCookie(options =>
			{
				options.Cookie.Name = "auth_token";
				options.LoginPath = "/Login";
				options.Cookie.MaxAge = TimeSpan.FromSeconds(30);
				options.AccessDeniedPath = "/access-denied";
			});

			services.AddAuthorization();
			services.AddDistributedMemoryCache();
			
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapBlazorHub();
				endpoints.MapFallbackToPage("/_Host");
			});
		}
	}
}
