using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace ProSoft.Forms
{
    public partial class InvoiceForm : Form
    {
        public InvoiceForm()
        {
            InitializeComponent();
            LoadInvoices();
            SetupDataGridView();
            dtpFrom.Value = DateTime.Today.AddDays(-30);
            dtpTo.Value = DateTime.Today;
        }

        private void SetupDataGridView()
        {
            dgvInvoices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInvoices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInvoices.RowHeadersVisible = false;
            dgvInvoices.AllowUserToAddRows = false;
            dgvInvoices.Columns["InvoiceID"].Visible = false;
            dgvInvoices.Columns["UserID"].Visible = false;
        }

        private void LoadInvoices()
        {
            try
            {
                using (var conn = new SqlConnection(Properties.Settings.Default["ProSoftConnectionString"].ToString()))
                {
                    conn.Open();
                    string query = @"SELECT i.InvoiceID, i.InvoiceNumber, i.InvoiceDate, 
                                   u.FullName AS Cashier, i.Total, i.PaymentMethod,
                                   c.CustomerName, i.UserID
                                   FROM Invoices i
                                   LEFT JOIN Users u ON i.UserID = u.UserID
                                   LEFT JOIN Customers c ON i.CustomerID = c.CustomerID
                                   WHERE i.InvoiceDate BETWEEN @FromDate AND @ToDate";

                    var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@FromDate", dtpFrom.Value.Date);
                    cmd.Parameters.AddWithValue("@ToDate", dtpTo.Value.Date.AddDays(1));

                    var adapter = new SqlDataAdapter(cmd);
                    var dt = new DataTable();
                    adapter.Fill(dt);

                    dgvInvoices.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách hóa đơn: " + ex.Message,
                              "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadInvoices();
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvInvoices.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần xem",
                              "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int invoiceID = Convert.ToInt32(dgvInvoices.SelectedRows[0].Cells["InvoiceID"].Value);
            var detailForm = new InvoiceDetailForm(invoiceID);
            detailForm.ShowDialog();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvInvoices.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn cần in",
                              "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int invoiceID = Convert.ToInt32(dgvInvoices.SelectedRows[0].Cells["InvoiceID"].Value);
            PrintInvoice(invoiceID);
        }

        private void PrintInvoice(int invoiceID)
        {
            try
            {
                // Code in hóa đơn sẽ được triển khai sau
                MessageBox.Show($"In hóa đơn #{invoiceID} (Chức năng sẽ được triển khai sau)",
                              "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi in hóa đơn: " + ex.Message,
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