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
            services.AddSingleton<IDoctorsService, DoctorsService>();

            services.AddSingleton<IFileManagerService, FileManagerService>();

            services.AddSingleton<IHotelsService, HotelsService>();

            services.AddSingleton<ILanguageService, LanguageService>();

            services.AddSingleton<ILookupsCRUDService, LookupsCRUDService>();

            services.AddSingleton<IMedicalCentersService, MedicalCentersService>();

            services.AddSingleton<IPlacesToVisitService, PlacesToVisitService>();

            //services.AddSingleton<IReviewsService, ReviewsService>();

        }
    }
}
