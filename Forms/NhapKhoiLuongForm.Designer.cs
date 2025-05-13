namespace ProSoft
{
    partial class NhapKhoiLuongForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtKhoiLuong;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TableLayoutPanel keypadPanel;
        private System.Windows.Forms.Button[] numberButtons;
        private System.Windows.Forms.Button btnDot;
        private System.Windows.Forms.Button btnBackspace;
        private System.Windows.Forms.Button btnEnter;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtKhoiLuong = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.keypadPanel = new System.Windows.Forms.TableLayoutPanel();
            this.numberButtons = new System.Windows.Forms.Button[10];
            this.btnDot = new System.Windows.Forms.Button();
            this.btnBackspace = new System.Windows.Forms.Button();

            this.SuspendLayout();

            // txtKhoiLuong
            this.txtKhoiLuong.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.txtKhoiLuong.Location = new System.Drawing.Point(30, 50);
            this.txtKhoiLuong.Name = "txtKhoiLuong";
            this.txtKhoiLuong.Size = new System.Drawing.Size(200, 36);
            this.txtKhoiLuong.TabIndex = 0;

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTitle.Location = new System.Drawing.Point(26, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(170, 21);
            this.lblTitle.Text = "Nhập khối lượng (kg):";

            // keypadPanel
            this.keypadPanel.ColumnCount = 3;
            this.keypadPanel.RowCount = 4;
            this.keypadPanel.Location = new System.Drawing.Point(30, 100);
            this.keypadPanel.Size = new System.Drawing.Size(200, 200);
            this.keypadPanel.TabIndex = 1;
            this.keypadPanel.ColumnStyles.Clear();
            for (int i = 0; i < 3; i++)
                this.keypadPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            for (int i = 0; i < 4; i++)
                this.keypadPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));

            // Number buttons (1–9)
            int num = 1;
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    var btn = new System.Windows.Forms.Button();
                    btn.Text = num.ToString();
                    btn.Dock = System.Windows.Forms.DockStyle.Fill;
                    btn.Font = new System.Drawing.Font("Segoe UI", 12F);
                    btn.Click += NumButton_Click;
                    this.keypadPanel.Controls.Add(btn, col, row);
                    numberButtons[num] = btn;
                    num++;
                }
            }

            // Button .
            this.btnDot.Text = ".";
            this.btnDot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDot.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnDot.Click += NumButton_Click;
            this.keypadPanel.Controls.Add(this.btnDot, 0, 3);

            // Button 0
            this.numberButtons[0] = new System.Windows.Forms.Button();
            this.numberButtons[0].Text = "0";
            this.numberButtons[0].Dock = System.Windows.Forms.DockStyle.Fill;
            this.numberButtons[0].Font = new System.Drawing.Font("Segoe UI", 12F);
            this.numberButtons[0].Click += NumButton_Click;
            this.keypadPanel.Controls.Add(this.numberButtons[0], 1, 3);

            // Button backspace
            this.btnBackspace.Text = "←";
            this.btnBackspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBackspace.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnBackspace.Click += BtnBackspace_Click;
            this.keypadPanel.Controls.Add(this.btnBackspace, 2, 3);
            
            // Thêm 1 hàng nữa cho nút Enter
            this.keypadPanel.RowCount = 5;
            this.keypadPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F)); // Hàng 4 mới

            // Button Enter
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnEnter.Text = "Enter";
            this.btnEnter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEnter.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnEnter.BackColor = System.Drawing.Color.LightGreen;
            this.btnEnter.Click += BtnEnter_Click;
            this.keypadPanel.Controls.Add(this.btnEnter, 0, 4);
            this.keypadPanel.SetColumnSpan(this.btnEnter, 3);  // chiếm toàn bộ 3 cột
            this.ClientSize = new System.Drawing.Size(270, 370);  // trước đó là 330


            // NhapKhoiLuongForm
            this.AcceptButton = null;
            this.ClientSize = new System.Drawing.Size(270, 330);
            this.Controls.Add(this.txtKhoiLuong);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.keypadPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NhapKhoiLuongForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nhập Khối Lượng";
            this.Load += new System.EventHandler(this.NhapKhoiLuongForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
