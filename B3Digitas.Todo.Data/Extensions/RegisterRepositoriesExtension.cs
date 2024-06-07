using B3Digitas.Todo.Data.Repository;
using B3Digitas.Todo.Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace B3Digitas.Todo.Data.Extensions;

public static class RegisterRepositoriesExtension
{
    public static IServiceCollection RegisterRepositories(this IServiceCollection service)
    {
        service.AddScoped<ITagRepository, TagRepository>();
        service.AddScoped<ITodoRepository, TodoRepository>();

        return service;
    }
}
