using GraduateProject.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduateProject.UI.Services
{
    public interface IFilter
    {
        Task<List<Doctor>> FilterByCityOrDepartmentOrRating(string? city, int? id, float? rating);
        Task<List<MedicalCenter>> FilterByCityOrRating(string? city, float? rating);
    }
}
