using CoodeshTest.Application.App;
using CoodeshTest.Application.Config;
using CoodeshTest.Application.Interfaces;
using CoodeshTest.Domain.Interfaces;
using CoodeshTest.Infra.Data.Context;
using CoodeshTest.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoodeshTest.Infra.Dependency
{
    public static class ConfigContainer
    {
        public static IServiceCollection AddInfrastrucure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            //Repositorys
            services.AddScoped<ICollaboratorRepository, CollaboratorRepository>();
            services.AddScoped<ICreatorRepository, CreatorRepository>();
            services.AddScoped<IAffiliatedRepository, AffiliatedRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            //Services
            services.AddScoped<ICollaboratorService, CollaboratorService>();
            services.AddScoped<ICreatorService, CreatorService>();
            services.AddScoped<IAffiliatedService, AffiliatedService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddAutoMapper(typeof(DominioToDtoProfile));

            return services;
        }
    }
}
