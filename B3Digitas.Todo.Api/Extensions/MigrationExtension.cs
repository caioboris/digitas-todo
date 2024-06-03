﻿using B3Digitas.Todo.Data;
using Microsoft.EntityFrameworkCore;

namespace B3Digitas.Todo.Api.Extensions;

public static class MigrationExtension
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        using DataContext context = 
            scope.ServiceProvider.GetRequiredService<DataContext>();

        context.Database.Migrate();
    }
}
