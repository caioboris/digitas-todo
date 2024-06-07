using B3Digitas.Todo.Business.Services;
using B3Digitas.Todo.Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace B3Digitas.Todo.Business.Extensions;

public static class RegisterServicesExtension
{
    public static IServiceCollection RegisterServices(this IServiceCollection service)
    {
        service.AddScoped<ITagService, TagService>();
        service.AddScoped<ITodoService, TodoService>();

        return service;
    }
}
