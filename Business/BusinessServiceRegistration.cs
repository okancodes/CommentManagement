using Business.Abstracts;
using Business.Concretes;
using Core.Business.Rules;
using Core.Entities.Concrete;
using Core.Utilities.Security.JWT;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Business
{
    public static class BusinessServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IUserOperationClaimService, UserOperationClaimManager>();
            services.AddScoped<IOperationClaimService, OperationClaimManager>();
            services.AddScoped<IAssignmentService, AssignmentManager>();
            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<IUserAssignmentService, UserAssignmentManager>();
            services.AddScoped<IAuthService, AuthManager>();
            services.AddSingleton<ITokenHelper, JwtHelper>(); 

            var assembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assembly);
            services.AddSubClassesOfType(assembly, typeof(BaseBusinessRules<Entity<Guid>>));
            return services;



        }
        public static IServiceCollection AddSubClassesOfType(
            this IServiceCollection services,
            Assembly assembly,
            Type type,
            Func<IServiceCollection,
                Type,
                IServiceCollection>? addWithLifeCycle = null)
        {
            var types = assembly.GetTypes().Where(t => t.BaseType?.Name == type.Name && t != type).ToList();
            foreach (var item in types)
                if (addWithLifeCycle == null)
                    services.AddScoped(item);

                else
                    addWithLifeCycle(services, type);
            return services;
        }
    }
}
