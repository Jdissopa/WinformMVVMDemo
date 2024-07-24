using MVVMDemo.Models;
using MVVMDemo.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVVMDemo.Validations
{
    public class StoreProductRequest : IValidation<Product>
    {
        private NotificationObj _notiObj;
        public StoreProductRequest()
        {
            _notiObj = new NotificationObj();
        }

        public NotificationObj GetNotifications()
        {
            return _notiObj;
        }

        public Product Validated(Product request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                _notiObj.ErrorMessage = "ชื่อผลิตภัณฑ์จะต้องไม่เป็นช่องว่าง";
            else if (request.Name.Length > 255)
                _notiObj.ErrorMessage = "ชื่อผลิตภัณฑ์จะต้องมีขนาดน้อยกว่า 255 ตัว";
            if (request.Price < 0)
                _notiObj.ErrorMessage = "ราคาไม่สามารถติดลบได้";

            if (_notiObj.ErrorMessages.Count > 0)
                return null;

            return new Product { Id = request.Id, Name = request.Name, Price = request.Price };
        }
    }
}
