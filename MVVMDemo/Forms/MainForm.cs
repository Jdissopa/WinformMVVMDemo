using MVVMDemo.Controllers;
using MVVMDemo.Databases;
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
        private ProductController _productController;

        public MainForm()
        {
            InitializeComponent();

            _productViewModel = new ProductViewModel();
            productView1.SetViewModel(_productViewModel);

            _productController = new ProductController(_productViewModel, new LabDatabaseConnector());
        }

        private void simpleButtonAppend_Click(object sender, EventArgs e)
        {
            _productController?.Store();
        }

        private void simpleButtonPop_Click(object sender, EventArgs e)
        {
            _productController?.DestroyLast();
        }
    }
}
