using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloodFloater.DAL;
using BloodFloater.DAL.Impl;
using BloodFloater.Services;
using BloodFloater.Services.Impl;
using Microsoft.Extensions.DependencyInjection;

namespace BloodFloater.Infrastructure
{
    public static class ConfigureServiceImpl
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IDonorService, DonorService>();
            services.AddScoped<IReceiverService, ReceiverService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILookupService, LookupService>();
            services.AddScoped<IProfileService, ProfileService>();
        }
    }
}
