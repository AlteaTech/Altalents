using Altalents.Business.Services;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Altalents.Business
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, string connectionString,
            Dictionary<string, string> apiExternesRoutes)
        {
            services.AddInfrastructure(connectionString, apiExternesRoutes);
            services.AddAutoMapper(typeof(ApplicationModule));
            services.AddScoped<IReferenceService, ReferenceService>();
            services.AddScoped<ISousReferenceService, SousReferenceService>();
            services.AddScoped<IUtilisateurService, UtilisateurService>();
            services.AddScoped<IIntroductionService, IntroductionService>();
            services.AddScoped<ITexteDiversService, TexteDiversService>();
            services.AddScoped<IJobService, JobService>();
            services.AddScoped<IMarqueService, MarqueService>();
            services.AddScoped<IEmailService, EmailService>();

            services.AddScoped<IUserStore<Utilisateur>, UtilisateurService>();
            services.AddScoped<SignInManager<Utilisateur>>();
            return services;
        }
    }
}
