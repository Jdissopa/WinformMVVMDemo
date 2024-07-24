using MVVMDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVVMDemo.Notifications
{
    public class ProductNotification : IErrorNotification
    {
        public object InformError(NotificationObj notificationObj)
        {
            string errors = string.Join(Environment.NewLine, notificationObj.ErrorMessages);
            MessageBox.Show(errors);

            return null;
        }
    }
}
