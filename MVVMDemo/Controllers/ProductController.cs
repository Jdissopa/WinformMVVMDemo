using MVVMDemo.Models;
using MVVMDemo.Notifications;
using MVVMDemo.Validations;
using MVVMDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo.Controllers
{
    public class ProductController
    {
        private ProductViewModel _productViewModel;

        public ProductController(ProductViewModel productViewModel)
        {
            _productViewModel = productViewModel;
        }

        public void Store()
        {
            Validator<Product> validator = new Validator<Product>(new StoreProductRequest())
                .SetErrorNotification(new ProductNotification());

            Product validatedProduct = validator.Validated(_productViewModel.GetProduct());
            if (validatedProduct == null)
                return;

            //อัพเดทรายการเพื่อการแสดงผล
            _productViewModel.AppendProductList(validatedProduct);

            //store validatedProduct to db
        }

        public void DestroyLast()
        {
            //อัพเดทรายการเพื่อการแสดงผล
            _productViewModel.RemoveLastProduct();

            //delete last product from db
        }
    }
}
