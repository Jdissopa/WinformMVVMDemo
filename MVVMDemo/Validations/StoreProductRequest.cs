using MVVMDemo.Models;
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
        private string _errMsg = string.Empty;
        public string errMsg { get => _errMsg; }

        public Product Validated(Product request)
        {
            _errMsg = string.Empty;

            if (string.IsNullOrWhiteSpace(request.Name))
                _errMsg += $"ชื่อผลิตภัณฑ์จะต้องไม่เป็นช่องว่าง{Environment.NewLine}";
            else if (request.Name.Length > 255)
                _errMsg += $"ชื่อผลิตภัณฑ์จะต้องมีขนาดน้อยกว่า 255 ตัว{Environment.NewLine}";
            if (request.Price < 0)
                _errMsg += $"ราคาไม่สามารถติดลบได้{Environment.NewLine}";

            if (_errMsg != string.Empty)
                return null;

            return new Product { Name = request.Name, Price = request.Price };
        }
    }
}
