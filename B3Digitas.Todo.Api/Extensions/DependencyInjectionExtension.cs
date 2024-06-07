using B3Digitas.Todo.Business.Extensions;
using B3Digitas.Todo.Data.Extensions;

namespace B3Digitas.Todo.Api.Extensions;

public static class DependencyInjectionExtension
{
    public static void AddDependencyInjection(this IServiceCollection services)
    {
        services.RegisterRepositories()
            .RegisterServices();
    }

}
