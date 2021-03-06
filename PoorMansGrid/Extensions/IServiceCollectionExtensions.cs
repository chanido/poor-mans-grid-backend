﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace PoorMansGrid.Extensions
{
    public enum TextSearchOption { 
        Default,
        ForceCaseInsensitive
    }
    public static class IServiceCollectionExtensions
    {
        //
        // Summary:
        //     /// Adds PoorMan's Grid FilterService
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
        public static IServiceCollection AddPoorMansGridFilterService(this IServiceCollection services, TextSearchOption options = TextSearchOption.Default)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            OptionsServiceCollectionExtensions.AddOptions(services);
            ServiceCollectionDescriptorExtensions.TryAdd(services, ServiceDescriptor.Scoped<IFilterService>(s => new FilterService(options)));

            return services;
        }
    }
}
