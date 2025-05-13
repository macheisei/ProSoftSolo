using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ProSoft.Forms
{
    public partial class InvoiceDetailForm : Form
    {
        private int _invoiceID;

        public InvoiceDetailForm(int invoiceID)
        {
            InitializeComponent();
            _invoiceID = invoiceID;
            LoadInvoiceDetails();
            SetupDataGridView();
            this.Text = $"Chi tiết hóa đơn #{_invoiceID}";
        }

        private void SetupDataGridView()
        {
            dgvDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetails.RowHeadersVisible = false;
            dgvDetails.AllowUserToAddRows = false;
            dgvDetails.Columns["ProductID"].Visible = false;
        }

        private void LoadInvoiceDetails()
        {
            try
            {
                using (var conn = new SqlConnection(Properties.Settings.Default["ProSoftConnectionString"].ToString()))
                {
                    conn.Open();

                    // Load thông tin chung hóa đơn
                    string invoiceQuery = @"SELECT i.InvoiceNumber, i.InvoiceDate, i.SubTotal, 
                                           i.Tax, i.Total, i.PaymentMethod, u.FullName AS Cashier,
                                           c.CustomerName, c.Phone, c.Address, c.Points
                                           FROM Invoices i
                                           LEFT JOIN Users u ON i.UserID = u.UserID
                                           LEFT JOIN Customers c ON i.CustomerID = c.CustomerID
                                           WHERE i.InvoiceID = @InvoiceID";

                    var cmd = new SqlCommand(invoiceQuery, conn);
                    cmd.Parameters.AddWithValue("@InvoiceID", _invoiceID);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblInvoiceNumber.Text = reader["InvoiceNumber"].ToString();
                            lblDate.Text = Convert.ToDateTime(reader["InvoiceDate"]).ToString("dd/MM/yyyy HH:mm");
                            lblCashier.Text = reader["Cashier"].ToString();
                            lblCustomer.Text = reader["CustomerName"].ToString();
                            lblPhone.Text = reader["Phone"].ToString();
                            lblAddress.Text = reader["Address"].ToString();
                            lblPoints.Text = reader["Points"].ToString();
                            lblSubTotal.Text = Convert.ToDecimal(reader["SubTotal"]).ToString("N0");
                            lblTax.Text = Convert.ToDecimal(reader["Tax"]).ToString("N0");
                            lblTotal.Text = Convert.ToDecimal(reader["Total"]).ToString("N0");
                            lblPaymentMethod.Text = reader["PaymentMethod"].ToString();
                        }
                    }

                    // Load chi tiết hóa đơn
                    string detailsQuery = @"SELECT d.ProductID, p.ProductName, d.Quantity, 
                                          d.UnitPrice, d.TotalPrice
                                          FROM InvoiceDetails d
                                          JOIN Products p ON d.ProductID = p.ProductID
                                          WHERE d.InvoiceID = @InvoiceID";

                    var adapter = new SqlDataAdapter(detailsQuery, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@InvoiceID", _invoiceID);
                    var dt = new DataTable();
                    adapter.Fill(dt);

                    dgvDetails.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chi tiết hóa đơn: " + ex.Message,
                              "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintInvoice();
        }

        private void PrintInvoice()
        {
            try
            {
                // Code in hóa đơn sẽ được triển khai sau
                MessageBox.Show($"In hóa đơn #{_invoiceID} (Chức năng sẽ được triển khai sau)",
                              "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi in hóa đơn: " + ex.Message,
                              "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}