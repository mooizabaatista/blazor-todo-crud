using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Todo.Application.Interfaces;
using Todo.Application.Mappings;
using Todo.Application.Services;
using Todo.Infra.Context;
using Todo.Infra.Interfaces;
using Todo.Infra.Repositories;

namespace Todo.IoC;

public static class NativeInjection
{    
    public static  IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Add DbContext
        services.AddDbContext<TodoContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        // Add Repositories
        services.AddScoped<ITodoRepository, TodoRepository>();

        // Add Services
        services.AddScoped<ITodoService, TodoService>();

        // Add AutoMapper
        services.AddAutoMapper(typeof(MappingProfile));

        return services;
    }
}
