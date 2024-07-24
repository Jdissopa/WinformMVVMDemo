using MVVMDemo.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo.Validations
{
    public interface IValidation<U>
    {
        NotificationObj GetNotifications();
        U Validated(U request);
    }
}
