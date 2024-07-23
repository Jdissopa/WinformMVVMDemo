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
      

        public ProductViewModel()
        {
            _product = new Product();
            _productList = new List<Product>();
        }

        public Product GetProduct()
        {
            return _product;
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

        public void AppendProductList(Product product)
        {
            _productList.Add(product);
            ClearInput();
            UpdateProductListText();
        }

        public Product RemoveLastProduct()
        {
            if (_productList.Count <= 0)
            {
                return null;
            }

            Product lastProduct = _productList.ElementAt(_productList.Count - 1);
            _productList.RemoveAt(_productList.Count - 1);
            UpdateProductListText();

            return lastProduct;
        }

        private void ClearInput()
        {
            Name = "";
            Price = 0;
        }
    }
}
