using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace ProSoft.Forms
{
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
            LoadProducts();
            SetupDataGridView();
            LoadCategories();
        }

        private void SetupDataGridView()
        {
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.RowHeadersVisible = false;
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.Columns["ProductID"].Visible = false;
            dgvProducts.Columns["CategoryID"].Visible = false;
        }

        private void LoadCategories()
        {
            try
            {
                using (var conn = new SqlConnection(Properties.Settings.Default["ProSoftConnectionString"].ToString()))
                {
                    conn.Open();
                    string query = "SELECT CategoryID, CategoryName FROM ProductCategories WHERE IsActive = 1";

                    var adapter = new SqlDataAdapter(query, conn);
                    var dt = new DataTable();
                    adapter.Fill(dt);

                    cboCategory.DataSource = dt;
                    cboCategory.DisplayMember = "CategoryName";
                    cboCategory.ValueMember = "CategoryID";
                    cboCategory.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục sản phẩm: " + ex.Message,
                              "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProducts()
        {
            try
            {
                using (var conn = new SqlConnection(Properties.Settings.Default["ProSoftConnectionString"].ToString()
))
                {
                    conn.Open();
                    string query = @"SELECT p.ProductID, p.ProductName, p.Barcode, p.Price, 
                                   p.StockQuantity, p.CategoryID, c.CategoryName, p.IsActive
                                   FROM Products p
                                   LEFT JOIN ProductCategories c ON p.CategoryID = c.CategoryID";

                    var adapter = new SqlDataAdapter(query, conn);
                    var dt = new DataTable();
                    adapter.Fill(dt);

                    dgvProducts.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách sản phẩm: " + ex.Message,
                              "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new ProductDetailForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadProducts();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa",
                              "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int productID = Convert.ToInt32(dgvProducts.SelectedRows[0].Cells["ProductID"].Value);
            var editForm = new ProductDetailForm(productID);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadProducts();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();
            int? categoryID = cboCategory.SelectedValue as int?;

            try
            {
                using (var conn = new SqlConnection(Properties.Settings.Default["ProSoftConnectionString"].ToString()
))
                {
                    conn.Open();
                    string query = @"SELECT p.ProductID, p.ProductName, p.Barcode, p.Price, 
                                    p.StockQuantity, p.CategoryID, c.CategoryName, p.IsActive
                                    FROM Products p
                                    LEFT JOIN ProductCategories c ON p.CategoryID = c.CategoryID
                                    WHERE (p.ProductName LIKE @SearchTerm OR p.Barcode LIKE @SearchTerm)";

                    if (categoryID != null)
                        query += " AND p.CategoryID = @CategoryID";

                    var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@SearchTerm", $"%{searchTerm}%");

                    if (categoryID != null)
                        cmd.Parameters.AddWithValue("@CategoryID", categoryID);

                    var adapter = new SqlDataAdapter(cmd);
                    var dt = new DataTable();
                    adapter.Fill(dt);

                    dgvProducts.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm sản phẩm: " + ex.Message,
                              "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // Code export to Excel sẽ được thêm sau
            MessageBox.Show("Chức năng xuất Excel sẽ được triển khai sau",
                          "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}