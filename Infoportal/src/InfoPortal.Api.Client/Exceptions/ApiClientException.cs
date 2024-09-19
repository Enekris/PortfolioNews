using InfoPortal.Api.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InfoPortal.Api.Client.Exceptions
{
    public class ApiClientException : Exception
    {
        public string TittleMessage = "Ошибка";
        public string ErrorMessage { get; set; }
        public string ErrorLog { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public ApiClientException(ErrorModel model) : base(model.ErrorMessage)
        {
            ErrorMessage = model.ErrorMessage;
            ErrorLog = model.ErrorLog;
            StatusCode = (HttpStatusCode)model.StatusCode;
        }
    }
}
