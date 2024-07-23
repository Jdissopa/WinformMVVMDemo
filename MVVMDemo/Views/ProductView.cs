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
using DevExpress.XtraEditors;

namespace MVVMDemo.Views
{
    public partial class ProductView : UserControl
    {
        private ProductViewModel _viewModel;
        public ProductView()
        {
            InitializeComponent();
        }

        private Binding BindingPriceWithFormat()
        {
            var binding = new Binding("Text", _viewModel, nameof(ProductViewModel.Price), true, DataSourceUpdateMode.OnPropertyChanged);
            binding.Format += (sender, e) =>
            {
                // Format the decimal value with commas
                if (e.DesiredType == typeof(string) && e.Value is decimal decimalValue)
                {
                    e.Value = decimalValue.ToString("N");
                }
            };
            binding.Parse += (sender, e) =>
            {
                // Parse the string value back to decimal
                if (e.DesiredType == typeof(decimal) && e.Value is string stringValue)
                {
                    if (decimal.TryParse(stringValue, out decimal result))
                    {
                        e.Value = result;
                    }
                    else
                    {
                        e.Value = 0; // or handle invalid input as needed
                    }
                }
            };

            return binding;
        }

        public void SetViewModel(ProductViewModel viewModel)
        {
            _viewModel = viewModel;
            textEditName.DataBindings.Add("Text", _viewModel, "Name");
          
            
            textEditPrice.DataBindings.Add(BindingPriceWithFormat());
            //textEditPrice.DataBindings.Add("Text", _viewModel, "Price");
            memoEditProductList.DataBindings.Add("Text", _viewModel, "ProductListText");
        }

        private void textEditPrice_KeyUp(object sender, KeyEventArgs e)
        {
            // Cast sender to TextBox
            TextEdit textBox = sender as TextEdit;

            if (textBox == null)
                return;

            if (e.KeyCode == Keys.OemPeriod || e.KeyCode == Keys.Decimal || 
                e.KeyCode == Keys.Enter || e.KeyCode == Keys.Back || e.KeyCode == Keys.Subtract)
                return;

            decimal price;
            bool success = decimal.TryParse(textBox.Text, out price);
            if (!success)
                MessageBox.Show("กรุณาใส่เฉพาะตัวเลข");
        }

        private void textEditPrice_Enter(object sender, EventArgs e)
        {
            TextEdit textBox = sender as TextEdit;

            if (textBox == null)
                return;

            decimal price;
            bool success = decimal.TryParse(textBox.Text, out price);

            if (!success)
                return;

            if (price == 0)
                textBox.Text = "";

            textBox.Text = textBox.Text.Replace(",", "");
        }

        private void textEditPrice_Leave(object sender, EventArgs e)
        {
            TextEdit textBox = sender as TextEdit;

            if (textBox == null)
                return;
            
            if (string.IsNullOrWhiteSpace(textBox.Text))
                textBox.Text = "0";

            decimal price;
            bool success = decimal.TryParse(textBox.Text, out price);
            if (success)
                textBox.Text = price.ToString("N");
        }
    }
}
