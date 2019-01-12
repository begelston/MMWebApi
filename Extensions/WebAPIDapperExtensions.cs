using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MMWebApi.Configuration;
using MMWebApi.Interfaces;
using MMWebApi.Repositories;

namespace MMWebApi.Extensions
{
    public static class DapperBuilderExtensions
    {
        public static IServiceCollection AddDapperConfigurationStore(
        this IServiceCollection builder, Action<SqlDBConfiguration> setupAction)
        {
            builder.Configure(setupAction);

            return builder.AddDapperConfigurationStore();
        }

        public static IServiceCollection AddDapperConfigurationStore(
        this IServiceCollection builder, IConfiguration configuration)
        {
            builder.Configure<SqlDBConfiguration>(configuration);

            return builder.AddDapperConfigurationStore();
        }

        private static IServiceCollection AddDapperConfigurationStore(
        this IServiceCollection builder)
        {
            //builder.AddScoped<IMemberRepository, MemberRepository>();            
            builder.AddScoped<IMemberRepository, MemberRepository>();
            return builder;
        }


    }

}
