﻿using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Volo.Abp.AspNetCore.Components.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.UI;

namespace Volo.Abp.AspNetCore.Components.UI
{
    [DependsOn(
        typeof(AbpUiModule),
        typeof(AbpAspNetCoreComponentsModule)
        )]
    public class AbpAspNetCoreComponentsUIModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {

        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.Replace(ServiceDescriptor.Transient<IComponentActivator, ServiceProviderComponentActivator>());

            //context.Services
            //    .GetHostBuilder().Logging
            //    .AddProvider(new AbpExceptionHandlingLoggerProvider(context.Services));
        }
    }
}
