using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informer.InfoPortal.Persistence.Interfaces.Utils
{
    public interface IDateTimeConverterUtil
    {
        string DateTimeToUnixTimeshtamp(DateTime datetime);
    }
}
