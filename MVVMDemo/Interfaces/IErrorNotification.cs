using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo.Interfaces
{
    public interface IErrorNotification
    {
        object InformError(object o);
    }
}
