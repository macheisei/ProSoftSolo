namespace ProSoft.Forms
{
    partial class NhapLaiSoLuongForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtEditQuantity;
        private System.Windows.Forms.Button[] numberButtons;
        private System.Windows.Forms.Button btnDot;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBackspace;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtEditQuantity = new System.Windows.Forms.TextBox();
            this.numberButtons = new System.Windows.Forms.Button[10];
            this.btnDot = new System.Windows.Forms.Button();
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnBackspace = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // txtEditQuantity
            this.txtEditQuantity.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.txtEditQuantity.Location = new System.Drawing.Point(20, 20);
            this.txtEditQuantity.Name = "txtEditQuantity";
            this.txtEditQuantity.Size = new System.Drawing.Size(260, 39);
            this.txtEditQuantity.TabIndex = 0;
            this.txtEditQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

            // numberButtons
            int x = 20, y = 80;
            for (int i = 1; i <= 9; i++)
            {
                numberButtons[i] = new System.Windows.Forms.Button();
                numberButtons[i].Text = i.ToString();
                numberButtons[i].Font = new System.Drawing.Font("Segoe UI", 14F);
                numberButtons[i].Size = new System.Drawing.Size(60, 50);
                numberButtons[i].Location = new System.Drawing.Point(x, y);
                numberButtons[i].Click += new System.EventHandler(this.NumButton_Click);
                this.Controls.Add(numberButtons[i]);

                x += 70;
                if (i % 3 == 0)
                {
                    x = 20;
                    y += 60;
                }
            }

            // Button 0
            numberButtons[0] = new System.Windows.Forms.Button();
            numberButtons[0].Text = "0";
            numberButtons[0].Font = new System.Drawing.Font("Segoe UI", 14F);
            numberButtons[0].Size = new System.Drawing.Size(60, 50);
            numberButtons[0].Location = new System.Drawing.Point(20, y);
            numberButtons[0].Click += new System.EventHandler(this.NumButton_Click);
            this.Controls.Add(numberButtons[0]);

            // btnDot
            this.btnDot.Text = ".";
            this.btnDot.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnDot.Size = new System.Drawing.Size(60, 50);
            this.btnDot.Location = new System.Drawing.Point(90, y);
            this.btnDot.Click += new System.EventHandler(this.btnDot_Click);
            this.Controls.Add(this.btnDot);

            // btnBackspace
            this.btnBackspace.Text = "←";
            this.btnBackspace.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnBackspace.Size = new System.Drawing.Size(60, 50);
            this.btnBackspace.Location = new System.Drawing.Point(160, y);
            this.btnBackspace.Click += new System.EventHandler(this.BtnBackspace_Click);
            this.Controls.Add(this.btnBackspace);

            y += 60;

            // btnEnter
            this.btnEnter.Text = "Enter";
            this.btnEnter.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnEnter.Size = new System.Drawing.Size(120, 50);
            this.btnEnter.Location = new System.Drawing.Point(20, y);
            this.btnEnter.BackColor = System.Drawing.Color.LightGreen;
            this.btnEnter.Click += new System.EventHandler(this.BtnEnter_Click);
            this.Controls.Add(this.btnEnter);

            // btnCancel
            this.btnCancel.Text = "Huỷ";
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Size = new System.Drawing.Size(120, 50);
            this.btnCancel.Location = new System.Drawing.Point(160, y);
            this.btnCancel.BackColor = System.Drawing.Color.LightCoral;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.Controls.Add(this.btnCancel);

            // NhapLaiSoLuongForm
            this.ClientSize = new System.Drawing.Size(300, y + 80);
            this.Controls.Add(this.txtEditQuantity);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Name = "NhapLaiSoLuongForm";
            this.Text = "Nhập lại số lượng";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
