using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodFloater.DAL;
using BloodFloater.DAL.Impl;
using Microsoft.Extensions.DependencyInjection;

namespace BloodFloater.Infrastructure
{
    public static class ConfigureRepositories
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IDonorRepository, DonorRepository>();
            services.AddScoped<IReceiverRepository, ReceiverRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

        }
    }
}
