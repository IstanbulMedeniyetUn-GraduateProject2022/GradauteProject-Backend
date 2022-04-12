using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateProject.Common.Enums
{
    public enum ResponseType
    {
        Error,
        Success,
        HasTransactions,
        ModelNotValid,
    }
    public class ResponseResult
    {
        public ResponseResult(ResponseType responseType)
        {
            ResponseType = responseType;
        }

        public ResponseResult(ResponseType responseType, string responseText)
        {
            ResponseType = responseType;
            ResponseText = responseText;
        }

        public ResponseResult(ResponseType responseType, dynamic result)
        {
            ResponseType = responseType;
            Result = result;
        }

        public ResponseResult(ResponseType responseType, string responseText, dynamic result)
        {
            ResponseType = responseType;
            ResponseText = responseText;
            Result = result;
        }

        public ResponseType ResponseType { get; set; }

        [StringLength(100)]
        public string ResponseText { get; set; }

        public dynamic Result { get; set; }
    }
}
