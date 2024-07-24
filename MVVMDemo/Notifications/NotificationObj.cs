using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo.Notifications
{
    public class NotificationObj
    {
        private List<string> _errMsgs;
        private string _errMsg;

        public NotificationObj()
        {
            _errMsgs = new List<string>();
        }

        public List<string> ErrorMessages { get => _errMsgs; }

        public string ErrorMessage { set => _errMsgs.Add(value); }
    }
}
