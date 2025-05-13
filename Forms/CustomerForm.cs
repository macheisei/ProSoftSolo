using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;



namespace ProSoft.Forms
{
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
            LoadCustomers();
            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.RowHeadersVisible = false;
            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.Columns["CustomerID"].Visible = false;
        }

        private void LoadCustomers()
        {
            try
            {
                using (var conn = new SqlConnection(Properties.Settings.Default["ProSoftConnectionString"].ToString()))
                {
                    conn.Open();
                    string query = @"SELECT CustomerID, CustomerName, Phone, Email, Address, 
                                   Points, RegistrationDate, IsActive 
                                   FROM Customers";

                    var adapter = new SqlDataAdapter(query, conn);
                    var dt = new DataTable();
                    adapter.Fill(dt);

                    dgvCustomers.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách khách hàng: " + ex.Message,
                              "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new CustomerDetailForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadCustomers();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa",
                              "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int customerID = Convert.ToInt32(dgvCustomers.SelectedRows[0].Cells["CustomerID"].Value);
            var editForm = new CustomerDetailForm(customerID);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadCustomers();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm))
            {
                LoadCustomers();
                return;
            }

            try
            {
                using (var conn = new SqlConnection(Properties.Settings.Default["ProSoftConnectionString"].ToString()))
                {
                    conn.Open();
                    string query = @"SELECT CustomerID, CustomerName, Phone, Email, Address, 
                                   Points, RegistrationDate, IsActive 
                                   FROM Customers
                                   WHERE CustomerName LIKE @SearchTerm 
                                   OR Phone LIKE @SearchTerm 
                                   OR Email LIKE @SearchTerm";

                    var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@SearchTerm", $"%{searchTerm}%");

                    var adapter = new SqlDataAdapter(cmd);
                    var dt = new DataTable();
                    adapter.Fill(dt);

                    dgvCustomers.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm khách hàng: " + ex.Message,
                              "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearch.PerformClick();
                e.Handled = true;
            }
        }
    }
}