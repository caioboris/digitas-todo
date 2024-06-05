using B3Digitas.Todo.Business.Interfaces;
using B3Digitas.Todo.Business.Services;
using B3Digitas.Todo.Data.Repository.Interfaces;
using B3Digitas.Todo.Data.Repository;
using B3Digitas.Todo.Domain.Repositories;

namespace B3Digitas.Todo.Api.Extensions;

public static class DependencyInjectionExtension
{
    public static void AddDependencyInjection(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ITodoRepository, TodoRepository>();
        builder.Services.AddScoped<ITagRepository, TagRepository>();
        builder.Services.AddScoped<ITodoService, TodoService>();
        builder.Services.AddScoped<ITagService, TagService>();
    }
}
