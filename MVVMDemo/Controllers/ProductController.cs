using MVVMDemo.Databases;
using MVVMDemo.Interfaces;
using MVVMDemo.Models;
using MVVMDemo.Notifications;
using MVVMDemo.Validations;
using MVVMDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVVMDemo.Controllers
{
    public class ProductController
    {
        private ProductViewModel _productViewModel;
        private ProductDatabase _database;

        public ProductController(ProductViewModel productViewModel, IDatabase database)
        {
            _productViewModel = productViewModel;
            _database = new ProductDatabase(database);
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
            int result = (int)_database.Store(validatedProduct);
            validatedProduct.Id = result;
        }

        public void DestroyLast()
        {
            //อัพเดทรายการเพื่อการแสดงผล
            Product removed = _productViewModel.RemoveLastProduct();

            //delete last product from db
            bool result = _database.Delete(removed);
        }
    }
}
