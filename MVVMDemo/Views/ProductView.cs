using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MVVMDemo.ViewModels;

namespace MVVMDemo.Views
{
    public partial class ProductView : UserControl
    {
        private ProductViewModel _viewModel;
        public ProductView()
        {
            InitializeComponent();
        }

        public void SetViewModel(ProductViewModel viewModel)
        {
            _viewModel = viewModel;
            textEditName.DataBindings.Add("Text", _viewModel, "Name");
            textEditPrice.DataBindings.Add("Text", _viewModel, "Price");
            memoEditProductList.DataBindings.Add("Text", _viewModel, "ProductListText");
        }
    }
}
