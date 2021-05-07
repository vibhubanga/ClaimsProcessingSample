﻿using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ClaimsProcessingSample.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructureMappings(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}