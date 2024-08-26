namespace Siap.GUI.Services
{
    public static class ServicesExtensions
    {
        public static IServiceCollection ModelosServices(this IServiceCollection services)
        {
            services.AddScoped<IInstitucionService, InstitucionService>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IGradoService, GradoService>();
            services.AddScoped<IDireccionService, DireccionService>();
            services.AddScoped<IDepartamentoService, DepartamentoService>();
            services.AddScoped<IEscalafonService, EscalafonService>();
            services.AddScoped<ISeccionService, SeccionService>();
            services.AddScoped<IPersonalService, PersonalService>();
            services.AddScoped<IPerfilProfesionalService, PerfilProfesionalService>();

            return services;
        }
    }
}
