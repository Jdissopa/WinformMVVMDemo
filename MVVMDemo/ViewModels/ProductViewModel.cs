using MVVMDemo.Interfaces;
using MVVMDemo.Models;
using MVVMDemo.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo.ViewModels
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        private Product _product;
        private List<Product> _productList;
        private string _productListText;

        private IErrorNotification _errorNotification;

        private IValidation<Product> _validator;
      

        public ProductViewModel()
        {
            _product = new Product();
            _productList = new List<Product>();
        }

        public ProductViewModel SetValidator(IValidation<Product> validator)
        {
            _validator = validator;
            return this;
        }

        public ProductViewModel SetNotification(IErrorNotification errNoti)
        {
            _errorNotification = errNoti;
            return this;
        }

        public int Id
        {
            get { return _product.Id; }
        }
        
        public string Name
        {
            get { return _product.Name; }
            set
            {
                if(_product.Name != value)
                {
                    _product.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public decimal Price
        {
            get { return _product.Price; }
            set
            {
                if (_product.Price != value)
                {
                    _product.Price = value;
                    OnPropertyChanged("Price");
                }
            }
        }

        public string ProductListText
        {
            get { return _productListText; }
            set
            {
                _productListText = value;
                OnPropertyChanged("ProductListText");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void UpdateProductListText()
        {
            ProductListText = string.Join(Environment.NewLine, _productList.Select(p => $"{p.Name} - {p.Price:C}"));
        }

        public void SaveProduct()
        {
            Product p = _validator != null? _validator.Validated(_product) : new Product { Name = _product.Name, Price = _product.Price };

            if (p == null)
            {
                _errorNotification?.InformError(_validator.errMsg);
                return;
            }

            _productList.Add(p);
            ClearInput();
            UpdateProductListText();
        }

        public void RemoveLastProduct()
        {
            if (_productList.Count <= 0)
            {
                _errorNotification?.InformError("ไม่มีรายการแล้ว");
                return;
            }

            _productList.RemoveAt(_productList.Count - 1);
            UpdateProductListText();
        }

        private void ClearInput()
        {
            Name = "";
            Price = 0;
        }
    }
}
