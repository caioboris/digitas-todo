using B3Digitas.Todo.Business.Interfaces;
using B3Digitas.Todo.Business.Services;
using B3Digitas.Todo.Data;
using B3Digitas.Todo.Api.Extensions;
using B3Digitas.Todo.Data.Repository;
using B3Digitas.Todo.Data.Repository.Interfaces;
using B3Digitas.Todo.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<ITodoRepository, TodoRepository>();
builder.Services.AddScoped<ITagRepository, TagRepository>();

builder.Services.AddScoped<ITodoService, TodoService>();
builder.Services.AddScoped<ITagService, TagService>();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Database")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
