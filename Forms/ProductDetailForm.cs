using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ProSoft.Forms
{
    public partial class ProductDetailForm : Form
    {
        private int? _productID;

        public ProductDetailForm()
        {
            InitializeComponent();
            Text = "Thêm sản phẩm mới";
            LoadCategories();
        }

        public ProductDetailForm(int productID) : this()
        {
            _productID = productID;
            Text = "Cập nhật thông tin sản phẩm";
            LoadProductData();
        }
        private void ProductDetailForm_Load(object sender, EventArgs e)
        {
            cboCategory.Items.AddRange(new object[] {
        "Thực phẩm",
        "Đồ uống",
        "Gia dụng",
        "Khác"
    });
        }


        private void LoadCategories()
        {
            try
            {
                using (var conn = new SqlConnection(Properties.Settings.Default["ProSoftConnectionString"].ToString()
))
                {
                    conn.Open();
                    string query = "SELECT CategoryID, CategoryName FROM ProductCategories WHERE IsActive = 1";

                    var adapter = new SqlDataAdapter(query, conn);
                    var dt = new DataTable();
                    adapter.Fill(dt);

                    cboCategory.DataSource = dt;
                    cboCategory.DisplayMember = "CategoryName";
                    cboCategory.ValueMember = "CategoryID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục sản phẩm: " + ex.Message,
                              "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProductData()
        {
            try
            {
                using (var conn = new SqlConnection(Properties.Settings.Default["ProSoftConnectionString"].ToString()
))
                {
                    conn.Open();
                    string query = "SELECT * FROM Products WHERE ProductID = @ProductID";

                    var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ProductID", _productID);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtName.Text = reader["ProductName"].ToString();
                            txtBarcode.Text = reader["Barcode"].ToString();
                            txtPrice.Text = reader["Price"].ToString();
                            txtCost.Text = reader["CostPrice"].ToString();
                            txtStock.Text = reader["StockQuantity"].ToString();
                            txtDescription.Text = reader["Description"].ToString();
                            cboCategory.SelectedValue = reader["CategoryID"];
                            chkActive.Checked = Convert.ToBoolean(reader["IsActive"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin sản phẩm: " + ex.Message,
                              "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                using (var conn = new SqlConnection(Properties.Settings.Default["ProSoftConnectionString"].ToString()
))
                {
                    conn.Open();

                    if (_productID == null)
                    {
                        // Thêm mới
                        string insertQuery = @"INSERT INTO Products 
                            (ProductName, Barcode, Price, CostPrice, StockQuantity, 
                             Description, CategoryID, IsActive)
                            VALUES (@Name, @Barcode, @Price, @Cost, @Stock, 
                                    @Description, @CategoryID, @Active);
                            SELECT SCOPE_IDENTITY();";

                        var cmd = new SqlCommand(insertQuery, conn);
                        AddParameters(cmd);

                        _productID = Convert.ToInt32(cmd.ExecuteScalar());
                        MessageBox.Show("Thêm sản phẩm thành công!",
                                      "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Cập nhật
                        string updateQuery = @"UPDATE Products SET 
                            ProductName = @Name,
                            Barcode = @Barcode,
                            Price = @Price,
                            CostPrice = @Cost,
                            StockQuantity = @Stock,
                            Description = @Description,
                            CategoryID = @CategoryID,
                            IsActive = @Active
                            WHERE ProductID = @ProductID";

                        var cmd = new SqlCommand(updateQuery, conn);
                        AddParameters(cmd);
                        cmd.Parameters.AddWithValue("@ProductID", _productID);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Cập nhật thông tin thành công!",
                                      "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu thông tin sản phẩm: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddParameters(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
            cmd.Parameters.AddWithValue("@Barcode", txtBarcode.Text.Trim());
            cmd.Parameters.AddWithValue("@Price", decimal.Parse(txtPrice.Text));
            cmd.Parameters.AddWithValue("@Cost", decimal.Parse(txtCost.Text));
            cmd.Parameters.AddWithValue("@Stock", int.Parse(txtStock.Text));
            cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
            cmd.Parameters.AddWithValue("@CategoryID", cboCategory.SelectedValue);
            cmd.Parameters.AddWithValue("@Active", chkActive.Checked);
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm",
                              "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (!decimal.TryParse(txtPrice.Text, out _))
            {
                MessageBox.Show("Giá bán phải là số",
                              "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return false;
            }

            if (!int.TryParse(txtStock.Text, out _))
            {
                MessageBox.Show("Số lượng tồn kho phải là số nguyên",
                              "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStock.Focus();
                return false;
            }

            if (cboCategory.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn danh mục sản phẩm",
                              "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCategory.Focus();
                return false;
            }

            return true;
        }

        private void btnGenerateBarcode_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm trước",
                              "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo barcode đơn giản từ tên sản phẩm + timestamp
            string barcode = $"PS-{txtName.Text.Substring(0, Math.Min(3, txtName.Text.Length)).ToUpper()}-{DateTime.Now:HHmmss}";
            txtBarcode.Text = barcode;
        }
    }
}