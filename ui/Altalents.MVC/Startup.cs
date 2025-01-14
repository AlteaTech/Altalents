using System.Text.Json.Serialization;

using Altalents.Business;
using Altalents.Business.Jobs;
using Altalents.Business.Services;
using Altalents.Commun.Settings;
using Altalents.DataAccess;
using Altalents.DataAccess.Supervision;
using Altalents.Entities;
using Altalents.Infrastructure;
using AlteaTools.Api.Core.Exceptions;
using AlteaTools.Api.Core.Extensions;
using AlteaTools.Api.Core.Handler;
using AlteaTools.ApplicationInsight.Extensions;
using AlteaTools.Hangfire;
using AlteaTools.Hangfire.Extensions;
using AlteaTools.Hangfire.SqlServer.Extensions;
using Hangfire;
using Hangfire.Dashboard;

using Microsoft.ApplicationInsights.DependencyCollector;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using Serilog;

using Template.SupervisionMiddleware;

namespace Altalents.MVC
{
    public partial class Startup
    {
        private const string NOM_API = "Altalents UI";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            if (!ThreadPool.SetMinThreads(500, 500))
            {
                throw new TechnicalException($"Impossible de set le nombre de thread de sync à 500 et assync 500.");
            }

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "AltalentsApi", Version = "v1" });
            });
            services.AddSeedworkApplicationInsightServices(Configuration);
            services.AddBaseServices(Configuration);
            services
                .AddMvc()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            services.AddKendo();

            services.AddHttpContextAccessor();
            services.AddScoped(serviceProvider =>
            {
                NavigationManager uriHelper = serviceProvider.GetRequiredService<NavigationManager>();

                return new HttpClient
                {
                    BaseAddress = new Uri(uriHelper.BaseUri)
                };
            });

            services.AddHttpClient();
            services.AddControllersWithViews();

            Dictionary<string, string> apiExternesRoutes = new()
            {

            };

            services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhost", builder =>
                {
                    builder.WithOrigins("http://localhost:4200") // Adresse de votre application Angular
                           .AllowAnyHeader() // Autoriser tous les en-têtes (comme Authorization, Content-Type, etc.)
                           .AllowAnyMethod() // Autoriser toutes les méthodes HTTP (GET, POST, PUT, DELETE)
                           .AllowCredentials(); // Autoriser l'envoi de cookies ou jetons si nécessaire
                });
            });

            services.AddApplication(Configuration.GetConnectionString("Data"), apiExternesRoutes);
            services.AddScoped<FileService>();

            services.AddAuthenticationCore();
            services.AddScoped<ProtectedSessionStorage>();
            services.AddAutoMapper(typeof(Startup));
            services.AddDistributedMemoryCache();
            services.Configure<EmailSettings>(Configuration.GetSection(EmailSettings.Section));
            services.Configure<CommercialSettings>(Configuration.GetSection(CommercialSettings.Section));

            IConfigurationSection configurationHangfireSection = Configuration.GetSection(Commun.Settings.GlobalSettings.Section);
            GlobalSettings globalSettings = configurationHangfireSection.Get<GlobalSettings>();
            configurationHangfireSection = Configuration.GetSection(HangfireSettings.Section);

            services.AddSession(options =>
            {
                options.Cookie.Name = ".AdventureWorks.Session";
                options.IdleTimeout = TimeSpan.FromSeconds(globalSettings.TimeoutSessionSeconds);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.Configure<GlobalSettings>(Configuration.GetSection(GlobalSettings.Section));

            HangfireSettings hangfireSettings = configurationHangfireSection.Get<HangfireSettings>();
            services.AddHangfire(Configuration.GetConnectionString("Hangfire"), hangfireSettings);
            if (hangfireSettings.IsActivated)
            {
                services.AddScoped<IMonitoringElement, HangfireSupervision>();
            }
            services.AddDefaultIdentity<Utilisateur>(options => options.SignIn.RequireConfirmedAccount = false).AddSignInManager<SigninUtilisateurService>();
            services.AddAuthentication();
            services.PostConfigure<DataProtectionOptions>(p =>
            {
                if (p.ApplicationDiscriminator != null && (p.ApplicationDiscriminator.EndsWith("/") || p.ApplicationDiscriminator.EndsWith("\\")))
                    p.ApplicationDiscriminator = p.ApplicationDiscriminator[..^1];
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            IConfigurationSection configurationHangfireSection = Configuration.GetSection(Commun.Settings.HangfireSettings.Section);
            app.AddHangfireDashboard(configurationHangfireSection.Get<HangfireSettings>());
   
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AltalentsApi");
            });
            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/HomeAdmin/Error");
                app.UseHsts();
            }
            else
            {
                app.Use((ctx, next) =>
                {
                    return next();
                });
            }

            app.UseMiddleware<StatusCodeExceptionHandler>();
            app.UseSupervision(NOM_API, "/state");
            app.UseReadinessSupervision(NOM_API, "/readiness");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Ajouter le middleware CORS ici
            app.UseCors("AllowLocalhost");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "admin",
                    pattern: "Admin/{controller=Account}/{action=Index}/{id?}",
                    constraints: new { controller = @"^(?!Home$).*$" });
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "spaF",
                    pattern: "{*url}",
                    defaults: new { controller = "Home", action = "Index" });
            });

            Serilog.Core.Logger serilogLogger = new LoggerConfiguration()
                                .ReadFrom.Configuration(Configuration, "Serilog")
                                .CreateLogger();

            loggerFactory.AddSerilog(serilogLogger);
            JobScheduler.ScheduleRecurringJobs("UI");

            IConfigurationSection configurationGlobalSettings = Configuration.GetSection(Commun.Settings.GlobalSettings.Section);
            GlobalSettings globalSettings = configurationGlobalSettings.Get<GlobalSettings>();
            if (globalSettings.AutoMigrate)
            {
                using (IServiceScope serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    MigrationContext context = new();
                    context.Database.GetDbConnection().ConnectionString = Configuration.GetConnectionString("Data");
                    context.Database.Migrate();
                }
            }
        }
    }
}
