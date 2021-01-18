﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace PoorMansGrid.Extensions
{
    public enum PoorMansGridOptions { ForceCaseInsensitive }
    public static class IServiceCollectionExtensions
    {
        //
        // Summary:
        //     /// Adds a non distributed in memory implementation of PoorMan's Grid FilterService
        //     to the /// Microsoft.Extensions.DependencyInjection.IServiceCollection. ///
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection to add services
        //     to.
        //
        // Returns:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection so that additional
        //     calls can be chained.
        public static IServiceCollection AddPoorMansGrid(this IServiceCollection services, PoorMansGridOptions? options = null)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            OptionsServiceCollectionExtensions.AddOptions(services);
            ServiceCollectionDescriptorExtensions.TryAdd(services, ServiceDescriptor.Singleton(new FilterService(options)));
            return services;
        }
    }
}
