using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;
using ProSoft.Properties;
using System.Data;


namespace ProSoft.Forms
{
    public partial class CustomerDetailForm : Form
    {
        private int? _customerID;

        public CustomerDetailForm()
        {
            InitializeComponent();
            Text = "Thêm khách hàng mới";
        }

        public CustomerDetailForm(int customerID) : this()
        {
            _customerID = customerID;
            Text = "Cập nhật thông tin khách hàng";
            LoadCustomerData();
        }

        private void LoadCustomerData()
        {
            try
            {
                var conn = new SqlConnection(Properties.Settings.Default["ProSoftConnectionString"].ToString());

                {
                    conn.Open();
                    string query = "SELECT * FROM Customers WHERE CustomerID = @CustomerID";

                    var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CustomerID", _customerID);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtName.Text = reader["CustomerName"].ToString();
                            txtPhone.Text = reader["Phone"].ToString();
                            txtEmail.Text = reader["Email"].ToString();
                            txtAddress.Text = reader["Address"].ToString();
                            txtPoints.Text = reader["Points"].ToString();
                            chkActive.Checked = Convert.ToBoolean(reader["IsActive"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin khách hàng: " + ex.Message,
                              "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                using (var conn = new SqlConnection(Properties.Settings.Default["ProSoftConnectionString"].ToString()))
                {
                    conn.Open();

                    if (_customerID == null)
                    {
                        // Thêm mới
                        string insertQuery = @"INSERT INTO Customers 
                            (CustomerName, Phone, Email, Address, Points, RegistrationDate, IsActive)
                            VALUES (@Name, @Phone, @Email, @Address, @Points, GETDATE(), @Active);
                            SELECT SCOPE_IDENTITY();";

                        var cmd = new SqlCommand(insertQuery, conn);
                        AddParameters(cmd);

                        _customerID = Convert.ToInt32(cmd.ExecuteScalar());
                        MessageBox.Show("Thêm khách hàng thành công!",
                                      "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Cập nhật
                        string updateQuery = @"UPDATE Customers SET 
                            CustomerName = @Name,
                            Phone = @Phone,
                            Email = @Email,
                            Address = @Address,
                            Points = @Points,
                            IsActive = @Active
                            WHERE CustomerID = @CustomerID";

                        var cmd = new SqlCommand(updateQuery, conn);
                        AddParameters(cmd);
                        cmd.Parameters.AddWithValue("@CustomerID", _customerID);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Cập nhật thông tin thành công!",
                                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu thông tin khách hàng: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddParameters(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
            cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim());
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
            cmd.Parameters.AddWithValue("@Points", int.Parse(txtPoints.Text));
            cmd.Parameters.AddWithValue("@Active", chkActive.Checked);
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng",
                              "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại",
                              "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return false;
            }

            if (!int.TryParse(txtPoints.Text, out _))
            {
                MessageBox.Show("Điểm tích lũy phải là số nguyên",
                              "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPoints.Focus();
                return false;
            }

            return true;
        }
    }
}