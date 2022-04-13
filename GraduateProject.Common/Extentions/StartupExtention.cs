using GraduateProject.Common.Services;
using GraduateProject.Common.Services.Doctors;
using GraduateProject.Common.Services.FileManager;
using GraduateProject.Common.Services.Hotels;
using GraduateProject.Common.Services.Languages;
using GraduateProject.Common.Services.Lookups;
using GraduateProject.Common.Services.MedicalCenters;
using GraduateProject.Common.Services.PlacesToVisit;
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
            services.AddScoped<IDoctorsService, DoctorsService>();

            services.AddScoped<IFileManagerService, FileManagerService>();

            services.AddScoped<IHotelsService, HotelsService>();

            services.AddScoped<ILanguageService, LanguageService>();

            services.AddScoped<ILookupsCRUDService, LookupsCRUDService>();

            services.AddScoped<IMedicalCentersService, MedicalCentersService>();

            services.AddScoped<IPlacesToVisitService, PlacesToVisitService>();

            //services.AddSingleton<IReviewsService, ReviewsService>();

        }
    }
}
