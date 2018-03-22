using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Infrastructure.Utils
{
    public static class AutoMapperExtensions
    {
        public static void ConfigureAutoMapper(IServiceCollection services)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var types = assemblies.SelectMany(pX => pX.ExportedTypes).ToArray();
            var profiles = types.Where(pX => typeof(Profile).GetTypeInfo().IsAssignableFrom(pX.GetTypeInfo()))
                .Where(pX => !pX.GetTypeInfo().IsAbstract);

            Mapper.Initialize(cfg =>
            {
                var configuration = cfg as MapperConfigurationExpression;
                foreach (var profile in profiles)
                {
                    var type = profile.GetTypeInfo();
                    if (configuration.Profiles.Where(pX => pX.GetType().GetTypeInfo() == type).Count() == 0)
                        cfg.AddProfile(profile);
                }
            });
        }
    }
}
