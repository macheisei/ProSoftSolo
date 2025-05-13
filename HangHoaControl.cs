using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing.Printing;
using ProSoft.Controls;
using ProSoft.Models;

namespace ProSoft.Controls
{
    public partial class HangHoaControl : UserControl
    {
        // Kết nối đến cơ sở dữ liệu
        private readonly string connectionString = "Server=192.168.89.51,1433;Database=ProSoft;User Id=Admin;Password=123456;";
        private int selectedProductID;
        private string selectedImagePath = "";
        private readonly ErrorProvider errorProvider = new ErrorProvider();
        private readonly ToolTip toolTip = new ToolTip();


        private PrintDocument printDocument = new PrintDocument();
        private string printProductCode = "";
        private string printProductName = "";
        private string printProductPrice = "";

        private int selectedRowIndex;
        int userId = UserSession.Id;
        string username = UserSession.Username;
        string role = UserSession.Role;
        // Enum định nghĩa vai trò người dùng
        public enum UserRole { Admin, Cashier }

        // Lớp tĩnh lưu thông tin người dùng hiện tại
        public static class CurrentProductUser
        {
            public static string Username { get; set; }
            public static UserRole Role { get; set; }
        }

        // Enum định nghĩa đơn vị sản phẩm

        public HangHoaControl()
        {
            InitializeComponent();
            this.Load += HangHoaControl_Load;
            ApplyRolePermissions();
            txtBarcode.Focus();
        }
        // Sự kiện khi điều khiển được tải
        private void HangHoaControl_Load(object sender, EventArgs e)
        {
            txtProductFind.Focus();
            txtBarcode.Focus();
            ComboBoxCategory.Items.AddRange(new string[]
                { "RAU CỦ", "TRÁI CÂY", "BÁNH MÌ - SỮA", "THỊT - CÁ", "ĐỒ UỐNG", "VỎ CHAI BIA", "KHÁC" });
            ComboBoxProductUnit.Items.AddRange(new string[]
                { "KG", "Gram", "Lít", "ML", "HỘP", "CÁI", "CHAI", "Lon", "GÓI", "THÙNG", "BÌNH"       });
            ComboBoxCategory.SelectedIndex = 0;
            ComboBoxProductUnit.SelectedIndex = 0;
            SetupProductFindGrid();
            LoadAllProducts();
            txtBarcode.KeyDown += txtBarcode_KeyDown;

        }
        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string barcode = txtBarcode.Text.Trim();
                if (!string.IsNullOrEmpty(barcode))
                {
                    LoadProductInfo(barcode);
                }
            }
        }
        private void LoadProductInfo(string barcode)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM dbo.Products WHERE Barcode = @Barcode";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Barcode", barcode);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtProductCode.Text = reader["ProductCode"]?.ToString();

                    ComboBoxCategory.SelectedItem = reader["Category"] != DBNull.Value
                        ? reader["Category"].ToString()
                        : null;

                    txtProductName.Text = reader["ProductName"]?.ToString();

                    txtProductSellPrice.Text = reader["Price"] != DBNull.Value
                        ? reader["Price"].ToString()
                        : "0";

                    txtProductWV.Text = reader["MeasureValue"] != DBNull.Value
                        ? reader["MeasureValue"].ToString()
                        : "";

                    ComboBoxProductUnit.SelectedItem = reader["MeasureUnit"] != DBNull.Value
                        ? reader["MeasureUnit"].ToString()
                        : null;

                    if (reader["ExpiryDate"] != DBNull.Value)
                        DateTimeControlHSD.Value = Convert.ToDateTime(reader["ExpiryDate"]);
                    else
                        DateTimeControlHSD.Value = DateTime.Now;

                    txtQuInventory.Text = reader["Stock"] != DBNull.Value
                        ? reader["Stock"].ToString()
                        : "0";

                    txtProductBuyPrice.Text = reader["Cost"] != DBNull.Value
                        ? reader["Cost"].ToString()
                        : "0";
                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        string imagePath = reader["ImagePath"].ToString();
                        if (File.Exists(imagePath))
                        {
                            pictureBoxProduct.Image = Image.FromFile(imagePath);  // Gán ảnh từ tệp
                        }
                        else
                        {
                            pictureBoxProduct.Image = null;  // Nếu tệp không tồn tại, gán null hoặc ảnh mặc định
                        }
                    }
                    else
                    {
                        pictureBoxProduct.Image = null;  // Nếu không có ảnh, gán null hoặc ảnh mặc định
                    }

                }
                else
                {
                    ClearProductInfoFields();
                }
            }
        }

        private void ClearProductInfoFields()
        {
            txtProductCode.Clear();
            txtBarcode.Clear();
            ComboBoxCategory.SelectedIndex = -1;
            txtProductName.Clear();
            txtProductSellPrice.Clear();
            txtProductWV.Clear();
            ComboBoxProductUnit.SelectedIndex = -1;
            DateTimeControlHSD.Value = DateTime.Now;
            txtQuInventory.Clear();
            txtProductBuyPrice.Clear();
        }
        private void HangHoaControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
                btnSaveProduct.PerformClick();
            else if (e.KeyCode == Keys.F8)
                btnPrintLabelPrice.PerformClick();
        }
        private void btnSaveProduct_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                SaveProduct();
            }
            else
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void SaveProduct()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            MERGE INTO dbo.Products AS target
            USING (SELECT @Barcode AS Barcode) AS source
            ON target.Barcode = source.Barcode
            WHEN MATCHED THEN
                UPDATE SET
                    ProductCode = @ProductCode,
                    Category = @Category,
                    ProductName = @ProductName,
                    Price = @Price,
                    MeasureValue = @MeasureValue,
                    MeasureUnit = @MeasureUnit,
                    ExpiryDate = @ExpiryDate,
                    Stock = @Stock,
                    Cost = @Cost,
                    ImagePath = @ImagePath
            WHEN NOT MATCHED THEN
                INSERT (Barcode, ProductCode, Category, ProductName, Price, MeasureValue, MeasureUnit, ExpiryDate, Stock, Cost)
                VALUES (@Barcode, @ProductCode, @Category, @ProductName, @Price, @MeasureValue, @MeasureUnit, @ExpiryDate, @Stock, @Cost, @ImagePath);";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Barcode", txtBarcode.Text.Trim());
                cmd.Parameters.AddWithValue("@ProductCode", txtProductCode.Text.Trim());
                cmd.Parameters.AddWithValue("@Category", ComboBoxCategory.SelectedItem?.ToString() ?? string.Empty);
                cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text.Trim());
                // Kiểm tra và chuyển đổi Price (Số thập phân)
                decimal price;
                if (!decimal.TryParse(txtProductSellPrice.Text, out price))
                {
                    MessageBox.Show("Giá sản phẩm không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Nếu giá không hợp lệ, dừng quá trình lưu
                }
                cmd.Parameters.AddWithValue("@Price", price);

                // Kiểm tra và chuyển đổi MeasureValue (Giá trị số thập phân)
                decimal measureValue;
                if (!decimal.TryParse(txtProductWV.Text, out measureValue))
                {
                    MessageBox.Show("Giá trị đo không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Nếu MeasureValue không hợp lệ, dừng quá trình lưu
                }
                cmd.Parameters.AddWithValue("@MeasureValue", measureValue);

                // Kiểm tra và chuyển đổi Stock (Số nguyên)
                int stock;
                if (!int.TryParse(txtQuInventory.Text, out stock))
                {
                    MessageBox.Show("Số lượng sản phẩm không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Nếu Stock không hợp lệ, dừng quá trình lưu
                }
                cmd.Parameters.AddWithValue("@Stock", stock);

                // Kiểm tra và chuyển đổi Cost (Số thập phân)
                decimal cost;
                if (!decimal.TryParse(txtProductBuyPrice.Text, out cost))
                {
                    MessageBox.Show("Giá nhập không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Nếu Cost không hợp lệ, dừng quá trình lưu
                }
                cmd.Parameters.AddWithValue("@Cost", cost);

                cmd.Parameters.AddWithValue("@MeasureUnit", ComboBoxProductUnit.SelectedItem?.ToString() ?? string.Empty);
                cmd.Parameters.AddWithValue("@ExpiryDate", DateTimeControlHSD.Value);
                cmd.Parameters.AddWithValue("@ImagePath", pictureBoxProduct.Image);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Dữ liệu sản phẩm đã được lưu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearProductInfoFields();
            txtBarcode.Focus();
        }

        // Áp dụng quyền dựa trên vai trò người dùng
        private void ApplyRolePermissions()
        {
            UserRole role = (UserRole)Enum.Parse(typeof(UserRole), UserSession.Role);
            if (role == UserRole.Admin)
            {
                dataGridViewProductFind.ReadOnly = false;
                if (dataGridViewProductFind.Columns.Contains("Delete"))
                    dataGridViewProductFind.Columns["Delete"].Visible = true;
            }
            else
            {
                dataGridViewProductFind.ReadOnly = true;
                if (dataGridViewProductFind.Columns.Contains("Delete"))
                    dataGridViewProductFind.Columns["Delete"].Visible = false;
            }
        }

        private void btnPrintLabelPrice_Click(object sender, EventArgs e)
        {
            PrintLabel();
        }
        private void PrintLabel()
        {
            string labelContent = $"Tên SP: {txtProductName.Text}\n" +
                                  $"Khối lượng: {txtProductWV.Text} {ComboBoxProductUnit.SelectedItem}\n" +
                                  $"Giá: {txtProductSellPrice.Text} VND\n" +
                                  $"Mã vạch: {txtBarcode.Text}";

            // Giả sử sử dụng máy in Epson TM-T20II
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrinterSettings.PrinterName = "Epson TM-T20II";

            // Ensure PrinterSettings.PrinterName is not null
            if (!string.IsNullOrEmpty(printDoc.PrinterSettings.PrinterName))
            {
                printDoc.PrintPage += (s, e) =>
                {
                    e.Graphics.DrawString(labelContent, new Font("Arial", 12), Brushes.Black, new PointF(10, 10));
                };
                printDoc.Print();
            }
            else
            {
                MessageBox.Show("Printer is not configured properly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Tab tabProductFindEdit

        private void txtProductFind_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtProductFind.Text.Trim();
            if (searchText.Length >= 3)
            {
                SearchProducts(searchText);
            }
        }
        private void SearchProducts(string searchText)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"
                SELECT * FROM dbo.Products
                WHERE Barcode LIKE @SearchText
                   OR ProductName LIKE @SearchText";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridViewProductFind.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }
        private void dataGridViewProductFind_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewProductFind.SelectedRows.Count > 0)
                selectedRowIndex = dataGridViewProductFind.SelectedRows[0].Index;
        }

        private void btnEditProductRow_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex >= 0)
                dataGridViewProductFind.ReadOnly = false;
        }
        private void btnSaveEditProduct_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex < 0) return;

            DataGridViewRow row = dataGridViewProductFind.Rows[selectedRowIndex];
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE dbo.Products SET ProductCode=@ProductCode, Category=@Category, ProductName=@ProductName, Price=@Price, MeasureValue=@MeasureValue, MeasureUnit=@MeasureUnit, ExpiryDate=@ExpiryDate, Stock=@Stock, Cost=@Cost WHERE Barcode=@Barcode", conn);

                cmd.Parameters.AddWithValue("@Barcode", row.Cells["Barcode"].Value);
                cmd.Parameters.AddWithValue("@ProductCode", row.Cells["ProductCode"].Value);
                cmd.Parameters.AddWithValue("@Category", row.Cells["Category"].Value);
                cmd.Parameters.AddWithValue("@ProductName", row.Cells["ProductName"].Value);
                cmd.Parameters.AddWithValue("@Price", row.Cells["Price"].Value);
                cmd.Parameters.AddWithValue("@MeasureValue", row.Cells["MeasureValue"].Value);
                cmd.Parameters.AddWithValue("@MeasureUnit", row.Cells["MeasureUnit"].Value);
                cmd.Parameters.AddWithValue("@ExpiryDate", row.Cells["ExpiryDate"].Value);
                cmd.Parameters.AddWithValue("@Stock", row.Cells["Stock"].Value);
                cmd.Parameters.AddWithValue("@Cost", row.Cells["Cost"].Value);
                cmd.ExecuteNonQuery();
            }
            LoadAllProducts();
            dataGridViewProductFind.ReadOnly = true;
        }
        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex < 0) return;

            var result = MessageBox.Show("Bạn thật sự muốn xoá sản phẩm khỏi CSDL?", "Xác nhận xoá", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DataGridViewRow row = dataGridViewProductFind.Rows[selectedRowIndex];
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM dbo.Products WHERE Barcode = @Barcode", conn);
                    cmd.Parameters.AddWithValue("@Barcode", row.Cells["Barcode"].Value);
                    cmd.ExecuteNonQuery();
                }
                LoadAllProducts();
            }
        }
        private void SetupProductFindGrid()
        {
            dataGridViewProductFind.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewProductFind.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewProductFind.MultiSelect = false;
            dataGridViewProductFind.ReadOnly = true;
            dataGridViewProductFind.AllowUserToAddRows = false;
            dataGridViewProductFind.AllowUserToDeleteRows = false;
        }

        private void LoadAllProducts()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string connectionString = "Server=192.168.89.51,1433;Database=ProSoft;User Id=Admin;Password=123456;TrustServerCertificate=True;";

                string query = "SELECT * FROM dbo.Products ORDER BY ProductName";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridViewProductFind.DataSource = dt;
            }
        }

        // Sự kiện khi nhấn nút "Làm mới"
        private void btnFresh_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in tabProductInfo.Controls)
            {
                if (ctrl is TextBox) ((TextBox)ctrl).Clear();
            }
            ComboBoxCategory.SelectedIndex = -1;
            ComboBoxProductUnit.SelectedIndex = -1;
            DateTimeControlHSD.Value = DateTime.Now;
            txtBarcode.Focus();
        }

        // Kiểm tra và xác thực dữ liệu đầu vào
        private bool ValidateForm()
        {
            errorProvider.Clear();

            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                errorProvider.SetError(txtProductName, "Tên sản phẩm không được để trống.");
                return false;
            }

            if (!decimal.TryParse(txtProductSellPrice.Text, out _))
            {
                errorProvider.SetError(txtProductSellPrice, "Giá bán phải là số hợp lệ.");
                return false;
            }

            if (!float.TryParse(txtProductWV.Text, out _))
            {
                errorProvider.SetError(txtProductWV, "Giá trị định lượng không hợp lệ.");
                return false;
            }

            if (ComboBoxProductUnit.SelectedIndex < 0)
            {
                errorProvider.SetError(ComboBoxProductUnit, "Vui lòng chọn đơn vị tính.");
                return false;
            }

            if (ComboBoxCategory.SelectedIndex < 0)
            {
                errorProvider.SetError(ComboBoxCategory, "Vui lòng chọn nhóm hàng.");
                return false;
            }

            return true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"C:\Datas";  // Đặt thư mục mặc định
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";  // Bộ lọc hình ảnh
            openFileDialog.Title = "Chọn hình ảnh sản phẩm";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn tệp đã chọn
                string filePath = openFileDialog.FileName;

                // Chuyển tệp hình ảnh thành mảng byte
                byte[] imageBytes = File.ReadAllBytes(filePath);

                // Hiển thị hình ảnh lên PictureBox
                pictureBoxProduct.Image = Image.FromFile(filePath);

            }
        }
    }
}


