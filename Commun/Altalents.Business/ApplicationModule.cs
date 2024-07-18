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
            services.AddScoped<IUtilisateurService, UtilisateurService>();
            services.AddScoped<IDossierTechniqueService, DossierTechniqueService>();
            services.AddScoped<IReferencesService, ReferencesService>();
            services.AddScoped<IJobService, JobService>();

            services.AddScoped<IUserStore<Utilisateur>, UtilisateurService>();
            services.AddScoped<SignInManager<Utilisateur>>();
            return services;
        }
    }
}
