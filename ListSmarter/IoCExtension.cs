using FluentValidation;
using ListSmarter.Common;
using ListSmarter.Repositories;
using ListSmarter.Repositories.Models;
using ListSmarter.Services;
using ListSmarter.Models;
using ListSmarter.Models.Validators;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ListSmarter;

public static class IoCExtension
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddTransient<ITaskService, TaskService>();
        services.AddTransient<IBucketService, BucketService>();
        services.AddTransient<IPersonService, PersonService>();
    }
    
    public static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddTransient<ITaskRepository, TaskRepository>();
        services.AddTransient<IBucketRepository, BucketRepository>();
        services.AddTransient<IPersonRepository, PersonRepository>();
    }
    
    public static void RegisterValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<BucketDto>, BucketDtoValidator>();
        services.AddScoped<IValidator<PersonDto>, PersonDtoValidator>();
        services.AddScoped<IValidator<TaskDto>, TaskDtoValidator>();
    }
}