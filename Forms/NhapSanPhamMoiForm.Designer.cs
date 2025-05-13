namespace ProSoft.Forms
{
    partial class NhapSanPhamMoiForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;

        private void InitializeComponent()
        {
            lblBarcode = new Label();
            txtTenSP = new TextBox();
            txtDonGia = new TextBox();
            txtSoLuong = new TextBox();
            btnOK = new Button();
            btnCancel = new Button();
            comboBoxProductGroup = new ComboBox();
            comboBoxProductUnit = new ComboBox();
            txtMeasureValue = new TextBox();
            txtSLnhap = new TextBox();
            dateTimePickerHSD = new DateTimePicker();
            SuspendLayout();
            // 
            // lblBarcode
            // 
            lblBarcode.AutoSize = true;
            lblBarcode.Location = new Point(26, 15);
            lblBarcode.Name = "lblBarcode";
            lblBarcode.Size = new Size(73, 15);
            lblBarcode.TabIndex = 0;
            lblBarcode.Text = "Mã vạch: ---";
            // 
            // txtTenSP
            // 
            txtTenSP.Location = new Point(26, 45);
            txtTenSP.Margin = new Padding(3, 2, 3, 2);
            txtTenSP.Name = "txtTenSP";
            txtTenSP.PlaceholderText = "Tên sản phẩm";
            txtTenSP.Size = new Size(263, 23);
            txtTenSP.TabIndex = 1;
            // 
            // txtDonGia
            // 
            txtDonGia.Location = new Point(26, 187);
            txtDonGia.Margin = new Padding(3, 2, 3, 2);
            txtDonGia.Name = "txtDonGia";
            txtDonGia.PlaceholderText = "Đơn giá";
            txtDonGia.Size = new Size(263, 23);
            txtDonGia.TabIndex = 3;
            // 
            // txtSoLuong
            // 
            txtSoLuong.Location = new Point(26, 303);
            txtSoLuong.Margin = new Padding(3, 2, 3, 2);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.ReadOnly = true;
            txtSoLuong.Size = new Size(263, 23);
            txtSoLuong.TabIndex = 4;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(64, 347);
            btnOK.Margin = new Padding(3, 2, 3, 2);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(88, 41);
            btnOK.TabIndex = 5;
            btnOK.Text = "Đồng ý";
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(169, 347);
            btnCancel.Margin = new Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(88, 41);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Hủy";
            btnCancel.Click += btnCancel_Click;
            // 
            // comboBoxProductGroup
            // 
            comboBoxProductGroup.DisplayMember = "\"RAU CỦ\", \"TRÁI CÂY\", \"BÁNH MÌ - SỮA\", \"THỊT - CÁ\", \"ĐỒ UỐNG\", \"VỎ CHAI BIA\", \"KHÁC\"";
            comboBoxProductGroup.FormattingEnabled = true;
            comboBoxProductGroup.Items.AddRange(new object[] { "\"KG\", \"Gram\", \"Lít\", \"ML\", \"HỘP\", \"CÁI\", \"CHAI\", \"Lon\", \"GÓI\", \"THÙNG\", \"BÌNH\"" });
            comboBoxProductGroup.Location = new Point(26, 78);
            comboBoxProductGroup.Name = "comboBoxProductGroup";
            comboBoxProductGroup.Size = new Size(263, 23);
            comboBoxProductGroup.TabIndex = 7;
            comboBoxProductGroup.ValueMember = "\"RAU CỦ\", \"TRÁI CÂY\", \"BÁNH MÌ - SỮA\", \"THỊT - CÁ\", \"ĐỒ UỐNG\", \"VỎ CHAI BIA\", \"KHÁC\"";
            // 
            // comboBoxProductUnit
            // 
            comboBoxProductUnit.DisplayMember = "\"KG\", \"Gram\", \"Lít\", \"ML\", \"HỘP\", \"CÁI\", \"CHAI\", \"Lon\", \"GÓI\", \"THÙNG\", \"BÌNH\"";
            comboBoxProductUnit.FormattingEnabled = true;
            comboBoxProductUnit.Items.AddRange(new object[] { "\"KG\", \"Gram\", \"Lít\", \"ML\", \"HỘP\", \"CÁI\", \"CHAI\", \"Lon\", \"GÓI\", \"THÙNG\", \"BÌNH\"" });
            comboBoxProductUnit.Location = new Point(26, 148);
            comboBoxProductUnit.Name = "comboBoxProductUnit";
            comboBoxProductUnit.Size = new Size(263, 23);
            comboBoxProductUnit.TabIndex = 8;
            comboBoxProductUnit.ValueMember = "\"KG\", \"Gram\", \"Lít\", \"ML\", \"HỘP\", \"CÁI\", \"CHAI\", \"Lon\", \"GÓI\", \"THÙNG\", \"BÌNH\"";
            // 
            // txtMeasureValue
            // 
            txtMeasureValue.Location = new Point(26, 110);
            txtMeasureValue.Name = "txtMeasureValue";
            txtMeasureValue.PlaceholderText = "Giá trị đo lường";
            txtMeasureValue.Size = new Size(263, 23);
            txtMeasureValue.TabIndex = 9;
            // 
            // txtSLnhap
            // 
            txtSLnhap.Location = new Point(27, 220);
            txtSLnhap.Name = "txtSLnhap";
            txtSLnhap.PlaceholderText = "Số lượng nhập";
            txtSLnhap.Size = new Size(263, 23);
            txtSLnhap.TabIndex = 10;
            // 
            // dateTimePickerHSD
            // 
            dateTimePickerHSD.Location = new Point(28, 258);
            dateTimePickerHSD.Name = "dateTimePickerHSD";
            dateTimePickerHSD.Size = new Size(262, 23);
            dateTimePickerHSD.TabIndex = 11;
            // 
            // NhapSanPhamMoiForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(315, 413);
            Controls.Add(dateTimePickerHSD);
            Controls.Add(txtSLnhap);
            Controls.Add(txtMeasureValue);
            Controls.Add(comboBoxProductUnit);
            Controls.Add(comboBoxProductGroup);
            Controls.Add(lblBarcode);
            Controls.Add(txtTenSP);
            Controls.Add(txtDonGia);
            Controls.Add(txtSoLuong);
            Controls.Add(btnOK);
            Controls.Add(btnCancel);
            Margin = new Padding(3, 2, 3, 2);
            Name = "NhapSanPhamMoiForm";
            Text = "Nhập sản phẩm mới";
            Load += NhapSanPhamMoiForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }
        private ComboBox comboBoxProductGroup;
        private ComboBox comboBoxProductUnit;
        private TextBox txtMeasureValue;
        private TextBox txtSLnhap;
        private DateTimePicker dateTimePickerHSD;
    }
}