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
        public object InformError(object o)
        {
            MessageBox.Show(o.ToString());
            return o;
        }
    }
}
