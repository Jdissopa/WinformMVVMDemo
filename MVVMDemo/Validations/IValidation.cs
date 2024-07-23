using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo.Validations
{
    public interface IValidation<U>
    {
        string errMsg { get; }
        U Validated(U request);
    }
}
