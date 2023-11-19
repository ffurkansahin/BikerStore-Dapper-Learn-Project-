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
    public partial class UpdateProductForm : Form
    {
        int productId;
        public UpdateProductForm(int product_id)
        {
            InitializeComponent();
            productId = product_id;
        }

        private void UpdateProductForm_Load(object sender, EventArgs e)
        {
            GetBrands();
            GetCategories();
            GetProductById();
        }

        void GetBrands()
        {
            using(BrandRepository brandRepository = new BrandRepository())
            {
                cmbBrands.DisplayMember = "brand_name";
                cmbBrands.ValueMember = "brand_id";
                cmbBrands.DataSource = brandRepository.GetAllData();
            }
        }
        void GetCategories()
        {
            using(CategoryRepository categoryRepository = new CategoryRepository()) 
            {
                cmbCategories.DisplayMember = "category_name";
                cmbCategories.ValueMember = "category_id";
                cmbCategories.DataSource = categoryRepository.GetAllData();
            }
        }

        void GetProductById()
        {
            using(ProductRepository productRepository = new ProductRepository())
            {
                var dataItem = productRepository.GetDataById(productId);
                txtProductName.Text = dataItem.product_name;
                txtModelYear.Text = dataItem.model_year.ToString();
                txtPrice.Text = dataItem.list_price.ToString();
                cmbBrands.SelectedValue = dataItem.brand_id;
                cmbCategories.SelectedValue = dataItem.category_id;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (ProductRepository productRepository = new ProductRepository())
            {
                UpdateProductSP dataItem = new UpdateProductSP();
                dataItem.product_id = productId;
                dataItem.product_name = txtProductName.Text;
                dataItem.model_year = int.Parse(txtModelYear.Text);
                dataItem.list_price=decimal.Parse(txtPrice.Text);
                dataItem.brand_id = (int)cmbBrands.SelectedValue;
                dataItem.category_id = (int)cmbCategories.SelectedValue;
                int returnvalue = productRepository.UpdateData(dataItem);
                if (returnvalue == 0) MessageBox.Show("Product couldn't update", "Info");
                else MessageBox.Show("Product updated", "Info");




            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using(ProductRepository productRepository = new ProductRepository())
            {
                int returnvalue =productRepository.DeleteData(new UpdateProductSP() { product_id = productId });
                if (returnvalue == 1) this.Close();
            }
        }
    }
}
