using BikerStoreWUI.Models.StoreProcedure;
using BikerStoreWUI.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BikerStoreWUI.Forms
{
    public partial class InsertProductForm : Form
    {
        public InsertProductForm()
        {
            InitializeComponent();
        }

        private void InsertProductForm_Load(object sender, EventArgs e)
        {
            GetBrands();
            GetCategories();
        }

        void GetBrands()
        {
            using (BrandRepository brandRepository = new BrandRepository())
            {
                cmbBrands.DisplayMember = "brand_name";
                cmbBrands.ValueMember = "brand_id";
                cmbBrands.DataSource = brandRepository.GetAllData();
            }
        }
        void GetCategories()
        {
            using (CategoryRepository categoryRepository = new CategoryRepository())
            {
                cmbCategories.DisplayMember = "category_name";
                cmbCategories.ValueMember = "category_id";
                cmbCategories.DataSource = categoryRepository.GetAllData();
            }
        }

        private void btnNewProduct_Click(object sender, EventArgs e)
        {
            using (ProductRepository productRepository = new ProductRepository())
            {
                UpdateProductSP dataItem = new UpdateProductSP();
                dataItem.product_name = txtProductName.Text;
                dataItem.model_year=int.Parse(txtModelYear.Text);
                dataItem.list_price = decimal.Parse(txtPrice.Text);
                dataItem.brand_id=(int)cmbBrands.SelectedValue;
                dataItem.category_id=(int)cmbCategories.SelectedValue;

                int returnvalue = productRepository.InsertData(dataItem);
                if (returnvalue > 0) MessageBox.Show("Product added", "Info");
                else MessageBox.Show("Product couldn't add");
            }

        }
    }
}
