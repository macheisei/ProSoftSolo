using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace ProSoft
{
    public partial class NhapKhoiLuongForm : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double KhoiLuong { get; private set; }

        public NhapKhoiLuongForm()
        {
            InitializeComponent();
        }

        private void NhapKhoiLuongForm_Load(object sender, EventArgs e)
        {
            txtKhoiLuong.Focus();
            txtKhoiLuong.Text = string.Empty; // Đặt giá trị mặc định cho txtKhoiLuong
            txtKhoiLuong.KeyDown += txtKhoiLuong_KeyDown;
        }

        private void txtKhoiLuong_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ConfirmInput();
            }
        }
        private void NumButton_Click(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                if (btn.Text == "←") // Nút xóa (Backspace)
                {
                    if (txtKhoiLuong.Text.Length > 0)
                        txtKhoiLuong.Text = txtKhoiLuong.Text.Substring(0, txtKhoiLuong.Text.Length - 1);
                }
                else if (btn.Text == ".")
                {
                    if (!txtKhoiLuong.Text.Contains(".")) // chỉ cho phép 1 dấu .
                        txtKhoiLuong.Text += ".";
                }
                else
                {
                    txtKhoiLuong.Text += btn.Text;
                }
            }
        }

        private void BtnBackspace_Click(object sender, EventArgs e)
        {
            if (txtKhoiLuong.Text.Length > 0)
            {
                txtKhoiLuong.Text = txtKhoiLuong.Text.Substring(0, txtKhoiLuong.Text.Length - 1);
                txtKhoiLuong.SelectionStart = txtKhoiLuong.Text.Length;
            }
        }
        private void BtnEnter_Click(object sender, EventArgs e)
        {
            ConfirmInput();
            this.Close();
        }
        private void ConfirmInput()
        {
            if (double.TryParse(txtKhoiLuong.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double result))
            {
                KhoiLuong = result;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng số (dùng dấu . cho phần thập phân).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


    }
}
