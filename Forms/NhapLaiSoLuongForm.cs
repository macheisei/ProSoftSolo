using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Windows.Forms;

namespace ProSoft.Forms
{
    public partial class NhapLaiSoLuongForm : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal NewQuantity { get; private set; }

        public NhapLaiSoLuongForm(decimal currentQuantity)
        {
            InitializeComponent();
            txtEditQuantity.Text = currentQuantity.ToString("0.##");
            txtEditQuantity.SelectAll();
            this.KeyPreview = true;
            this.KeyDown += txtEditQuantity_KeyDown;
        }

        private void txtEditQuantity_KeyDown([NotNull] object? sender, KeyEventArgs e)
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
                    if (txtEditQuantity.Text.Length > 0)
                        txtEditQuantity.Text = txtEditQuantity.Text.Substring(0, txtEditQuantity.Text.Length - 1);
                }
                else if (btn.Text == ".")
                {
                    if (!txtEditQuantity.Text.Contains(".")) // chỉ cho phép 1 dấu .
                        txtEditQuantity.Text += ".";
                }
                else
                {
                    txtEditQuantity.Text += btn.Text;
                }
            }
        }
        private void btnDot_Click(object sender, EventArgs e)
        {
            if (!txtEditQuantity.Text.Contains("."))
                txtEditQuantity.Text += ".";
        }
        private void BtnBackspace_Click(object sender, EventArgs e)
        {
            if (txtEditQuantity.Text.Length > 0)
            {
                txtEditQuantity.Text = txtEditQuantity.Text.Substring(0, txtEditQuantity.Text.Length - 1);
                txtEditQuantity.SelectionStart = txtEditQuantity.Text.Length;
            }
        }
        private void BtnEnter_Click(object sender, EventArgs e)
        {
            ConfirmInput();
        }
        private void btnNumber_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            txtEditQuantity.Text += btn.Text;
        }

        private void ConfirmInput()
        {
            if (double.TryParse(txtEditQuantity.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double result))
            {
                NewQuantity = (decimal)result;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng số (dùng dấu . cho phần thập phân).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
