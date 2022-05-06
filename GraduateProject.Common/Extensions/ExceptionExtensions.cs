using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateProject.Common.Extentions
{
    public static class ExceptionExtensions
    {
        public static string GetError(this Exception ex)
        {
            if (!string.IsNullOrEmpty(ex.InnerException?.Message))
            {
                return ex.InnerException.Message;
            }

            return ex.Message;

        }
    }
}
