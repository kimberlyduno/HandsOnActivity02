using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace HandsOnActivity02
{
    public partial class frmAddProduct : Form
    {
        private string _ProductName;
        private string _Category;
        private string _MfgDate;
        private string _ExpDate;
        private string _Description;
        private int _Quantity;
        private double _SellPrice;
        private Boolean good = false;

        BindingSource showProductList = new BindingSource();

        public frmAddProduct()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ListOfProductCategory = new String[]
            {
                "Beverages",
                "Bread / Bakery",
                "Canned / Jarred Goods",
                "Dairy",
                "Frozen Goods",
                "Meat",
                "Personal Care",
                "Other"
            };
            foreach(String item in ListOfProductCategory)
            {
                cbCategory.Items.Add(item);
            }
        }
        public string Product_Name(string name)
        {
            if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
            {
                throw new StringFormatException();
            }
                
                return name;
        }
        public int Quantity(string qty)
        {
            if (!Regex.IsMatch(qty, @"^[0-9]"))
            {
                throw new NumberFormatException();
            }
                
                return Convert.ToInt32(qty);
        }
        public double SellingPrice(string price)
        {
            if (!Regex.IsMatch(price.ToString(), @"^(\d*\.)?\d+$"))
            {
                throw new CurrencyFormatException();
            }
                
                return Convert.ToDouble(price);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                _ProductName = Product_Name(txtProductName.Text);
                _Category = cbCategory.Text;
                _MfgDate = dtPickerMfgDate.Value.ToString("yyyy-MM-dd");
                _ExpDate = dtPickerExpDate.Value.ToString("yyyy-MM-dd");
                _Description = richTxtDescription.Text;
                _Quantity = Quantity(txtQuantity.Text);
                _SellPrice = SellingPrice(txtSellPrice.Text);
                showProductList.Add(new ProductClass(_ProductName, _Category, _MfgDate, _SellPrice, _Quantity, _Description));
                gridViewProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                gridViewProductList.DataSource = showProductList;
            }
            catch(StringFormatException kim)
            {
                MessageBox.Show("Please Product Again");
            }
            catch (NumberFormatException kim)
            {
                MessageBox.Show("Please Enter Valid Qty");
            }
            catch (CurrencyFormatException kim)
            {
                MessageBox.Show("Please Enter Valid Currency");
            }
        }

    }
}

public class StringFormatException : Exception
{
    public StringFormatException()
    {
    }

    public StringFormatException(string name) : base(name)
    {

    }
}
public class NumberFormatException : Exception
{
    public NumberFormatException()
    {
    }

    public NumberFormatException(string qty) : base(qty)
    {

    }
}
public class CurrencyFormatException : Exception
{
    public CurrencyFormatException()
    {
    }

    public CurrencyFormatException(string price) : base(price)
    {

    }
}
