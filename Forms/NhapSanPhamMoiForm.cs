using System;
using System.ComponentModel;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using ProSoft.Models;

namespace ProSoft.Forms
{
    public partial class NhapSanPhamMoiForm : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ProductInfo ProductInfo { get; private set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Barcode { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SoLuong { get; set; }

        public NhapSanPhamMoiForm()
        {
            InitializeComponent();
        }

        private void NhapSanPhamMoiForm_Load(object sender, EventArgs e)
        {
            lblBarcode.Text = Barcode;
            txtSoLuong.Text = SoLuong.ToString();
            txtSoLuong.ReadOnly = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenSP.Text) ||
                string.IsNullOrWhiteSpace(comboBoxProductUnit.Text) ||
                string.IsNullOrWhiteSpace(txtDonGia.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtDonGia.Text, out decimal donGia))
            {
                MessageBox.Show("Đơn giá không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string maSP = GenerateNewProductCode();

            ProductInfo = new ProductInfo
            {
                ProductCode = maSP,
                ProductName = txtTenSP.Text.Trim(),
                MeasureUnit = comboBoxProductUnit.Text.Trim(),
                Quantity = SoLuong,
                Price = (double)donGia,
                Category = "Khác"
            };

            // Lưu vào cơ sở dữ liệu nếu cần
            SaveNewProductToDatabase(ProductInfo, Barcode);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private string GenerateNewProductCode()
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=ProSoft;Integrated Security=True"))
            {
                conn.Open();
                string query = "SELECT MAX(CAST(ProductCode AS INT)) FROM Products";
                SqlCommand cmd = new SqlCommand(query, conn);
                object result = cmd.ExecuteScalar();
                int newCode = (result != DBNull.Value ? Convert.ToInt32(result) : 1000) + 1;
                return newCode.ToString("00000");
            }
        }

        private void SaveNewProductToDatabase(ProductInfo product, string barcode)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=ProSoft;Integrated Security=True"))
            {
                conn.Open();
                string insertQuery = "INSERT INTO Products (ProductCode, ProductName, MeasureUnit, Price, Barcode, Category) " +
                                     "VALUES (@ProductCode, @ProductName, @MeasureUnit, @Price, @Barcode, @Category)";
                SqlCommand cmd = new SqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("@ProductCode", product.ProductCode);
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@MeasureUnit", product.MeasureUnit);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@Barcode", barcode);
                cmd.Parameters.AddWithValue("@Category", product.Category);
                cmd.ExecuteNonQuery();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
