using GraduateProject.Common.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateProject.Common.Extentions
{
    public static class StartupExtention
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IDoctorsService, DoctorsService>();

        }
    }
}
