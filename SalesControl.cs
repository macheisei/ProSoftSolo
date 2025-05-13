using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using ProSoft.Forms;
using ProSoft.Models;

namespace ProSoft.Controls
{
    public partial class SalesControl : UserControl
    {
        int userId = UserSession.Id;
        string username = UserSession.Username;
        string role = UserSession.Role;
        public SalesControl()
        {
            InitializeComponent();
            LoadProducts();
        }

        private void LoadProducts()
        {
            try
            {
                using (var conn = new SqlConnection(Properties.Settings.Default["ProSoftConnectionString"].ToString()))
                {
                    conn.Open();
                    string query = "SELECT ProductID, ProductName, Price FROM Products WHERE IsActive = 1";

                    var adapter = new SqlDataAdapter(query, conn);
                    var dt = new DataTable();
                    adapter.Fill(dt);

                    dgvProducts.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgvProducts.SelectedRows[0];
            int productID = Convert.ToInt32(row.Cells["ProductID"].Value);
            string productName = row.Cells["ProductName"].Value.ToString();
            decimal price = Convert.ToDecimal(row.Cells["Price"].Value);

            // Thêm vào giỏ hàng
            dgvCart.Rows.Add(productID, productName, price, 1, price);
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            decimal subtotal = 0;
            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                subtotal += Convert.ToDecimal(row.Cells["Total"].Value);
            }

            decimal tax = subtotal * 0.1m; // VAT 10%
            decimal total = subtotal + tax;

            lblSubtotal.Text = subtotal.ToString("N0");
            lblTax.Text = tax.ToString("N0");
            lblTotal.Text = total.ToString("N0");
        }

        

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (dgvCart.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm sản phẩm vào giỏ hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = new SqlConnection(Properties.Settings.Default["ProSoftConnectionString"].ToString()))
                {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // Tạo hoá đơn
                            string invoiceQuery = @"INSERT INTO Invoices (InvoiceNumber, UserID, InvoiceDate, SubTotal, Tax, Total, PaymentMethod)
                                                VALUES (@InvoiceNumber, @UserID, GETDATE(), @SubTotal, @Tax, @Total, @PaymentMethod);
                                                SELECT SCOPE_IDENTITY();";

                            var cmd = new SqlCommand(invoiceQuery, conn, transaction);
                            cmd.Parameters.AddWithValue("@InvoiceNumber", "INV-" + DateTime.Now.ToString("yyyyMMddHHmmss"));
                            cmd.Parameters.AddWithValue("@UserID", UserSession.Id);
                            cmd.Parameters.AddWithValue("@SubTotal", decimal.Parse(lblSubtotal.Text));
                            cmd.Parameters.AddWithValue("@Tax", decimal.Parse(lblTax.Text));
                            cmd.Parameters.AddWithValue("@Total", decimal.Parse(lblTotal.Text));
                            cmd.Parameters.AddWithValue("@PaymentMethod", cboPaymentMethod.SelectedItem.ToString());

                            int invoiceID = Convert.ToInt32(cmd.ExecuteScalar());

                            // Thêm chi tiết hoá đơn
                            foreach (DataGridViewRow row in dgvCart.Rows)
                            {
                                string detailQuery = @"INSERT INTO InvoiceDetails (InvoiceID, ProductID, Quantity, UnitPrice, TotalPrice)
                                                    VALUES (@InvoiceID, @ProductID, @Quantity, @UnitPrice, @TotalPrice)";

                                cmd = new SqlCommand(detailQuery, conn, transaction);
                                cmd.Parameters.AddWithValue("@InvoiceID", invoiceID);
                                cmd.Parameters.AddWithValue("@ProductID", row.Cells["ProductID"].Value);
                                cmd.Parameters.AddWithValue("@Quantity", row.Cells["Quantity"].Value);
                                cmd.Parameters.AddWithValue("@UnitPrice", row.Cells["Price"].Value);
                                cmd.Parameters.AddWithValue("@TotalPrice", row.Cells["Total"].Value);

                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvCart.Rows.Clear();
                            CalculateTotal();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Lỗi thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}