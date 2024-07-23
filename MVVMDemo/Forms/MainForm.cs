using MVVMDemo.Models;
using MVVMDemo.Notifications;
using MVVMDemo.Validations;
using MVVMDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVVMDemo.Forms
{
    public partial class MainForm : Form
    {
        private ProductViewModel _productViewModel;

        public MainForm()
        {
            InitializeComponent();

            _productViewModel = new ProductViewModel()
                .SetValidator(new StoreProductRequest())
                .SetNotification(new ProductNotification());

            productView1.SetViewModel(_productViewModel);
        }

        private void simpleButtonAppend_Click(object sender, EventArgs e)
        {
            //if (productView1.)
            //new ProductNotification().InformError("ราคาต้องเป็นตัวเลขเท่านั้น");
            //return;
            _productViewModel.SaveProduct();
        }

        private void simpleButtonPop_Click(object sender, EventArgs e)
        {
            _productViewModel.RemoveLastProduct();
        }
    }
}
