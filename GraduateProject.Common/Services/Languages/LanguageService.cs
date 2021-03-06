using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateProject.Common.Services.Languages
{
    public class LanguageService : ILanguageService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LanguageService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetLanguageIdFromRequestAsync()
        {
            try
            {
                if (_httpContextAccessor.HttpContext?.Request == null)
                    return null;

                //get request culture
                var requestCulture = "";
                _httpContextAccessor.HttpContext.Request.Cookies.TryGetValue("langId" , out requestCulture);
                if (requestCulture == "")
                    return null;

                var currentCultureString = requestCulture; //.Split('-')[0].Trim();

                
                return currentCultureString;
            }
            catch (Exception)
            {
                //TODO log ex.GetError()
                return null;
            }
        }
    }
}
