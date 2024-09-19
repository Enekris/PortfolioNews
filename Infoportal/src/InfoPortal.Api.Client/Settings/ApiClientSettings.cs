using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoPortal.Api.Client.Settings
{
    public class ApiClientSettings
    {
        public TimeSpan? RequestTimeOut { get; set; }
        public string BaseAddress { get; set; }
        public string? Token { get; set; }
    }
}
